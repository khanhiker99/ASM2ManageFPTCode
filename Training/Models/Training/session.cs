using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Training.Models.Training;

namespace Training.Models.Training
{
    [Serializable]
    public class Userlogin
    {
        public long AccountID { set; get; }
        public string UserName { set; get; }
        public  role role { set; get; }
        
    }
}