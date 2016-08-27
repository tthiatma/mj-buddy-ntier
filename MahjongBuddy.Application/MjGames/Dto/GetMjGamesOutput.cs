using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace MahjongBuddy.MjGames.Dto
{
    public class GetMjGamesOutput : IOutputDto
    {
        public IEnumerable<MjGameDto> Games{ get; set; }
    }
}
