using Abp.Domain.Entities;

namespace MahjongBuddy.Game.Rule
{
    /// <summary>
    /// list of rule in mahjong, initially implement Hongkong mahjong rule
    /// </summary>
    public class MjRule : Entity
    {
        public virtual string Name{ get; set; }

        public virtual string Description { get; set; }
    }
}
