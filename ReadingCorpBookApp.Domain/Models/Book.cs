using ReadingCorpBookApp.Domain.Enums;

namespace ReadingCorpBookApp.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Author Author { get; set; }
        public DateTime RegistrationTimeStamp { get; set; }
        public Category Category { get; set; }
        public string? Description { get; set; }
    }
}
