using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using NLog;
using GZIT.GZTimeTracker.API.Core;

namespace GZTimeTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : GZControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;        

        public TestController(IUnitOfWork unitOfWork, ILogger<TestController> logger)
        {
            _unitOfWork = unitOfWork;            
        }

        // GET: api/Test
        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {     
            _logger.Error("Ja jsem z text z loggeru");
            try
            {                
                var persons = await _unitOfWork.ProjectRepository.GetAll();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                
                return StatusCode(500, "Internal server error");
            }
        }        
    }
}
