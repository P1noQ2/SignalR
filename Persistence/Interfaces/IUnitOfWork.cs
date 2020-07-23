using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMessageRepository Messages { get; set; }
        IApplicationUserRepository ApplicationUsers { get; set; }
        int complete();
    }
}
