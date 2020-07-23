using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Context
{
    public class SignalRContext : DbContext
    {
        public SignalRContext(DbContextOptions<SignalRContext> options)
            :base(options)
        {

        }
        public DbSet<ApplicationUser> applicationUser { get; set; }
        public DbSet<Message> Message { get; set; }
    }
}
