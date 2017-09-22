using Express_Report_Folders.Web.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Express_Report_Folders.Web.Controllers
{
	public class ReportsController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		public async Task<ActionResult> Index()
		{
			return View(await db.Reports.ToListAsync());
		}

		public async Task<ActionResult> Details(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Report report = await db.Reports.FindAsync(id);
			if (report == null)
			{
				return HttpNotFound();
			}
			return View(report);
		}

		public ActionResult Create()
		{
			ViewBag.DbConnectionId = new SelectList(db.DbConnections, "Id", "ConnectionString");
			return View();
		}
		[HttpPost, ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Report report)
		{
			if (ModelState.IsValid)
			{
				report.Id = Guid.NewGuid();
				db.Reports.Add(report);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			ViewBag.DbConnectionId = new SelectList(db.DbConnections, "Id", "ConnectionString", report.DbConnectionId);
			return View(report);
		}

		public async Task<ActionResult> Edit(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Report report = await db.Reports.FindAsync(id);
			if (report == null)
			{
				return HttpNotFound();
			}
			ViewBag.DbConnectionId = new SelectList(db.DbConnections, "Id", "ConnectionString", report.DbConnectionId);
			return View(report);
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(Report report)
		{
			if (ModelState.IsValid)
			{
				db.Entry(report).State = EntityState.Modified;
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			ViewBag.DbConnectionId = new SelectList(db.DbConnections, "Id", "ConnectionString", report.DbConnectionId);
			return View(report);
		}

		public async Task<ActionResult> Delete(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Report report = await db.Reports.FindAsync(id);
			if (report == null)
			{
				return HttpNotFound();
			}
			return View(report);
		}

		[HttpPost, ActionName(nameof(Delete)), ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(Guid id)
		{
			Report report = await db.Reports.FindAsync(id);
			db.Reports.Remove(report);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		public async Task<ActionResult> Build(Guid? id)
		{
			return View(await db.Reports
				.Where(i => i.Id == id)
				.Include(i => i.ReportQueryParameters)
				.Include(i => i.ReportQuerySelects)
				.Include(i => i.ReportQueueJoins)
				.Include(i => i.ReportQueryWhere)
				.FirstAsync()
				);
		}
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Build(Report report)
		{
			return View();
		}

		public async Task<ActionResult> Run(Guid? id)
		{
			return View(await db.Reports
				.Where(i => i.Id == id)
				.Include(i => i.ReportQueryParameters)
				.Include(i => i.ReportQuerySelects)
				.Include(i => i.ReportQueueJoins)
				.Include(i => i.ReportQueryWhere)
				.FirstAsync()
				);
		}
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Run(Report report)
		{
			return View();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
