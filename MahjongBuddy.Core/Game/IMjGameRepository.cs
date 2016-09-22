using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongBuddy.Game
{
    public interface IMjGameRepository : IRepository<MjGame, long>
    {
    }
}
