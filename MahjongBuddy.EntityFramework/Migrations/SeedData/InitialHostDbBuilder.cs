using MahjongBuddy.EntityFramework;
using EntityFramework.DynamicFilters;

namespace MahjongBuddy.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly MahjongBuddyDbContext _context;

        public InitialHostDbBuilder(MahjongBuddyDbContext context)
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
