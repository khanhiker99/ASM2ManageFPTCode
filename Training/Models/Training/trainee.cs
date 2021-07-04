namespace Training.Models.Training
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trainee")]
    public partial class trainee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trainee()
        {
            courses = new HashSet<course>();
        }

        [Key]
        public int ID { get; set; }

        public int accountID { get; set; }

        [Required(ErrorMessage = "Phải nhập tên vào")]
        [StringLength(255)]
        public string name { get; set; }

        [Required(ErrorMessage = "Phải nhập ngày tháng năm sinh vào")]
        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Phải nhập Education vào")]
        [StringLength(255)]
        public string education { get; set; }

        [Required(ErrorMessage = "Phải nhập programming language vào")]
        [StringLength(255)]
        public string programmingLanguage { get; set; }

        public int TOEICScore { get; set; }

        public virtual account account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<course> courses { get; set; }
    }
}
