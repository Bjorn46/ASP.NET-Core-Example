using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFSolution.Data;
using EFSolution.Models;
using System.Reflection.Metadata;
using EFSolution.DTO;

namespace EFSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CookController : ControllerBase
    {
        private readonly FoodAppContext _context;

        public CookController(FoodAppContext context)
        {
            _context = context;
        }

        // GET all cooks
        [HttpGet]
        public IActionResult GetAllCooks()
        {
            var cooks = _context.Cooks;
            return Ok(cooks);
        }

        // GET a specific cook by id
        [HttpGet("{id}")]
        public async Task<ActionResult<CookDto>> GetCook(int id)
        {
            var cook = await _context.Cooks
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.CookId == id);

            if (cook == null)
            {
                return NotFound();
            }

            //Mapping Cook model to CookDto
            return new CookDto()
            {
                CookId = cook.CookId,
                Rating = cook.Rating,
                Adress = cook.Adress,
                Name = cook.Name
            };
        }

        // POST: api/Cook - Creates a new cook
        [HttpPost]
        public void AddCook(CookDto Cook)
        {
            //Mapping Cook model to CookDto
            var cook = new Cook 
            {
                CookId = Cook.CookId,
                Rating = Cook.Rating,
                Adress = Cook.Adress,
                Name = Cook.Name
            };
            _context.Cooks.Add(cook);
            _context.SaveChangesAsync();

        }

    }
}
