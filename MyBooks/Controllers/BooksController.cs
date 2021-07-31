using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.Services;
using MyBooks.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetBookById(int Id)
        {
            var book = _booksService.GetBookById(Id);
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult UpdateBookById(int Id, [FromBody]BookVM bookVM)
        {
            var book = _booksService.UpdateBookById(Id, bookVM);
            return Ok(book);
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteBookById(int Id)
        {
            _booksService.DeleteByBookId(Id);
            return Ok();
        }
    }
}
