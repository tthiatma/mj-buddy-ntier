using Abp.AutoMapper;
using MahjongBuddy.Game;
using MahjongBuddy.Users;
using System.Collections.Generic;

namespace MahjongBuddy.MjGames.Dto
{
    [AutoMap(typeof(MjGameSession))]
    public class CreateMjGameSessionInput
    {
        public long MjGameId { get; set; }
        public ICollection<User> Users { get; set; }
        public MjGameWind Wind { get; set; }
        public int GameNo { get; set; }

        public CreateMjGameSessionInput()
        {
            Users = new List<User>();
        }
    }
}
