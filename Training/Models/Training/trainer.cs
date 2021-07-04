namespace Training.Models.Training
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trainer")]
    public partial class trainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trainer()
        {
            topics = new HashSet<topic>();
        }

        [Key]
        public int ID { get; set; }

        public int accountID { get; set; }

        [Required(ErrorMessage = "Phải nhập tên vào")]
        [StringLength(255)]
        public string name { get; set; }

        [Required(ErrorMessage = "Phải nhập type vào")]
        [StringLength(255)]
        public string type { get; set; }

        [Required(ErrorMessage = "Phải nhập Education vào")]
        [StringLength(255)]
        public string education { get; set; }

        [Required(ErrorMessage = "Phải nhập nơi làm việc vào")]
        [StringLength(255)]
        public string workingPlace { get; set; }

        [Required(ErrorMessage = "Phải nhập số điện thoại vào")]
        [StringLength(255)]
        public string phoneNumber { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email không đúng định dạng")]
        [Required(ErrorMessage = "Phải nhập Email vào")]
        [StringLength(255)]
        public string email { get; set; }

        public virtual account account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<topic> topics { get; set; }
    }
}
