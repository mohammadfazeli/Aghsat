using Microsoft.AspNet.Identity.EntityFramework;

namespace Aghsat.Domain
{
    public class Role : IdentityRole<int, UserRole>
    {
        public Role() { }
        public Role(string name) { Name = name; }
    }
}
