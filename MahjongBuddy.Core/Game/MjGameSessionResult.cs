using Abp.Domain.Entities;
using MahjongBuddy.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahjongBuddy.Game
{
    /// <summary>
    /// Accounting of the result of when the game is over 
    /// </summary>
    public class MjGameSessionResult: Entity<long>
    {
        public virtual User User { get; set; }
        public virtual int Point { get; set; }

        [ForeignKey("MjGameSessionId")]
        public virtual MjGameSession MjGameSession { get; set; }
        public virtual long? MjGameSessionId { get; set; }

        public MjGamePlayerResultState PlayerResultState { get; set; }
    }

    
}
