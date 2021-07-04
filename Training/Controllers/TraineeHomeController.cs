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
    public class TraineeHomeController : SessionController
    {
        private TrainingFPT db = new TrainingFPT();
        // GET: TraineeHome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(resetPassword acc)
        {
           
                // Lấy ID hiện tại của mình
                var accountID = Session["TraineeID"];
                string str = Session["TraineeID"].ToString();

                var account = db.accounts.Find(Int32.Parse(str));

                if (account.password.Equals(acc.password))
                {
                    if (acc.newPassWord.Equals(acc.ReturnPassWord))
                    {
                        account.password = acc.ReturnPassWord;
                        //db.accounts.Add(account);
                        db.Entry(account).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                }
            
            return View("ChangePassword");
        }

        public ActionResult YourProfile()
        {
            return View();
        }



        public ActionResult AvailableCourse()
        {
            var courses = db.courses.Include(c => c.category);      // Include: Lấy thêm thông tin trong Category của từng Course một
            return View("AvailableCourse", courses.ToList());       // Trả List corse này về AvailableCourse.cshtml
        }

        public ActionResult CoursesAssigned()
        {
            var accountID = Session["TraineeID"];
            string str = Session["TraineeID"].ToString();

            var account = db.accounts.Find(Int32.Parse(str));
            var trainees = db.trainees.Where(m => m.accountID.Equals(account.ID)).ToList();
            var listCourse = new HashSet<course>();

            if (trainees.Count() > 0)
            {
                listCourse = (HashSet<course>)trainees[0].courses;
            }

            //var courses = db.courses.Include(c => c.category);      
            return View("CoursesAssigned", listCourse);       
        }

    }
}