using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongBuddy.Connection
{
    /// <summary>
    /// Signal R connection
    /// use this to map to user
    /// </summary>
    public class MjSignalRConnection : Entity<long>, IHasCreationTime
    {
        public virtual string ConnectionId { get; set; }
        public virtual string UserAgent { get; set; }
        public virtual bool Connected { get; set; }

        public DateTime CreationTime { get; set; }

        public MjSignalRConnection()
        {
            CreationTime = DateTime.Now;
        }
    }
}
