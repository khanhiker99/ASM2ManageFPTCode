using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Training.Models;
using Training.Models.Training;

namespace Training.Controllers
{
    public class LoginController : Controller
    {
        private TrainingFPT db = new TrainingFPT();
        

        [HttpPost]
        public ActionResult Index(account acc)
        {
            var accounts  = db.accounts.Where(u => u.username == acc.username).ToList();

            if (accounts.Count > 0) 
            {
                accounts = accounts.Where(u => u.password == acc.password).ToList();
                if (accounts.Count > 0)
                {
                    var account = accounts.First();
                    var roles = account.roles;
                    var role = roles.First();
                    if (role.roleName.Equals("TRAINEE"))
                    {
                        var userSession = new Userlogin();
                        userSession.UserName = account.username;
                        userSession.AccountID = account.ID;
                        userSession.role = role;
                        
                        Session.Add(CommonConstants.TRAINEE_SESSION, userSession);
                        var i = Session["SESSION_CREDENTIALS"];
                        Session["TraineeID"] = account.ID;
                        Session["TraineeName"] = account.username;
                        

                        return RedirectToAction("Index", "Home");
                    }
                    else if (role.roleName.Equals("ADMIN"))
                    {
                        var userSession = new Userlogin();
                        userSession.UserName = account.username;
                        userSession.AccountID = account.ID;
                        userSession.role = role;

                        Session.Add(CommonConstants.ADMIN_SESSION, userSession);
                        var i = Session["SESSION_CREDENTIALS"];
                        Session["AdminID"] = account.ID;
                        Session["AdminName"] = account.username;


                        return RedirectToAction("Index", "Home");                    
                    }    
                    else if (role.roleName.Equals("TRAINER"))
                    {
                        var userSession = new Userlogin();
                        userSession.UserName = account.username;
                        userSession.AccountID = account.ID;
                        userSession.role = role;

                        Session.Add(CommonConstants.TRAINER_SESSION, userSession);
                        var i = Session["SESSION_CREDENTIALS"];
                        Session["TrainerID"] = account.ID;
                        Session["TrainerName"] = account.username;


                        return RedirectToAction("Index", "Home");
                    }    
                    else
                    {
                        var userSession = new Userlogin();
                        userSession.UserName = account.username;
                        userSession.AccountID = account.ID;
                        userSession.role = role;

                        Session.Add(CommonConstants.TRAININGSTAFF_SESSION, userSession);
                        var i = Session["SESSION_CREDENTIALS"];
                        Session["TrainingStaffID"] = account.ID;
                        Session["TrainingStaffName"] = account.username;


                        return RedirectToAction("Index", "Home");
                    }
                   
                }    
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["TraineeID"] = "";
            Session["TraineeName"] = "";

            Session["AdminID"] = "";
            Session["AdminName"] = "";

            Session["TrainingStaffID"] = "";
            Session["TrainingStaffName"] = "";

            Session["TrainerID"] = "";
            Session["TrainerName"] = "";


            Response.Redirect("~/Login");
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}
