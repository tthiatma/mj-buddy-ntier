using Abp.Domain.Entities;
using MahjongBuddy.Tiles;
using MahjongBuddy.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahjongBuddy.Game
{
    /// <summary>
    /// Whole mj game consists of 16 sessions going through each players 4 east, 4 south, 4 west, and 4 north
    /// </summary>
    public class MjGameSession : Entity<long>
    {
        /// <summary>
        /// reference which room this session belongs to
        /// </summary>
        [ForeignKey("MjGameId")]
        public virtual MjGame MJGame { get; set; }

        public virtual long? MjGameId { get; set; }

        /// <summary>
        /// collection of all tiles in the game
        /// </summary>
        public ICollection<MjTileInGame> Tiles { get; set; }

        /// <summary>
        /// Represents current wind of the game
        /// </summary>
        public virtual string Wind { get; set; }

        /// <summary>
        /// Represents 1st , 2nd, ...16th game
        /// </summary>
        public virtual string GameNo{ get; set; }

        /// <summary>
        /// There could be more than one winner in a game
        /// </summary>
        public virtual ICollection<User> Winners { get; set; }

        /// <summary>
        /// List of losers/feeders when winner declared
        /// </summary>
        public virtual ICollection<User> Losers { get; set; }

        /// <summary>
        /// Track which tile that player throw to board after their turn end
        /// </summary>
        public virtual MjTileInGame LastTileOnBoard { get; set; }

        /// <summary>
        /// indicate if there is a winner in this session
        /// </summary>
        public virtual bool HasWinner { get; set; }

    }
}
