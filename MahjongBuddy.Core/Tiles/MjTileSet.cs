using Abp.Domain.Entities;
using System.Collections.Generic;

namespace MahjongBuddy.Tiles
{
    /// <summary>
    /// collection of 3 tiles(Chow/Pong) or 2 for eye
    /// </summary>
    public class MjTileSet : Entity
    {
        public virtual ICollection<MjTileInGame> Tiles{ get; set; }
        public virtual MjTileSetType TileSetType { get; set; }
        public virtual MjTileType TileType { get; set; }
        public virtual bool IsRevealed { get; set; }
    }
}
