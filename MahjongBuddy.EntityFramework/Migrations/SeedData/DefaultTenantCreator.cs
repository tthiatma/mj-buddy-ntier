using System.Linq;
using MahjongBuddy.EntityFramework;
using MahjongBuddy.MultiTenancy;

namespace MahjongBuddy.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly MahjongBuddyDbContext _context;

        public DefaultTenantCreator(MahjongBuddyDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
