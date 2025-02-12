using DEP.Repository.Models;

namespace DEP.Service.Interfaces
{
    public interface IBookService
    {
        Task<Book> GetBook(int id);
        Task<List<Book>> GetBooks();
        Task<bool> AddBook(Book book);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);
    }
}
