using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GZIT.GZTimeTracker.API.Core;
using GZIT.GZTimeTracker.Core.Infrastructure;

namespace GZTimeTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : GZControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;        

        public TestController(IUnitOfWork unitOfWork)
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
