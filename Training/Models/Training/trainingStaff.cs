namespace Training.Models.Training
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trainingStaff")]
    public partial class trainingStaff
    {
        [Key]
        public int ID { get; set; }

        public int accountID { get; set; }

        [Required(ErrorMessage = "Phải nhập tên vào")]
        [StringLength(255)]
        public string name { get; set; }

        [Required(ErrorMessage = "Phải nhập ngày thắng năm sinh vào")]
        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Phải nhập số điện thoại vào")]
        [StringLength(255)]
        public string phoneNumber { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email không đúng định dạng")]
        [Required(ErrorMessage = "Phải nhập Email vào")]
        [StringLength(255)]
        public string email { get; set; }

        public virtual account account { get; set; }
    }
}
