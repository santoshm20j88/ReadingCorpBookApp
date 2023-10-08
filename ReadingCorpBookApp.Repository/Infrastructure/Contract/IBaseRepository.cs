using Microsoft.AspNetCore.Mvc;

namespace ReadingCorpBookApp.Repository.Infrastructure.Contract
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();

        Task<IActionResult> Create(T obj);
    }
}
