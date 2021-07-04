namespace Training.Models.Training
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("course")]
    public partial class course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public course()
        {
            topics = new HashSet<topic>();
            trainees = new HashSet<trainee>();
           
        }

        [Key]
        public int ID { get; set; }

        public int categoryID { get; set; }


        [NotMapped]
        public int[] traineesID { get; set; }
        

        [Required(ErrorMessage = "Phải nhập tên course vào")]
        [StringLength(255)]
        public string courseName { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<topic> topics { get; set; }

        
        public HashSet<trainee> trainees { get; set; }

    }
}
