using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MahjongBuddy.Game;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahjongBuddy.Tiles
{
    public class MjTileInGame : Entity<long>, IHasCreationTime
    {
        [ForeignKey("TileId")]
        public virtual MjTile Tile { get; set; }

        public virtual int? TileId { get; set; }

        /// <summary>
        /// represents which game session this tile in game belongs to
        /// </summary>
        [ForeignKey("MjGameSessionId")]
        public virtual MjGameSession MjGameSession { get; set; }

        public virtual long MjGameSessionId { get; set; }

        public virtual MjTileInGameState State { get; set; }

        public virtual int? OwnerId { get; set; }

        /// <summary>
        /// num to display the order of tile depending on when the user get the tile 
        /// </summary>
        public virtual int OrderNum { get; set; }

        /// <summary>
        /// primary use is to sort the tile based on how user want to display their tile
        /// </summary>
        public virtual int UserOrderNum { get; set; }

        /// <summary>
        /// The time when this tile in game is created.
        /// </summary>
        public virtual DateTime CreationTime { get; set; }

        public MjTileInGame()
        {
            CreationTime = DateTime.Now;
        }
    }
}
