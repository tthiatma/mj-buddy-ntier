using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MahjongBuddy.MjGames.Dto;
using System.Threading.Tasks;

namespace MahjongBuddy.Games
{
    public interface IMjGameAppService : IApplicationService
    {
        void CreateMjGame(CreateMjGameInput input);
        void JoinMjGame(JoinMjGameInput input);
        GetMjGamesOutput GetMjGames(GetMjGamesInput input);
    }
}
