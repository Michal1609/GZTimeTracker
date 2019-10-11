using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GZIT.GZTimeTracker.Core.Infrastructure;
using GZIT.GZTimeTracker.Infrastructure.Data;

namespace GZTimeTracker.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
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
            try
            {
                var persons = await _unitOfWork.ProjectRepository.GetAll();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Some error in the GetAllOwners method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        
    }
}
