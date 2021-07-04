using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Training.Controllers
{
    public class SessionController : Controller
    {
        // GET: Seeson

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);  // 
            if ( Session["TraineeID"] == null  || Session["TraineeID"].Equals("")
              )
            {
                RouteValueDictionary route = new RouteValueDictionary(new { Controller = "Login", Action = "Index" });
                filterContext.Result = new RedirectToRouteResult(route);
                return;
            }            
        }
    }
}