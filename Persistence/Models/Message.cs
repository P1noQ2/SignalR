using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistence.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        public string FromUser { get; set; }

        [Required]
        [DefaultValue("oblak")]
        public string To { get; set; }

        [Required]
        [MaxLength(300)]
        public string Text { get; set; }

        public DateTimeOffset SendAt { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
