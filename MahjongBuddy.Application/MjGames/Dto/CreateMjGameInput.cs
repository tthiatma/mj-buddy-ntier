using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MahjongBuddy.Game;

namespace MahjongBuddy.MjGames.Dto
{
    [AutoMap(typeof(MjGame))]
    public class CreateMjGameInput : IInputDto
    {
        public bool IsPrivateGame { get; set; }
        public string GameRoomPassword { get; set; }
        public int MjRuleId { get; set; }
    }
}
