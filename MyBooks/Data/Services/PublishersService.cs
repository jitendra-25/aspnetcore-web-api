using MyBooks.Data.Models;
using MyBooks.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Data.Services
{
    public class PublishersService
    {
        private readonly AppDbContext _context;

        public PublishersService(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public void AddPublisher(PublisherVM publisherVM)
        {
            var publisher = new Publisher()
            {
                Name = publisherVM.Name
            };

            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var publisherData = _context.Publishers.Where(n => n.Id == publisherId).Select(n => new PublisherWithBooksAndAuthorsVM()
            {
                Name = n.Name,
                BookAuthors = n.Books.Select(b => new BookAuthorVM()
                {
                    BookName = b.Title,
                    BookAuthors = b.Book_Authors.Select(a => a.Author.AuthorName).ToList()
                }).ToList()
            }).FirstOrDefault();

            return publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var publisher = _context.Publishers.Where(p => p.Id == id).FirstOrDefault();
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
        }
    }
}
