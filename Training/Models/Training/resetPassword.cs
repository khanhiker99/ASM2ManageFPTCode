using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Training.Models.Training
{
    public class resetPassword
    {
        [StringLength(14, MinimumLength = 8, ErrorMessage = "Phải nhập PassWord tối thiểu là 8 và tối đa là 14")]
        [Required(ErrorMessage = "Phải nhập PassWord vào")]
        //[DisplayName("Mật khẩu")]     // DisplayName dùng để ghi đè nhãn dán
        [DataType(DataType.Password)]
        public string password { get; set; }


        [Compare("newPassWord", ErrorMessage = "PassWord bạn vừa nhập không trùng khớp với PassWord trước đó mời bạn nhập lại")]
        [Required(ErrorMessage = "Phải nhập lại PassWord vào")]
        [DataType(DataType.Password)]
        
        public String newPassWord { get; set; }


        [Compare("returnPassWord", ErrorMessage = "PassWord bạn vừa nhập không trùng khớp với PassWord trước đó mời bạn nhập lại")]
        [Required(ErrorMessage = "Phải nhập lại PassWord vào")]
        [DataType(DataType.Password)]
        
        public String ReturnPassWord { get; set; }
    }
}