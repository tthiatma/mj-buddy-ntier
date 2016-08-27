using Abp.Domain.Entities;
using MahjongBuddy.Game;
using MahjongBuddy.Game.Rule;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahjongBuddy.Tiles
{
    /// <summary>
    /// collect all tile sets and calculate total points worth for that set
    /// HK rule will be 3(set) - 3(set) -3(set) - 2(eye set) tiles combo to win
    /// </summary>
    public class MjWinningTileSet : Entity
    {
        /// <summary>
        /// represents which game session this tile in game belongs to
        /// </summary>
        [ForeignKey("MjGameSessionId")]
        public virtual MjGameSession MjGameSession { get; set; }

        public virtual long MjGameSessionId { get; set; }

        public virtual MjTileSet Eye { get; set; }
        public virtual ICollection<MjTileSet> Sets { get; set; }
        public virtual ICollection<MjTileInGame> Flowers { get; set; }
        public virtual ICollection<MjHandWorth> HandsWorth { get; set; }
        public virtual int TotalPoints { get; set; }
    }
}
