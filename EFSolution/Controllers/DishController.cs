using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFSolution.Data;
using EFSolution.Models;
using EFSolution.DTO;

namespace EFSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishController : ControllerBase
    {
        private readonly FoodAppContext _context;

        public DishController(FoodAppContext context)
        {
            _context = context;
        }

        // GET: api/Dish - Get all dishes
        [HttpGet]
        public Task<List<DishDto>> GetAllDishes(FoodAppContext context)
        {
            return context.Dishes.Select(d => new DishDto()
            {
                DishId = d.DishId,
                CookId = d.CookId,
                Quantity = d.Quantity,
                DishName = d.DishName,
                Price = d.Price,
                StartTime = d.StartTime,
                EndTime = d.EndTime
            })
            .ToListAsync();
        }

        // GET: api/Dish/5 - Get a specific dish by id
        [HttpGet("{id}")]
        public async Task<ActionResult<DishDto>> GetDish(int id, FoodAppContext context)
        {
            var dish = await context.Dishes
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.DishId == id);

            if (dish == null)
            {
                return NotFound();
            }

            //Mapping Dish model to dishDto
            return new DishDto()
            {
                DishId = dish.DishId,
                CookId = dish.CookId,
                Quantity = dish.Quantity,
                DishName = dish.DishName,
                Price = dish.Price,
                StartTime = dish.StartTime,
                EndTime = dish.EndTime
            };
        }

        // POST: api/Dish - Creates a new dish
        [HttpPost]
        public void AddDish(DishDto Dish)
        {
            //Mapping Cook model to CookDto
            var dish = new Dish
            {
                DishId = Dish.DishId,
                CookId = Dish.CookId,
                Quantity = Dish.Quantity,
                DishName = Dish.DishName,
                Price = Dish.Price,
                StartTime = Dish.StartTime,
                EndTime = Dish.EndTime
            };
            _context.Dishes.Add(dish);
            _context.SaveChangesAsync();
        }

        // PUT: api/Dish/5 - Update a specific dish
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDish(int id, DishDto Dish)
        {
            if (id != Dish.DishId)
            {
                return BadRequest();
            }

            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }
            dish.DishName = Dish.DishName;
            dish.Price = Dish.Price;
            dish.StartTime = Dish.StartTime;
            dish.EndTime = Dish.EndTime;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // DishExists method
        private bool DishExists(int id)
        {
            return _context.Dishes.Any(e => e.DishId == id);
        }

    }
}
