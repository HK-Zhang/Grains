using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovie.DAL;
using MvcMovie.Models;
using PagedList;
using System.Data;
using System.Net;
using System.Data.Entity;

namespace MvcMovie.Controllers
{
    public class CompanyController : Controller
    {
        private CompanyContext db = new CompanyContext();
        //
        // GET: /Company/
        public ActionResult Index(string sortOrder,string searchString,string currentFilter,int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameSortParm = string.IsNullOrEmpty(sortOrder) ? "first_desc" : "";
            ViewBag.LastNameSortParm = sortOrder == "last" ? "last_desc" : "last";

            if (searchString != null)
            {
                page = 1;
            }
            else {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var workers = from w in db.Workers
                          select w;

            if (!string.IsNullOrEmpty(searchString)) 
            {
                workers = workers.Where(w => w.FirstName.Contains(searchString) || w.LastName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "first_desc":
                    workers = workers.OrderByDescending(w => w.FirstName);
                    break;
                case "last_desc":
                    workers = workers.OrderByDescending(w => w.LastName);
                    break;
                case "last":
                    workers = workers.OrderBy(w => w.LastName);
                    break;
                default:
                    workers = workers.OrderBy(w => w.FirstName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page??1);

            //return View(workers.ToList());
            return View(workers.ToPagedList(pageNumber,pageSize));
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName, LastName, Sex, Rating")]Worker worker) 
        {
            try
            {
                if (ModelState.IsValid) {
                    db.Workers.Add(worker);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }
            catch (DataException)
            {

                ModelState.AddModelError("unableToSave", "Unable to save changes.Try again, and if the problem persists see your system administrator.");

            }
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Worker worker = db.Workers.Find(id);

            if (worker == null)
                return HttpNotFound();



            return View(worker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, FirstName, LastName, Sex, Rating")]Worker worker)
        {
            if (ModelState.IsValid) 
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(worker);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Worker worker = db.Workers.Find(id);

            if (worker == null)
                return HttpNotFound();

            return View(worker);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Worker worker = new Worker { ID = id };
                db.Entry(worker).State = EntityState.Deleted;
                db.SaveChanges();

            }
            catch (DataException)
            {
                return RedirectToAction("Index", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }
    }
}