using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MahjongBuddy.Game;

namespace MahjongBuddy.MjGames.Dto
{
    [AutoMapFrom(typeof(MjGame))]
    public class MjGameDto : EntityDto
    {
        public MjGameState State { get; set; }
        public int MjRuleId { get; set; }
        public int TotalPlayers { get; set; }
        public bool IsPrivateGame { get; set; }
    }
}
