using Persistence.Context;
using Persistence.Interfaces;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SignalRContext Context;
        public UnitOfWork(SignalRContext context)
        {
            Context = context;
            Messages = new MessageRepository(Context);
            ApplicationUsers = new ApplicationUserRepository(Context);
        }
        public IMessageRepository Messages { get; set; }
        public IApplicationUserRepository ApplicationUsers { get; set; }

        public int complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
