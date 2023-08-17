using DEP.Repository.Context;
using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DEP.Repository.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseContext context;
        public BookRepository(DatabaseContext context) { this.context = context; }

        public async Task<Book> AddBook(Book book)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> DeleteBook(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.BookId == id);

            if (book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }

            return book;
        }

        public async Task<Book> GetBook(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.BookId == id);
            return book;
        }

        public async Task<List<Book>> GetBooks()
        {
            var books = await context.Books.ToListAsync();
            return books;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return book;
        }
    }
}
