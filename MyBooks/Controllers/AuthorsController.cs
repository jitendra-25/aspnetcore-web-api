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
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            this._authorsService = authorsService;
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorVM AuthorVM)
        {
            _authorsService.AddAuthor(AuthorVM);
            return Ok();
        }
    }
}
