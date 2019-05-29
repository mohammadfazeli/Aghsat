using Aghsat.Domain;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.ServiceLayer.Interface;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Data.Entity;
using System.Security.Principal;
using Aghsat.DataLayer.AghsatContext;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;

namespace Aghsat.ServiceLayer.Services
{
    public class ApplicationUserManagerService
       : UserManager<User, int>,
       IApplicationUserManagerService
    {
         readonly IDataProtectionProvider _dataProtectionProvider;
         readonly IApplicationRoleManagerService _roleManager;
         readonly IUserStore _store;
         readonly IUnitOfWork _uow;
         readonly IDbSet<User> _users;
         readonly Lazy<Func<IIdentity>> _identity;
         User _user;

        public ApplicationUserManagerService(
            IUserStore store,
            IUnitOfWork uow,
            Lazy<Func<IIdentity>> identity, // For lazy loading -> Controller gets constructed before the HttpContext has been set by ASP.NET.
            IApplicationRoleManagerService roleManager,
            IDataProtectionProvider dataProtectionProvider,
            IIdentityMessageService smsService,
            IIdentityMessageService emailService)
            : base((IUserStore<User, int>)store)
        {
            _store = store;
            _uow = uow;
            _identity = identity;
            _users = _uow.Set<User>();
            _roleManager = roleManager;
            _dataProtectionProvider = dataProtectionProvider;
            this.SmsService = smsService;
            this.EmailService = emailService;

            //this.SeedDatabase();
            createUserManager();
        }

        public User FindById(int userId)
        {
            return _users.Find(userId);
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(User User)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await CreateIdentityAsync(User, DefaultAuthenticationTypes.ApplicationCookie).ConfigureAwait(false);

            // Add custom user claims here
            userIdentity.AddClaim(new Claim("user-email", User.Email));

            return userIdentity;
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            return this.Users.ToListAsync();
        }

        public override async Task<IdentityResult> CreateAsync(User user,string Pass)
        {
            return await base.CreateAsync(user, Pass);
            
        }

        public User GetCurrentUser()
        {
            return _user ?? (_user = this.FindById(GetCurrentUserId()));
        }

        public async Task<User> GetCurrentUserAsync()
        {
            return _user ?? (_user = await this.FindByIdAsync(GetCurrentUserId()).ConfigureAwait(false));
        }

        public int GetCurrentUserId()
        {
            return _identity.Value().GetUserId<int>();
        }

        public async Task<bool> HasPassword(int userId)
        {
            var user = await FindByIdAsync(userId).ConfigureAwait(false);
            return user != null && user.PasswordHash != null;
        }

        public async Task<bool> HasPhoneNumber(int userId)
        {
            var user = await FindByIdAsync(userId).ConfigureAwait(false);
            return user != null && user.PhoneNumber != null;
        }

        public Func<CookieValidateIdentityContext, Task> OnValidateIdentity()
        {
            return SecurityStampValidator.OnValidateIdentity<ApplicationUserManagerService, User,int>(
                         validateInterval: TimeSpan.FromSeconds(0),
                         regenerateIdentityCallback: (manager, user) => manager.GenerateUserIdentityAsync(user),
                         getUserIdCallback: claimsIdentity => claimsIdentity.GetUserId<int>());
        }

        public  void SeedDatabase()
        {
            const string name = "Farhad@gmail.com";
            const string password = "Farhad@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = _roleManager.FindRoleByName(roleName);
            if (role == null)
            {
                role = new Role(roleName);
                var roleResult = _roleManager.CreateRole(role);
                if (!roleResult.Succeeded)
                {
                    throw new InvalidOperationException(string.Join(", ", roleResult.Errors));
                }
            }

            var user = this.FindByName(name);
            if (user == null)
            {
                user = new User { UserName = name, Email = name };
                var createResult = this.Create(user, password);
                if (!createResult.Succeeded)
                {
                    throw new InvalidOperationException(string.Join(", ", createResult.Errors));
                }

                var setLockoutResult = this.SetLockoutEnabled(user.Id, false);
                if (!setLockoutResult.Succeeded)
                {
                    throw new InvalidOperationException(string.Join(", ", setLockoutResult.Errors));
                }
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = this.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var addToRoleResult = this.AddToRole(user.Id, role.Name);
                if (!addToRoleResult.Succeeded)
                {
                    throw new InvalidOperationException(string.Join(", ", addToRoleResult.Errors));
                }
            }
        }

         void createUserManager()
        {
            // Configure validation logic for usernames
            this.UserValidator = new UserValidator<User, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            this.UserLockoutEnabledByDefault = true;
            this.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            this.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            this.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<User, int>
            {
                MessageFormat = "Your security code is: {0}"
            });
            this.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<User, int>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });

            if (_dataProtectionProvider != null)
            {
                var dataProtector = _dataProtectionProvider.Create("ASP.NET Identity");
                this.UserTokenProvider = new DataProtectorTokenProvider<User, int>(dataProtector);
            }
        }
    }


    //public class UserManagerService : UserManager<User, int>, IUserManagerService
    //{
    //    public UserManagerService(IUserStore<User, int> store) : base(store)
    //    {

    //    }

    //    #region Fileds

    //     readonly IUnitWork _uow;
    //     readonly IDbSet<User> _users;
    //     readonly IDbSet<UserRole> _userRoles;
    //     readonly IApplicationRoleManagerService _applicationRoleManagerService;
    //    // readonly IDataProtectionProvider _dataProtectionProvider;
    //     readonly IUserStore<User, int> _userStore;
    //     readonly IIdentity _identity;
    //    // readonly IUserDealerDataAccessService _userDealerDataAccessService;
    //     User _user;

    //    #endregion

    //    #region Methods

    //    #region Constructors

    //    public UserManagerService(IUserStore<User, int> userStore, IUnitWork uow, IIdentity identity, IApplicationRoleManagerService applicationRoleManagerService, IIdentityMessageService smsService, IIdentityMessageService emailService)
    //        : base(userStore)
    //    {
    //        _userStore = userStore;
    //        _uow = uow;
    //        _identity = identity;
    //        _users = _uow.set<User>();
    //        _userRoles = _uow.set<UserRole>();
    //        _applicationRoleManagerService = applicationRoleManagerService;
    //        //_dataProtectionProvider = dataProtectionProvider;
    //        SmsService = smsService;
    //        EmailService = emailService;
    //        //_userDealerDataAccessService = userDealerDataAccessService;
    //        CreateUserManager();
    //    }

    //    #endregion

    //    #region Get & GetAll
    //    public User GetModel(int? userId)
    //    {
    //        var user = _users.SingleOrDefault(row => row.Id == userId);
    //        return user;
    //    }

    //    //public User GetWithNavigation(int id, ToolbarActions toolbarActions)
    //    //{
    //    //    switch (toolbarActions)
    //    //    {
    //    //        case ToolbarActions.First:
    //    //            return _users.OrderBy(x => x.Code).FirstOrDefault();
    //    //        case ToolbarActions.Previous:

    //    //            var code = GetModel(id).Code;
    //    //            var minCode = _users.OrderBy(x => x.Code).FirstOrDefault().Code;
    //    //            if (code == minCode)
    //    //            {
    //    //                return GetModel(id);
    //    //            }
    //    //            return _users.OrderByDescending(x => x.Code).FirstOrDefault(x => x.Code < code);

    //    //        case ToolbarActions.Next:

    //    //            var code2 = GetModel(id).Code;
    //    //            var maxCode = _users.OrderByDescending(x => x.Code).FirstOrDefault().Code;
    //    //            if (code2 == maxCode)
    //    //            {
    //    //                return GetModel(id);
    //    //            }
    //    //            return _users.OrderBy(x => x.Code).FirstOrDefault(x => x.Code > code2);

    //    //        case ToolbarActions.Last:
    //    //            return _users.OrderByDescending(x => x.Code).FirstOrDefault();
    //    //        default:
    //    //            return GetModel(id);
    //    //    }
    //    //}
    //    //public void SetLogonUserInformation(string paramUserId)
    //    //{
    //    //    var userId = int.Parse(paramUserId);
    //    //    var dealerlist = EntityFrameworkExtentions.GetDealerList(userId);
    //    //    var warehouseList = EntityFrameworkExtentions.GetWarehouseList(userId);
    //    //    var taxes = EntityFrameworkExtentions.GetTax();
    //    //    var companyInfo = EntityFrameworkExtentions.GetCompanyInfo();
    //    //    var logonuserInformationSession = HttpContext.Current.Session;
    //    //    var centralDealer = EntityFrameworkExtentions.GetCentralDealer();
    //    //    var centralBranch = EntityFrameworkExtentions.GetCentralBranch(centralDealer);
    //    //    var fiscalYear = EntityFrameworkExtentions.GetFiscalYear(userId);
    //    //    var logonuserInformation = _users.Include(p => p.Personnel).Where(p => p.Id == userId).AsEnumerable().Select(p => new LogonUserInformationModel
    //    //    {
    //    //        UserId = p.Id,
    //    //        UserName = p.UserName,
    //    //        DealerId = LogonUserInformation.SelectedDealerId ?? p.Personnel.DealerId.Value,
    //    //        SelectedDealerId = LogonUserInformation.SelectedDealerId ?? p.Personnel.DealerId.Value,
    //    //        UnitId = LogonUserInformation.SelectedDealerId ?? p.Personnel.Job.Unit.UniqueId,
    //    //        JobId = LogonUserInformation.SelectedDealerId ?? p.Personnel.Job.UniqueId,
    //    //        DealerName = p.Personnel.Dealer.Name,
    //    //        DealerNo = p.Personnel.Dealer.DealerNo,
    //    //        BranchId = p.Personnel.BranchId.Value,
    //    //        BranchNo = p.Personnel.Branch.BranchNo,
    //    //        BranchName = p.Personnel.Branch.Name,
    //    //        PersonnelId = p.PersonnelId.Value,
    //    //        PersonnelName = p.Personnel.FirstName + " " + p.Personnel.LastName,
    //    //        VersionDate = VersionController.VersionController.VersionDate,
    //    //        VersionTime = VersionController.VersionController.VersionTime,
    //    //        DealerDataList = dealerlist,
    //    //        WarehouseList = warehouseList,
    //    //        TaxAndToll = taxes.TaxAndTollPercent,
    //    //        Tax = taxes.TaxPercent,
    //    //        Toll = taxes.TollPercent,
    //    //        CentralDealerId = centralDealer,
    //    //        CentralBranchId = centralBranch,
    //    //        DealersGradeId = p.Personnel.Dealer.GradeId.Value,
    //    //        IsSuspend = p.Personnel.Dealer.DealerStatus.Code == (int)DealerStatusEnum.Suspend,
    //    //        IsActive = p.Personnel.Dealer.DealerStatus.Code == (int)DealerStatusEnum.Active,
    //    //        CompanyName = companyInfo.FarsiName,
    //    //        Address = companyInfo.Address,
    //    //        EconomicCode = companyInfo.EconomicCode,
    //    //        Phone = companyInfo.Tel,
    //    //        CurrentFiscalYearId = fiscalYear?.UniqueId ?? new int(),
    //    //        FiscalYear = fiscalYear?.ToString(),
    //    //        FiscalYearId = fiscalYear?.UniqueId ?? new int(),
    //    //        LockedFiscalYear = false,
    //    //        FiscalYearDateTo = fiscalYear?.FromDate ?? default(DateTime),
    //    //        FiscalYearDateFrom = fiscalYear?.ToDate ?? default(DateTime)
    //    //    }).FirstOrDefault();
    //    //    logonuserInformationSession["userInformationSession"] = logonuserInformation;
    //    //    LogonUserInformation.Init();
    //    //}
    //    //public int GetSystemAdminUserId()
    //    //{
    //    //    return _users.First(p => p.IsSystemAdmin).Id;
    //    //}
    //    //public User GetModel(int code)
    //    //{
    //    //    return _users.SingleOrDefault(row => row.Code == code);
    //    //}
    //    //public User GetByUserName(string username)
    //    //{
    //    //    return _users.Include(p => p.Personnel).Include(p => p.Personnel.Dealer).FirstOrDefault(row => row.UserName.ToLower() == username.ToLower());
    //    //}
    //    public User GetCurrentUser()
    //    {
    //        return _user ?? (_user = GetModel(GetCurrentUserId()));
    //    }
    //    //public bool IsSystemAdmin()
    //    //{
    //    //    var userid = GetCurrentUserId();
    //    //    return _users.Any(row => row.Id == userid && (row.IsSystemAccount || row.IsSystemAdmin));
    //    //}
    //    //public bool IsSystemAccount()
    //    //{
    //    //    var userid = GetCurrentUserId();
    //    //    return _users.Any(row => row.Id == userid && (row.IsSystemAccount));
    //    //}
    //    //public bool IsUserActive(string userName)
    //    //{
    //    //    var user = GetByUserName(userName);
    //    //    if (user.Personnel.Dealer.DealerStatusId == (int)DealerStatusEnum.InActive)
    //    //    {
    //    //        MessageService.NotificationError(Resources.Resources.DealerIsInActive);
    //    //        return false;
    //    //    }
    //    //    if (!user.IsActive)
    //    //    {
    //    //        MessageService.NotificationError(Resources.Resources.UserIsInActive);
    //    //        return false;
    //    //    }
    //    //    return true;
    //    //}
    //    //public int GetCurrentUserId()
    //    //{
    //    //    return _identity.GetintUserId();
    //    //}
    //    //public int GetCount()
    //    //{
    //    //    return _users.Count(row => row.IsSystemAccount == false && row.IsActive);
    //    //}
    //    //public IQueryable<User> GetAll()
    //    //{
    //    //    return _users.Where(p => p.IsSystemAccount == false && p.IsActive);
    //    //}
    //    //public IQueryable<User> GetSomeUsers(string name)
    //    //{
    //    //    return _users.Where(p => p.IsSystemAccount == false && p.UserName == name && p.IsActive);
    //    //}
    //    //public List<DropdownItemViewModelint> GetAllDropDown()
    //    //{
    //    //    return GetAll().Select(row => new DropdownItemViewModelint
    //    //    {
    //    //        Text = row.UserName
    //    //    ,
    //    //        Value = row.Id.ToString()
    //    //    }).ToList();
    //    //}

    //    //public List<CheckBox> GetAllCheckBox()
    //    //{
    //    //    return GetAll().Select(row => new CheckBox()
    //    //    {
    //    //        Name = row.UserName
    //    //    ,
    //    //        Id = row.Id.ToString()
    //    //    }).ToList();
    //    //}
    //    #endregion

    //    #region CRUD
    //    public int Add(RegisterViewModel registerViewModel)
    //    {
    //        var userModel = this.FindByName(registerViewModel.Email) ?? new User
    //        {
    //            Email = registerViewModel.Email,
    //            PasswordHash = registerViewModel.Password,
    //            UserName = registerViewModel.UserName
    //        };
    //        var result = this.Create(userModel, registerViewModel.Password);
    //        this.SetLockoutEnabled(userModel.Id, false);
    //        //this.GenerateEmailConfirmationTokenAsync(userModel.Id);
    //        //var callbackUrl = "www.Yahoo.Com";
    //        //this.SendEmailAsync(userModel.Id, "Confirm your account", "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
    //        return result.Succeeded ? userModel.Id : new int();
    //    }

    //    public UpdateStatus Update(EditUserVm editLoginVm)
    //    {
    //        var userModel = GetModel(editLoginVm.UserId);


    //        if (userModel == null) return UpdateStatus.UpdateFailed;
    //        userModel.Email = editLoginVm.Email;
    //        userModel.UserName = editLoginVm.UserName;
    //        userModel.PersonnelId = editLoginVm.PersonnelId;
    //        userModel.StartDate = editLoginVm.StartDate;
    //        userModel.ExpireDate = editLoginVm.ExpireDate;
    //        if (editLoginVm.Password != userModel.DecodePassword)
    //        {
    //            userModel.DecodePassword = SevenExtensionMethods.Decode(editLoginVm.Password);
    //            this.ChangePassword(editLoginVm.UserId, userModel.PasswordHash, editLoginVm.Password);
    //        }
    //        //if (userModel.DecodePassword != editLoginVm.DecodePassword)
    //        //{
    //        //    userModel.DecodePassword = editLoginVm.DecodePassword;
    //        //    this.ChangePassword(editLoginVm.UserId, userModel.PasswordHash, editLoginVm.Password);
    //        //}
    //        var result = this.Update(userModel);
    //        return result.Succeeded ? UpdateStatus.UpdateSuccefull : UpdateStatus.UpdateFailed;
    //    }

    //    public async Task<IdentityResult> AddRoleToUser(int userId, string RoleName)
    //    {
    //        var rolesForUser = this.GetRoles(userId);
    //        if (!rolesForUser.Contains(RoleName))
    //            return await AddToRoleAsync(userId, RoleName);
    //        else
    //            return IdentityResult.Failed();
    //    }

    //    //public AddStatus AddGroupToUser(int userId, int groupId)
    //    {
    //        throw new NotImplementedException();
    //    //var GroupsrolesForUser = this.GetRoles(userId);
    //    //if (!rolesForUser.Contains(RoleName))
    //    //    return await AddToRoleAsync(userId, RoleName);
    //    //else
    //    //    return IdentityResult.Failed();
    //}

    //#endregion

    //#region CreateUserManager

    // void CreateUserManager()
    //{

    //    // Configure validation logic for usernames
    //    UserValidator = new UserValidator<User, int>(this)
    //    {
    //        AllowOnlyAlphanumericUserNames = false,
    //        RequireUniqueEmail = true
    //    };

    //    // Configure validation logic for passwords
    //    PasswordValidator = new PasswordValidator
    //    {
    //        //RequiredLength = 6,
    //        RequireNonLetterOrDigit = false,
    //        RequireDigit = false,
    //        RequireLowercase = true,
    //        RequireUppercase = false,
    //    };

    //    // Configure user lockout defaults
    //    UserLockoutEnabledByDefault = true;
    //    DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
    //    MaxFailedAccessAttemptsBeforeLockout = 5;

    //    // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
    //    // You can write your own provider and plug in here.
    //    RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<User, int>
    //    {
    //        MessageFormat = "Your security code is: {0}"
    //    });

    //    RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<User, int>
    //    {
    //        Subject = "SecurityCode",
    //        BodyFormat = "Your security code is {0}"
    //    });

    //    EmailService = new EmailService();
    //    SmsService = new SmsService();


    //    var options = new IdentityFactoryOptions<UserManagerService>();
    //    var dataProtectionProvider = options.DataProtectionProvider;

    //    if (_dataProtectionProvider == null) return;
    //    var dataProtector = _dataProtectionProvider.Create("ASP.NET Identity");
    //    UserTokenProvider = new DataProtectorTokenProvider<User, int>(dataProtector);
    //}

    //#endregion

    //#region GenerateUserIdentityAsync

    // async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManagerService manager, User user)
    //{
    //    return await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
    //}

    //#endregion

    //#region OnValidateIdentity

    //public Func<CookieValidateIdentityContext, Task> OnValidateIdentity()
    //{
    //    return SecurityStampValidator.OnValidateIdentity<UserManagerService, User, int>(
    //                 validateInterval: TimeSpan.FromMinutes(30),
    //                 regenerateIdentityCallback: (manager, user) => GenerateUserIdentityAsync(manager, user),
    //                 getUserIdCallback: id => id.GetintUserId());
    //}

    //#endregion

    //#region Seed Database

    //public void SeedDatabase()
    //{
    //    const string name = "farhad@7soft.biz";
    //    const string password = "farhad123!";
    //    const string roleNameAdmin = "Admin";      //Admin
    //    const bool active = true;

    //    var userModel = this.FindByName(name);


    //    if (userModel == null)
    //    {
    //        userModel = new User { UserName = name, Email = name, PhoneNumber = "44641840" };
    //        this.Create(userModel, password);
    //        this.SetLockoutEnabled(userModel.Id, false);
    //    }

    //    var roleModel = _applicationRoleManagerService.FindRoleByName(roleNameAdmin);
    //    if (roleModel == null)
    //    {
    //        roleModel = new Role { Name = roleNameAdmin };
    //        _applicationRoleManagerService.Add(roleModel);
    //    }

    //    /*var roleModelForStudent = _applicationRoleManagerService.FindRoleByName(roleNameStudent);
    //    if (roleModelForStudent == null)
    //    {
    //        roleModelForStudent = new Role { Name = roleNameStudent, IsSystemRole = true };
    //        _applicationRoleManagerService.Add(roleModelForStudent);
    //    }*/

    //    var rolesForUser = this.GetRoles(userModel.Id);
    //    if (!rolesForUser.Contains(roleModel.Name))
    //        this.AddToRole(userModel.Id, roleModel.Name);

    //    #region Add Default attribute with Options


    //    #endregion

    //}

    //#endregion

    ////#region Custome Methods

    ////public async Task<User> GetCurrentUserAsync()
    ////{
    ////    return _user ?? (_user = await FindByIdAsync(GetCurrentUserId()));
    ////}
    ////public async Task<List<User>> GetAllUsersAsync()
    ////{
    ////    return await Users.ToListAsync();
    ////}
    ////public async Task<ClaimsIdentity> GenerateUserIdentityAsync(User user)
    ////{
    ////    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    ////    var userIdentity = await CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
    ////    // Add custom user claims here
    ////    return userIdentity;
    ////}
    ////public async Task<bool> HasPassword(int userId)
    ////{
    ////    var user = await FindByIdAsync(userId);
    ////    return user?.PasswordHash != null;
    ////}
    ////public async Task<bool> HasPhoneNumber(int userId)
    ////{
    ////    var user = await FindByIdAsync(userId);
    ////    return user?.PhoneNumber != null;
    ////}

    ////#endregion

    //#endregion
}
