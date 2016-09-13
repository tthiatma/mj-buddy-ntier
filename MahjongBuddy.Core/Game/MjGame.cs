using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MahjongBuddy.Game.Rule;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using MahjongBuddy.Users;

namespace MahjongBuddy.Game
{
    /// <summary>
    /// Player can create game(room) so that other player can join the game
    /// </summary>
    public class MjGame : Entity<long>, IHasCreationTime
    {
        [ForeignKey("CreatorId")]
        public virtual User Creator { get; set; }
        public virtual long? CreatorId { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual bool IsPrivateGame { get; set; }

        public virtual string GameRoomPassword { get; set; }

        [ForeignKey("MjRuleId")]
        public virtual MjRule MjRule { get; set; }

        public virtual int? MjRuleId { get; set; }

        public DateTime CreationTime { get; set; }

        public virtual long? ActiveSessionId { get; set; }

        /// <summary>
        /// List of status of game
        /// </summary>
        public virtual MjGameState State { get; set; }        

        public MjGame()
        {
            CreationTime = DateTime.Now;
        }
    }
}
