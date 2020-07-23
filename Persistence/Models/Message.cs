using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistence.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        public string FromUserId { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        [MaxLength(300)]
        public string Text { get; set; }

        public DateTimeOffset SendAt { get; set; }
    }
}
