using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sensores.Radix.Domain.Core.Interfaces.Repositories
{
    public interface IUnityOfWork
    {
        Task<bool> Commit();
        Task<bool> RollBack();
    }
}
