using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using TestProject.EntityFramework;

namespace TestProject.Migrator
{
    [DependsOn(typeof(TestProjectDataModule))]
    public class TestProjectMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<TestProjectDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}