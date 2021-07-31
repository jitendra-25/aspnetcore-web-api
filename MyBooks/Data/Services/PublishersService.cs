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
    }
}
