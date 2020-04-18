namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BalanceClosed_temp
    {
        public int? BGroupID { get; set; }

        public int? BGroupIDParent { get; set; }

        [StringLength(255)]
        public string BGroupName { get; set; }

        public float? ValidDisbalance { get; set; }

        [StringLength(255)]
        public string PointName { get; set; }

        [StringLength(2)]
        public string Direction { get; set; }

        public int? SourceID { get; set; }

        [StringLength(255)]
        public string TagName { get; set; }

        public DateTime? Time_Stamp { get; set; }

        public int? Time_Stamp_ms { get; set; }

        public float? Value { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Period { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? P { get; set; }

        public DateTime? DateClosed { get; set; }

        [StringLength(255)]
        public string UserName { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rid { get; set; }
    }
}
