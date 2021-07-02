using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainningStudent.Models;

namespace TrainningStudent.Controllers
{
    public class EnrollmentTrainerController : Controller
    {
        // GET: EnrollmentTrainer
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            var enrollment = db.Enrollment.Include(e => e.Course).Include(e => e.Trainer).Include(e => e.Trainee);
      
            return View(enrollment.ToList());
        }
      

        // GET: Enrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollment.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollments/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Course, "CourseID", "CourseName","");
            ViewBag.TraineeID = new SelectList(db.Trainee, "TraineeID", "TraineeName","");
            ViewBag.TrainerID = new SelectList(db.Trainer, "TrainerID", "TrainerName","");
            
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "EnrollmentID,CourseID,TraineeID,TrainerID")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollment.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Course, "CourseID", "CourseName", enrollment.CourseID);
            ViewBag.TraineeID = new SelectList(db.Trainee, "TraineeID", "TraineeName", enrollment.TraineeID);
            ViewBag.TrainerID = new SelectList(db.Trainer, "TrainerID", "TrainerName", enrollment.TrainerID);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollment.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Course, "CourseID", "CourseName", enrollment.CourseID);
            ViewBag.TraineeID = new SelectList(db.Trainee, "TraineeID", "TraineeName", enrollment.TraineeID);
            ViewBag.TrainerID = new SelectList(db.Trainer, "TrainerID", "TrainerName", enrollment.TrainerID);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "EnrollmentID,CourseID,TraineeID,TrainerID")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Course, "CourseID", "CourseName", enrollment.CourseID);
            ViewBag.TraineeID = new SelectList(db.Trainee, "TraineeID", "TraineeName", enrollment.TraineeID);
            ViewBag.TrainerID = new SelectList(db.Trainer, "TrainerID", "TrainerName", enrollment.TrainerID);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollment.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = db.Enrollment.Find(id);
            db.Enrollment.Remove(enrollment);
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