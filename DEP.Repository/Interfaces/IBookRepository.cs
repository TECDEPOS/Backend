using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetBook(int id);
        Task<List<Book>> GetBooks();
        Task<bool> AddBook(Book book);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);
    }
}
