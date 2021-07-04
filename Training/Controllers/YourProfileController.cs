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
    public class YourProfileController : SessionController
    {
        // GET: YourProfile

        private TrainingFPT db = new TrainingFPT();
        public ActionResult Index()
        {
            var accountID = Session["TraineeID"];
            string str = Session["TraineeID"].ToString();
            
            var currentTrainee = db.trainees.Where(m => m.accountID.ToString().Equals(str)).ToList();
            return View(currentTrainee[0]);

            
        }
    }
}