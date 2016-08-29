using System.Collections.Generic;

namespace MahjongBuddy.MjGames.Dto
{
    public class GetMjGamesOutput
    {
        public IEnumerable<MjGameDto> Items{ get; set; }
    }
}
