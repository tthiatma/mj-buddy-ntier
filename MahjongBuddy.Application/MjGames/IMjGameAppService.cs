using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MahjongBuddy.Game;
using MahjongBuddy.MjGames.Dto;
using System.Threading.Tasks;

namespace MahjongBuddy.Games
{
    public interface IMjGameAppService : IApplicationService
    {
        MjGame CreateMjGame(CreateMjGameInput input);
        MjGameSession CreateMjGameSession(CreateMjGameSessionInput input);
        void UpdateMjGame(MjGame input);
        GetMjGamesOutput GetMjGames(GetMjGamesInput input);
        void AddUserToSession(AddUserToSessionInput input);
        void RemoveUserFromSession(RemoveUserFromSessionInput input);
    }
}
