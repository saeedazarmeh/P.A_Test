using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A_Contract.InfraStucture
{
    public interface UnitOfWork
    {
        Task Begin();
        Task Complete();
        Task Commit();
        Task RollBack();
    }
}
