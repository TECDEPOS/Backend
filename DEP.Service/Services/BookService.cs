using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;

namespace DEP.Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository repo;
        public BookService(IBookRepository repo) {  this.repo = repo; }

        public async Task<bool> AddBook(Book book)
        {
            return await repo.AddBook(book);
        }

        public async Task<Book> DeleteBook(int id)
        {
            return await repo.DeleteBook(id);
        }

        public async Task<Book> GetBook(int id)
        {
            return await repo.GetBook(id);
        }

        public async Task<List<Book>> GetBooks()
        {
            return await repo.GetBooks();
        }

        public async Task<Book> UpdateBook(Book book)
        {
            return await repo.UpdateBook(book);
        }
    }
}
