using Abp.AutoMapper;
using MahjongBuddy.Game;

namespace MahjongBuddy.MjGames.Dto
{
    [AutoMapFrom(typeof(MjGameSession))]
    public class MjGameSessionDto
    {
        public int TotalPlayers { get; set; }
    }
}
