using MyBooks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Data.Services
{
    public class LogsService
    {
        private readonly AppDbContext _appDbContext;

        public LogsService(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public List<Log> GetAllLogsFromDB()
        {
            return _appDbContext.Logs.ToList();
        }
    }
}
