namespace ReadingCorpBookApp.Client.DtoModel
{
    public class BookDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public AuthorDto Author { get; set; }
        public DateTime RegistrationTimeStamp { get; set; }
        public CategoryDto Category { get; set; }
        public string? Description { get; set; }
    }
}
