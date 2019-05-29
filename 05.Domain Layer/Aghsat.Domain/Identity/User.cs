using Microsoft.AspNet.Identity.EntityFramework;

namespace Aghsat.Domain
{
   public class User  : IdentityUser<int,UserLogin,UserRole,UserClaim>
    {
    }
}
