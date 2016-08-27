using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using MahjongBuddy.EntityFramework;

namespace MahjongBuddy.Migrator
{
    [DependsOn(typeof(MahjongBuddyDataModule))]
    public class MahjongBuddyMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<MahjongBuddyDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}