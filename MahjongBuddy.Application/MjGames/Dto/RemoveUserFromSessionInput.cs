using MahjongBuddy.Users;

namespace MahjongBuddy.MjGames.Dto
{
    public class RemoveUserFromSessionInput
    {
        public long GameSessionId { get; set; }
        public User User { get; set; }
    }
}
