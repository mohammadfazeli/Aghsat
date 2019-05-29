using Aghsat.Domain;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aghsat.ServiceLayer.Interface
{
    //public interface IApplicationRoleManagerService : IDisposable
    //{
    //    #region Properties

    //    IIdentityValidator<Role> RoleValidator { get; set; }
    //    #endregion

    //    #region Get & GetAll

    //    Role GetModel(int code);
    //    Role FindRoleByName(string roleName);
    //    int GetCount();

    //    #endregion

    //    #region CUD

    //    IdentityResult Add(Role role);
    //    #endregion
    //}
    public interface IApplicationRoleManagerService : IDisposable
    {
        /// <summary>
        /// Used to validate roles before persisting changes
        /// </summary>
        IIdentityValidator<Role> RoleValidator { get; set; }

        /// <summary>
        /// Create a role
        /// </summary>
        /// <param name="role"/>
        /// <returns/>
        Task<IdentityResult> CreateAsync(Role role);

        /// <summary>
        /// Update an existing role
        /// </summary>
        /// <param name="role"/>
        /// <returns/>
        Task<IdentityResult> UpdateAsync(Role role);

        /// <summary>
        /// Delete a role
        /// </summary>
        /// <param name="role"/>
        /// <returns/>
        Task<IdentityResult> DeleteAsync(Role role);

        /// <summary>
        /// Returns true if the role exists
        /// </summary>
        /// <param name="roleName"/>
        /// <returns/>
        Task<bool> RoleExistsAsync(string roleName);

        /// <summary>
        /// Find a role by id
        /// </summary>
        /// <param name="roleId"/>
        /// <returns/>
        Task<Role> FindByIdAsync(int roleId);

        /// <summary>
        /// Find a role by name
        /// </summary>
        /// <param name="roleName"/>
        /// <returns/>
        Task<Role> FindByNameAsync(string roleName);


        // Our new custom methods

        Role FindRoleByName(string roleName);
        IdentityResult CreateRole(Role role);
        IList<Role> GetCustomUsersInRole(string roleName);
        IList<User> GetusersInRole(string roleName);
        IList<Role> FindUserRoles(int userId);
        string[] GetRolesForUser(int userId);
        bool IsUserInRole(int userId, string roleName);
        Task<List<Role>> GetAllRolesAsync();
    }
}
