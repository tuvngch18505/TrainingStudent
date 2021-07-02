namespace TrainningStudent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trainee")]
    public partial class Trainee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainee()
        {
            Enrollment = new HashSet<Enrollment>();
        }

        public int TraineeID { get; set; }

        [StringLength(100)]
        public string TraineeName { get; set; }

        [StringLength(100)]
        public string Majors { get; set; }

        public int? Phone { get; set; }

        [StringLength(100)]
        public string Classroom { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}
