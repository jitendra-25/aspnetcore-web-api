using MyBooks.Data.Models;
using MyBooks.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Data.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext _context;

        public AuthorsService(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public void AddAuthor(AuthorVM authorVM)
        {
            var author = new Author()
            {
                AuthorName = authorVM.AuthorName
            };

            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public List<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return _context.Authors.FirstOrDefault(a => a.Id == id);
        }
    }
}
