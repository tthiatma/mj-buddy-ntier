using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MahjongBuddy.Game;

namespace MahjongBuddy.MjGames.Dto
{
    [AutoMap(typeof(MjGame))]
    public class CreateMjGameInput
    {
        public bool IsPrivateGame { get; set; }
        public string RoomPassword { get; set; }
        public int MjRuleId { get; set; }
    }
}
