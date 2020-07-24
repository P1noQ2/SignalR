using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Persistence.Context
{
    public class SignalRContext : IdentityDbContext<ApplicationUser>
    {
        public SignalRContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Message> Message { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Message>()
                .HasOne<ApplicationUser>(a => a.ApplicationUser)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.UserId);
        }
    }
}
