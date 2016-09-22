using Abp.Domain.Repositories;
using System.Linq;

namespace MahjongBuddy.Game
{
    public interface IMjGameSessionRepository: IRepository<MjGameSession, long>
    {
        IQueryable<MjGameSession> GetAllWithUsers();
    }
}
