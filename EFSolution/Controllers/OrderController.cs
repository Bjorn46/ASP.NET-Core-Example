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
    public class OrderController : ControllerBase
    {
        private readonly FoodAppContext _context;

        public OrderController(FoodAppContext context)
        {
            _context = context;
        }

        
    }
}
