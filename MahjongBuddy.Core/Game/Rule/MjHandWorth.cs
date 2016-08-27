using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahjongBuddy.Game.Rule
{
    /// <summary>
    /// list out all the possible winning types in mahjong depending on the rule
    /// </summary>
    public class MjHandWorth : Entity
    {
        [ForeignKey("MjRuleId")]
        public virtual MjRule  MjRule{ get; set; }

        public virtual int? MjRuleId { get; set; }

        public MjWinningType MjWinningType { get; set; }

        public int Point { get; set; }
    }
}
