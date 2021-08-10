using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly LogsService _logsService;

        public LogsController(LogsService logsService)
        {
            this._logsService = logsService;
        }

        [HttpGet("get-all-logs")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_logsService.GetAllLogsFromDB());
            }
            catch (Exception ex)
            {
                return BadRequest("Could not load logs from DB");
            }
        }
    }
}
