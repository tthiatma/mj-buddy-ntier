using Abp.Application.Services;
using MahjongBuddy.MjGames.Dto;

namespace MahjongBuddy.Games
{
    public interface IMjGameAppService : IApplicationService
    {
        void CreateMjGame(CreateMjGameInput input);
        void JoinMjGame(JoinMjGameInput input);
        GetMjGamesOutput GetMjGames(GetMjGamesInput input);
    }
}
