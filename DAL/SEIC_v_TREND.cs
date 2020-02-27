namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SEIC_v_TREND
    {
        [StringLength(255)]
        public string Tagname { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? TagTimeStamp { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TagTimeStamp_ms { get; set; }

        public float? tag1 { get; set; }
    }
}
