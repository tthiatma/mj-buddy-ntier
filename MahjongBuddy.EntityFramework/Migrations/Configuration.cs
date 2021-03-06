using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using MahjongBuddy.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace MahjongBuddy.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MahjongBuddy.EntityFramework.MahjongBuddyDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MahjongBuddy";
        }

        protected override void Seed(MahjongBuddy.EntityFramework.MahjongBuddyDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            new DefaultMjGamesCreator(context).Create();

            context.SaveChanges();
        }
    }
}
