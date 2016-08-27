using Abp.Domain.Entities;

namespace MahjongBuddy.Tiles
{
    /// <summary>
    /// collections of all tiles in mahjong
    /// </summary>
    public class MjTile : Entity
    {
        public virtual string Name { get; set; }
        public virtual MjTileType TileType { get; set; }
        public virtual MjTileValue Value { get; set; }
        public virtual string ImageMedPath { get; set; }
        public virtual string ImageSmPath { get; set; }
    }
}
