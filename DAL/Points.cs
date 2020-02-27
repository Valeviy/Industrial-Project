namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Points
    {
        [Key]
        [Column(Order = 0)]
        public int PointID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BGroupID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string Direction { get; set; }

        [StringLength(255)]
        public string Tagname { get; set; }

        public int? PeriodID { get; set; }

        public float? ValidMistake { get; set; }

        public int? SourceID { get; set; }

        [StringLength(50)]
        public string PointName { get; set; }
    }
}
