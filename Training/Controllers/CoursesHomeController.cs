using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training.Models;
using Training.Models.Training;

namespace Training.Controllers
{
    public class CoursesHomeController : SessionController  // Session: Lưu thông tin xuyên suốt app đang chạy
    {
        // GET: CoursesHome

        private TrainingFPT db = new TrainingFPT();

        // GET: courses
        public ActionResult AvailableCourse()
        {
            var courses = db.courses.Include(c => c.category);      // Include: Lấy thêm thông tin trong Category của từng Course một
            return View(courses.ToList());
        }
    }
}