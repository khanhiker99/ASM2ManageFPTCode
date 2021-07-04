using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.Models
{
    public class CommonConstants
    {
        public static string ADMIN_SESSION = "ADMIN_SESSION";
        public static string TRAINEE_SESSION = "TRAINEE_SESSION";
        public static string TRAINER_SESSION = "TRAINER_SESSION";
        public static string TRAINING_SESSION = "TRAINING_SESSION";
        
        public static string CurrentCulture { set; get; }
        public static string TRAININGSTAFF_SESSION { get; internal set; }
    }
}