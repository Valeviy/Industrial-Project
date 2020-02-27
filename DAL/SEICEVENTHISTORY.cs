namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SEICEVENTHISTORY")]
    public partial class SEICEVENTHISTORY
    {
        public int? Ev_Type { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Ev_Time { get; set; }

        public int? Ev_Time_ms { get; set; }

        [StringLength(255)]
        public string Ev_Info { get; set; }

        [StringLength(255)]
        public string Ev_User { get; set; }

        [StringLength(255)]
        public string Ev_User_Full { get; set; }

        [StringLength(255)]
        public string Ev_Message { get; set; }

        [StringLength(255)]
        public string Ev_Value { get; set; }

        [StringLength(255)]
        public string Ev_Prev_Value { get; set; }

        [StringLength(255)]
        public string Ev_Station { get; set; }

        [StringLength(255)]
        public string Ev_Comment { get; set; }

        [StringLength(255)]
        public string Ev_Source { get; set; }

        public int? Ev_Deleted { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Last_Update { get; set; }

        public int? Last_Update_ms { get; set; }

        [Column(TypeName = "datetime2")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? TagTimeStamp { get; set; }

        [Key]
        public DateTime DBTimeStamp { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(255)]
        public string TagName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public float? Value { get; set; }
    }
}
