using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public class Homework
    {
        private const int MaxContentLength = 40;
        
        [Key]
        public int Id { get; set; }

        [MaxLength(MaxContentLength)]
        [Required]
        public string Content { get; set; }

        public DateTime TimeSent { get; set; }
    }
}
