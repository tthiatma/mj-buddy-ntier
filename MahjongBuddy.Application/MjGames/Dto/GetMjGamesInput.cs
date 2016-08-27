using Abp.Application.Services.Dto;

namespace MahjongBuddy.MjGames.Dto
{
    public class GetMjGamesInput : IInputDto
    {
        public int Count { get; set; }
    }
}
