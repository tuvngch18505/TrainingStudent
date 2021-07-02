namespace TrainningStudent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Topic")]
    public partial class Topic
    {
        public int TopicID { get; set; }

        [StringLength(100)]
        public string TopicName { get; set; }

        public int? CourseID { get; set; }

        public int? TrainerID { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public virtual Course Course { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
