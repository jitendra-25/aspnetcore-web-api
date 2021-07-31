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
    public class PublishersController : ControllerBase
    {

        private readonly PublishersService _publishersService;

        public PublishersController(PublishersService publishersService)
        {
            this._publishersService = publishersService;
        }

        [HttpPost]
        public IActionResult AddPublisher([FromBody] PublisherVM publisherVM)
        {
            _publishersService.AddPublisher(publisherVM);
            return Ok();
        }
    }
}
