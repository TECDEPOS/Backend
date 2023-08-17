using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetBook(int id);
        Task<List<Book>> GetBooks();
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<Book> DeleteBook(int id);
    }
}
