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
    public class OrderDetailController : ControllerBase
    {
        private readonly FoodAppContext _context;

        public OrderDetailController(FoodAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllOrderDetails()
        {
            var orderDetails = _context.OrderDetails;
            return Ok(orderDetails);
        }
    }
}
