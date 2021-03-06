using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBooks.ActionResults;
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
        private readonly ILogger<PublishersController> _logger;

        public PublishersController(PublishersService publishersService, ILogger<PublishersController> logger)
        {
            this._publishersService = publishersService;
            this._logger = logger;
        }

        [HttpGet]
        //[Route("GetAllPublishers/{sortBy?}")]
        [Route("GetAllPublishers")]
        public IActionResult GetAllPublishers(string sortBy, string searchString, int pageNumber)
        {
            //throw new Exception("Test Custom Exception GetAllPublishers");
            try
            {
                _logger.LogInformation("Log GetAllPublishers Get Action method");
                var publishers = _publishersService.GetAllPublishers(sortBy, searchString, pageNumber);
                return Ok(publishers);
            }
            catch (Exception ex)
            {
                return BadRequest("Could not load the publishers");
            }
        }

        [HttpPost]
        public IActionResult AddPublisher([FromBody] PublisherVM publisherVM)
        {
            _publishersService.AddPublisher(publisherVM);
            return Ok();
        }

        [HttpGet]
        [Route("GetPublisherData/{publisherId}")]
        public IActionResult GetPublisherData(int publisherId)
        {
            var publisherData = _publishersService.GetPublisherData(publisherId);
            return Ok(publisherData);
        }

        [HttpGet]
        [Route("GetPublisherById/{publisherId}")]
        //public IActionResult GetPublisherById(int publisherId)
        public CustomActionResult GetPublisherById(int publisherId)
        {
            var publisher = _publishersService.GetPublisherById(publisherId);
            if(publisher != null)
            {
                //return Ok(publisher);
                var _response = new CustomActionResultVM()
                {
                    Publisher = publisher
                };

                return new CustomActionResult(_response);
            }
            else
            {
                //return NotFound();
                return new CustomActionResult(new CustomActionResultVM()
                {
                    Exception = new Exception("No Data Found for Publsiher")
                });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _publishersService.DeletePublisherById(id);
            return Ok();
        }
    }
}
