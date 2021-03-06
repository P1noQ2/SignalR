﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Messages = new HashSet<Message>();
        }
        public bool ChatStatus { get; set; }
        
        [NotMapped]
        public string ConnectionId { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
