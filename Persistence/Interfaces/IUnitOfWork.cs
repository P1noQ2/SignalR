using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMessageRepository Messages { get; set; }
        IApplicationUserRepository ApplicationUsers { get; set; }
        Task<int> Complete();
    }
}
