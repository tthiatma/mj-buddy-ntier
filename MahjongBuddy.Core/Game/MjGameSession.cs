using Abp.Domain.Entities;
using MahjongBuddy.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahjongBuddy.Game
{
    /// <summary>
    /// Whole mj game consists of 16 sessions going through each players 4 east, 4 south, 4 west, and 4 north
    /// MjGameSession track current game no and the wind of this session.
    /// </summary>
    public class MjGameSession : Entity<long>
    {
        /// <summary>
        /// reference which room this session belongs to
        /// </summary>
        [ForeignKey("MjGameId")]
        public virtual MjGame MJGame { get; set; }
        public virtual long? MjGameId { get; set; }

        public virtual ICollection<User> Users { get; set; }

        /// <summary>
        /// Represents current wind of the game
        /// </summary>
        public virtual MjGameWind Wind { get; set; }

        /// <summary>
        /// Represents 1st , 2nd, ...16th game
        /// </summary>
        public virtual int GameNo{ get; set; }

    }
}
