using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Data.ViewModels
{
    public class AuthorVM
    {
        public string AuthorName { get; set; }
    }

    public class AuthorWithBooksVM
    {
        public string AuthorName { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
