using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.DB.Contexts;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Entities
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationIdentityDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }

        //private DbSet<ApplicationUser> UserSet
        //{
        //    get
        //    {
        //        return Context.Set<ApplicationUser>();
        //    }
        //}

        //public override IQueryable<ApplicationUser> Users
        //{
        //    get
        //    {
        //        return UserSet.Include(u => u.User).ThenInclude(d => d.Doctor);
        //    }
        //}
    }
}
