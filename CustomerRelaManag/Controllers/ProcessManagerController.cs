using CustomerRelaManag.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CustomerRelaManag.Controllers
{
    public class ProcessManagerController : Controller
    {
        private readonly ApplicationDbContext _Context;
        public ProcessManagerController(ApplicationDbContext context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {
            List<SelectListItem> TmList = new List<SelectListItem>();
            var tmlist = _Context.Teams.ToList();
            foreach (var item in tmlist)
            {
                SelectListItem pm = new SelectListItem();
                pm.Value = Convert.ToString(item.TeamId);                
                pm.Text = item.TeamName;
                TmList.Add(pm);
            }
            ViewBag.tm = TmList;
            var pl = _Context.Projects.ToList();
            return View(pl);
        }
    }
}
