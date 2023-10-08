namespace ReadingCorpBookApp.Service.Infrastructure.Contract
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetBooks();
        Task<T> CreateBook(T entity);
        Task SaveChangestoDatabase();
        T UpdateBook(int id, T entity);
    }
}
