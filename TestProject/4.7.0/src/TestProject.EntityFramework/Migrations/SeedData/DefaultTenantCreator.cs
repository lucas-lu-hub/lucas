using System.Linq;
using TestProject.EntityFramework;
using TestProject.MultiTenancy;

namespace TestProject.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly TestProjectDbContext _context;

        public DefaultTenantCreator(TestProjectDbContext context)
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
