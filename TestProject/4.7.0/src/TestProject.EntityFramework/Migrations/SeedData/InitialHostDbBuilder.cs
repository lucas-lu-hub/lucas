using TestProject.EntityFramework;
using EntityFramework.DynamicFilters;

namespace TestProject.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly TestProjectDbContext _context;

        public InitialHostDbBuilder(TestProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
