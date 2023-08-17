using DEP.Repository.Models;

namespace DEP.Service.Interfaces
{
    public interface IBookService
    {
        Task<Book> GetBook(int id);
        Task<List<Book>> GetBooks();
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<Book> DeleteBook(int id);
    }
}
