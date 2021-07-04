namespace Training.Models.Training
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("topic")]
    public partial class topic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public topic()
        {
            trainers = new HashSet<trainer>();
        }

        [Key]
        public int ID { get; set; }

        public int courseID { get; set; }

        [Required(ErrorMessage = "Phải nhập tên topic vào")]
        [StringLength(255)]
        public string topicName { get; set; }

        [Required]
        [StringLength(255)]
        public string description { get; set; }

        public virtual course course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trainer> trainers { get; set; }
    }
}
