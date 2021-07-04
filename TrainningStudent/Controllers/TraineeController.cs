using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainningStudent.Models;
using System.Data.Entity;
using System.Net;

namespace TrainningStudent.Controllers
{
    public class TraineeController : Controller
    {
        private Model1 db = new Model1();
        // GET: Trainee
        public ActionResult Index()
        {
           
            var trainees = from t in db.Trainee select t;

            return View(db.Trainee.ToList());
        }
        // GET: Trainees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainee.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }
        // GET: Trainees/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        // POST: Trainees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "TraineeID,TraineeName,Majors,Phone,Classroom,Location")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Trainee.Add(trainee);
                db.SaveChanges();
                AuthenticController.CreateAccount(trainee.TraineeName, "123456", "Trainee");
                return RedirectToAction("Index");
            }
            return View(trainee);
        }
        // GET: Trainees/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainee.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }
        // POST: Trainees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "TraineeID,TraineeName,Majors,Phone,Classroom,Location")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainee);
        }

        // GET: Trainees/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainee.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }
        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainee trainee = db.Trainee.Find(id);
            db.Trainee.Remove(trainee);
            db.SaveChanges();
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