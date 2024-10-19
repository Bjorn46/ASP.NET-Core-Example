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

    }
}
