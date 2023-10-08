using ReadingCorpBookApp.Client.DtoModel;
using System.Net.Http.Headers;
using System.Net.Http.Json;

class Program
{
    static void Main(string[] args)
    {
        //GetBooks();
        CreateBook();
        //UpdateBook();
    }
    
    /// <summary>
    /// Get All Books
    /// </summary>
    private async static void GetBooks()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7106/");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        HttpResponseMessage response = client.GetAsync("api/book").Result;  
        if (response.IsSuccessStatusCode)
        {
            var allBooks = await response.Content.ReadFromJsonAsync<IEnumerable<BookDto>>();
            if (allBooks != null & allBooks.Count() > 0)
            {
                foreach (var item in allBooks)
                {
                    Console.WriteLine($" Name: {item.Name}, Author: {item.Author.Name}, " +
                        $"Category: {item.Category} , Description: {item.Description}");
                }
            }
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
        Console.ReadLine();
    }

    /// <summary>
    /// Create New Book in Database
    /// </summary>
    private static void CreateBook()
    {
        using (var client = new HttpClient())
        {
            BookDto book = new BookDto
            {
                Name = "Steve Jobs",
                Author = new AuthorDto { Name = "Waater Isaacson" },
                RegistrationTimeStamp = DateTime.Now,
                Category = CategoryDto.Biography,
                Description = "Biography Book",
            };
            client.BaseAddress = new Uri("https://localhost:7106/");
            var response = client.PostAsJsonAsync("api/book/", book).Result;
            if (response.IsSuccessStatusCode)
            {
                GetBooks();
            }
            else
            {
                Console.WriteLine("Error occured!");
            }
        }

    }

    /// <summary>
    /// Update Existing book in Database
    /// </summary>
    private static void UpdateBook()
    {
        using (var client = new HttpClient())
        {
            BookDto book = new BookDto
            {
                Id = 6,
                Name = "Steve Jobs",
                Author = new AuthorDto { Name = "Waater Isaacson" },
                RegistrationTimeStamp = DateTime.Now,
                Category = CategoryDto.Biography,
                Description = "Biography Book",
            };
            client.BaseAddress = new Uri("https://localhost:7106/");
            var response = client.PutAsJsonAsync("api/book/" + book.Id + "/", book).Result;
            if (response.IsSuccessStatusCode)
            {
                GetBooks();
            }
            else
            {
                Console.WriteLine("Error occured!");
            }
        }

    }
}