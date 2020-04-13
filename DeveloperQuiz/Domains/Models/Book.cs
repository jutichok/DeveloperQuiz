using System;
using System.ComponentModel.DataAnnotations;

namespace DeveloperQuiz.Domains.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDateUtc { get; set; }
    }
}
