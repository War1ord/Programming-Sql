using Express_Report_Folders.Web.Models;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Express_Report_Folders.Web.Controllers
{
	public class DbConnectionsController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		public async Task<ActionResult> Index()
		{
			return View(await db.DbConnections.ToListAsync());
		}

		public async Task<ActionResult> Details(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DbConnection dbConnection = await db.DbConnections.FindAsync(id);
			if (dbConnection == null)
			{
				return HttpNotFound();
			}
			return View(dbConnection);
		}

		public ActionResult Create()
		{
			return View();
		}
		[HttpPost, ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(DbConnection dbConnection)
		{
			if (ModelState.IsValid)
			{
				dbConnection.Id = Guid.NewGuid();
				db.DbConnections.Add(dbConnection);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			return View(dbConnection);
		}

		public async Task<ActionResult> Edit(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DbConnection dbConnection = await db.DbConnections.FindAsync(id);
			if (dbConnection == null)
			{
				return HttpNotFound();
			}
			return View(dbConnection);
		}
		[HttpPost, ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(DbConnection dbConnection)
		{
			if (ModelState.IsValid)
			{
				db.Entry(dbConnection).State = EntityState.Modified;
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(dbConnection);
		}

		public async Task<ActionResult> Delete(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DbConnection dbConnection = await db.DbConnections.FindAsync(id);
			if (dbConnection == null)
			{
				return HttpNotFound();
			}
			return View(dbConnection);
		}
		[HttpPost, ActionName(nameof(Delete)), ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(Guid id)
		{
			DbConnection dbConnection = await db.DbConnections.FindAsync(id);
			db.DbConnections.Remove(dbConnection);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
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
