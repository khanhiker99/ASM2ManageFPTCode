namespace Training.Models.Training
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account")]
    public class account
    {
      

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public account()
        {
            trainees = new HashSet<trainee>();
            trainers = new HashSet<trainer>();
            trainingStaffs = new HashSet<trainingStaff>();
            roles = new HashSet<role>();
        }

        [Key]
        public int ID { get; set; }

        [StringLength(15, MinimumLength = 7, ErrorMessage = "Phải nhập UserName tối thiểu là 7 và tối đa là 15")]
        [Required(ErrorMessage = "Phải nhập UserName vào")]
        public string username { get; set; }

        [StringLength(14, MinimumLength = 8, ErrorMessage = "Phải nhập PassWord tối thiểu là 8 và tối đa là 14")]
        [Required(ErrorMessage = "Phải nhập PassWord vào")]
        //[DisplayName("Mật khẩu")]     // DisplayName dùng để ghi đè nhãn dán
        [DataType(DataType.Password)]
        public string password { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trainee> trainees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trainer> trainers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trainingStaff> trainingStaffs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<role> roles { get; set; }
    }
}
