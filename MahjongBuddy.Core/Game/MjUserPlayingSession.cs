using Abp.Domain.Entities;
using MahjongBuddy.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahjongBuddy.Game
{
    /// <summary>
    /// player state when in a game session
    /// </summary>
    public class MjUserPlayingSession : Entity<long>
    {
        public virtual bool CanPickTile { get; set; }

        public virtual bool CanThrowTile { get; set; }

        public virtual bool CanDoNoFlower { get; set; }

        public virtual string Wind { get; set; }

        [ForeignKey("MjGameSessionId")]
        public virtual MjGameSession MjGameSession { get; set; }

        public virtual long? MjGameSessionId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual long? UserId { get; set; }

        public virtual bool AutoSortTile { get; set; }

    }
}
