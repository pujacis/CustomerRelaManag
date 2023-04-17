using CustomerRelaManag.Data;
using CustomerRelaManag.Models;
using CustomerRelaManag.ModelVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CustomerRelaManag.Controllers
{
	public class BDEController : Controller
	{
		private readonly ApplicationDbContext _context;
		public BDEController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult BDEUI()
		{


            var data = (from pm in _context.Projects 
                         join Tm in _context.Teams on pm.TeamId equals Tm.TeamId into team 
                         from t in team.DefaultIfEmpty()
                        join prom in _context.ProcessManagers on pm.PMID equals prom.PMId into proma
                        from p in proma.DefaultIfEmpty()
                        join s in _context.Statuss on pm.StatusId equals s.StatusId into sta
                        from st in sta.DefaultIfEmpty()
                        join bd in _context.BDEs on pm.BdId equals bd.BDEId into bde
                        from b in bde.DefaultIfEmpty()
                        join c in _context.Clients on pm.Clientid equals c.ClientId into cl
                          from cli in cl.DefaultIfEmpty()
                        select new ProjectVM
                        {
                            PMName = p ==null ?"NO PM":p.PMName,
                            BDName = b==null?"NO BD": b.BDEName,
                            TeamName = t==null?"NO TM": t.TeamName,
                            ClientName = cli==null?"NO CN": cli.ClientName,
                            Status = st==null?"NO St": st.StatusName,
                            ProjectId = pm.ProjectId,
                            ProjectName = pm.ProjectName,
                            CreatedDate = pm.CreatedDate,
                            Details= pm.Details,
                        }).ToList();


            return View(data);
		}
		
		public IActionResult Assign(Projects model)
		{
            var project = _context.Projects.Find(model.ProjectId);
			if (project != null)
			{
				project.PMID = model.PMID;				
				_context.SaveChangesAsync();
			}
				return View("BDEUI");
			
		}
		public IActionResult Delete(int id)
        {
            var data = _context.Projects.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
		}
        [HttpPost]
		public IActionResult Delete(Projects model)
        {
            var projtct =  _context.Projects.Find(model.ProjectId);
            if (projtct != null)
            {
                _context.Projects.Remove(projtct);
            }

             _context.SaveChangesAsync();
            return RedirectToAction("BDEUI");
		}
        public IActionResult Details(int id)
        {
            var data = _context.Projects.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        public IActionResult Edit(int id)
        {   
			if(id == 0)
			{ return NotFound();
			}
            List<SelectListItem> PMList = new List<SelectListItem>();
            var pmlist = _context.ProcessManagers.ToList();
            foreach (var item in pmlist)
            {
                SelectListItem pm = new SelectListItem();
                pm.Value = Convert.ToString(item.PMId);
                pm.Text = item.PMName;
                PMList.Add(pm);
            }
            ViewBag.Pm = PMList;
            List<SelectListItem> Status = new List<SelectListItem>();
            var statusl = _context.Statuss.ToList();
            foreach (var item in statusl)
            {
                SelectListItem status = new SelectListItem();
                status.Value = Convert.ToString(item.StatusId);
                status.Text = item.StatusName;
                Status.Add(status);
            }
            ViewBag.status = Status;
            var data =_context.Projects.Find(id);
            if (data == null)
            {
                return NotFound();
            }


            return View(data);
        }
		[HttpPost]
        public IActionResult Edit(Projects model)
		{
			var data = _context.Projects.Find(model.ProjectId);
			if (data != null)
			{
				data.PMID = model.PMID;
				data.CreatedDate = model.CreatedDate;
				data.ProjectName= model.ProjectName;
				data.Clientid=model.Clientid;
				data.StatusId=model.StatusId;
				data.TeamId=model.TeamId;
				data.Details= model.Details;

				_context.SaveChangesAsync();
			}
            return RedirectToAction("BDEUI");
		}
        public IActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProject(Projects project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                 _context.SaveChangesAsync();
                return RedirectToAction(nameof(BDEUI));
            }
            return View(project);
        }

	}
}
