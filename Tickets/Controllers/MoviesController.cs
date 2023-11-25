using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Data.Repositories.IRepositoryInterface;

namespace Tickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovie movie;
        public MoviesController(IMovie _movie) => movie = _movie;
        
        public async Task<IActionResult> Index()
        {
            var Movies = await movie.GetAllAsync(idx=>idx.Cinema);
            return View(Movies);
        }
    }
}
