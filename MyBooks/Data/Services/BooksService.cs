using MyBooks.Data.Models;
using MyBooks.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public BookWithAuthorsVM GetBookById(int id)
        {
            var bookWithAuthorsVM = _context.Books.Where(n => n.Id == id).Select(book => new BookWithAuthorsVM()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Author.AuthorName).ToList()
            }).FirstOrDefault();

            return bookWithAuthorsVM;
        }

        public void AddBookWithAuthors(BookVM bookVM)
        {
            var book = new Book()
            {
                Title = bookVM.Title,
                Description = bookVM.Description,
                IsRead = bookVM.IsRead,
                DateRead = bookVM.IsRead ? bookVM.DateRead.Value : null,
                Rate = bookVM.IsRead ? bookVM.Rate.Value : null,
                Genre = bookVM.Genre,
                CoverUrl = bookVM.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = bookVM.PublisherId
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            foreach (var id in bookVM.AuthorIds)
            {
                var book_author = new Book_Author()
                {
                    BookId = book.Id,
                    AuthorId = id
                };

                _context.Book_Authors.Add(book_author);
                _context.SaveChanges();
            }
        }

        public Book UpdateBookById(int id, BookVM bookVM)
        {
            var book = _context.Books.FirstOrDefault(i => i.Id == id);
            if(book != null)
            {
                book.Title = bookVM.Title;
                book.Description = bookVM.Description;
                book.IsRead = bookVM.IsRead;
                book.DateRead = bookVM.IsRead ? bookVM.DateRead.Value : null;
                book.Rate = bookVM.IsRead ? bookVM.Rate.Value : null;
                book.Genre = bookVM.Genre;
                book.CoverUrl = bookVM.CoverUrl;
                book.DateAdded = DateTime.Now;

                _context.SaveChanges();
            }

            return book;
        }

        public void DeleteByBookId(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
