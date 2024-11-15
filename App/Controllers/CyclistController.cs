using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFSolution.Data;
using EFSolution.Models;

namespace EFSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CyclistController : ControllerBase
    {
        private readonly FoodAppContext _context;

        public CyclistController(FoodAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCyclists()
        {
            var cyclists = _context.Cyclists;
            return Ok(cyclists);
        }
    }
}
