﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainningStudent.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace TrainningStudent.Controllers
{
    public class TraineeActionController : Controller
    {
        private Model1 db = new Model1();
        // GET: TraineeAction
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profile()
        {
            var userName = User.Identity.Name;

            var trainee = (from t in db.Trainee where t.TraineeName.Equals(userName) select t).FirstOrDefault();
            return View(trainee);
        }
        public ActionResult MyCourses()
        {
            var userName = User.Identity.Name;

            var enrollments = from e in db.Enrollment where e.Trainee.TraineeName.Equals(userName) select e;

            return View(enrollments.ToList());
        }
        [Authorize(Roles = "Trainee")]
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Trainee")]
        public ActionResult Edit([Bind(Include = "TraineeID,TraineeName,Majors,Phone,Classroom,Location")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Profile");
            }
            return View(trainee);
        }
    }
}