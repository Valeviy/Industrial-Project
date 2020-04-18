namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BalanceClosed")]
    public partial class BalanceClosed
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BGroupID { get; set; }

        public int? BGroupIDParent { get; set; }

        [StringLength(255)]
        public string BGroupName { get; set; }

        public float? ValidDisbalance { get; set; }

        [StringLength(255)]
        public string PointName { get; set; }

        [StringLength(2)]
        public string Direction { get; set; }

        public int? SourceID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string TagName { get; set; }

        public DateTime? Time_Stamp { get; set; }

        public int? Time_Stamp_ms { get; set; }

        public float? Value { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Period { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "smalldatetime")]
        public DateTime P { get; set; }

        public DateTime? DateClosed { get; set; }

        [StringLength(255)]
        public string UserName { get; set; }
    }
}
