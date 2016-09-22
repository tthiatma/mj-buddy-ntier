using Abp.EntityFramework;
using MahjongBuddy.Game;
using System.Data.Entity;
using System.Linq;

namespace MahjongBuddy.EntityFramework.Repositories
{
    public class MjGameSessionRepository : MahjongBuddyRepositoryBase<MjGameSession, long>, IMjGameSessionRepository
    {
        public MjGameSessionRepository(IDbContextProvider<MahjongBuddyDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public IQueryable<MjGameSession> GetAllWithUsers()
        {
            var query = GetAll().Include(g => g.Users);
            return query;
        }
    }
}
