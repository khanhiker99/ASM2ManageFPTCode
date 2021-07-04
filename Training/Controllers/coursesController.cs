using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Training.Models;
using Training.Models.Training;

namespace Training.Controllers
{
    public class coursesController : Controller
    {
        private TrainingFPT db = new TrainingFPT();

        // GET: courses
        public ActionResult Index()
        {
            var courses = db.courses.Include(c => c.category);
            return View(courses.ToList());
        }

        // GET: courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: courses/Create
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.categories, "ID", "categoryName");
            ViewBag.trainees = new SelectList(db.trainees, "ID", "name");
            return View();
        }

        // POST: courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "categoryID,traineesID,courseName")] course course)
        {
           
            if (ModelState.IsValid)
            {
                HashSet<trainee> trainees = new HashSet<trainee>();
                
                course =  db.courses.Add(course);
                

                for (int i = 0; i < course.traineesID.Count(); i++)
                {
                    var trainee = db.trainees.Find(course.traineesID[i]);
                    trainees.Add(trainee);

                }
                
                course.trainees = trainees;
                db.courses.Add(course);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            

            ViewBag.categoryID = new SelectList(db.categories, "ID", "categoryName", course.categoryID);
            return View(course);
        }

        // GET: courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var courses = db.courses.Include(c => c.trainees).ToList();
            course course = courses.Find(m => m.ID.Equals(id));

            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.categories, "ID", "categoryName", course.categoryID);
            

            course.traineesID = course.trainees.Select(m => m.ID).ToArray();

            ViewBag.trainees = new MultiSelectList(db.trainees, "ID", "name", new[] { 9 });
            return View(course);
        }

        // POST: courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,categoryID,courseName")] course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.categories, "ID", "categoryName", course.categoryID);
            return View(course);
        }

        // GET: courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            course course = db.courses.Find(id);
            db.courses.Remove(course);
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
