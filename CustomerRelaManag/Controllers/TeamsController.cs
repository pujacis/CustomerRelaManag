using CustomerRelaManag.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CustomerRelaManag.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TeamsController(ApplicationDbContext context) { 
            _context = context;
        }
        public IActionResult Index()
        {
            var pl = _context.Projects.ToList();
            return View(pl);
        }
    }
}
