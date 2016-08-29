using Abp.EntityFramework;
using MahjongBuddy.Game;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongBuddy.EntityFramework.Repositories
{
    public class MjGameRepository : MahjongBuddyRepositoryBase<MjGame, long>, IMjGameRepository
    {
        public MjGameRepository(IDbContextProvider<MahjongBuddyDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public IQueryable<MjGame> GetAllWithUsers()
        {
            var query = GetAll().Include(g => g.Users);
            return query;
        }
    }
}
