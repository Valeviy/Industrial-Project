namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SEICALARMHISTORY")]
    public partial class SEICALARMHISTORY
    {
        public DateTime? Al_Start_Time { get; set; }

        public int? Al_Start_Time_ms { get; set; }

        [StringLength(255)]
        public string Al_Tag { get; set; }

        [StringLength(255)]
        public string Al_Message { get; set; }

        public int? Al_Ack { get; set; }

        public int? Al_Active { get; set; }

        public float? Al_Tag_Value { get; set; }

        public float? Al_Prev_Tag_Value { get; set; }

        public int? Al_Group { get; set; }

        public int? Al_Priority { get; set; }

        [StringLength(255)]
        public string Al_Selection { get; set; }

        public int? Al_Type { get; set; }

        public int? Al_Ack_Req { get; set; }

        public DateTime? Al_Norm_Time { get; set; }

        public int? Al_Norm_Time_ms { get; set; }

        public DateTime? Al_Ack_Time { get; set; }

        public int? Al_Ack_Time_ms { get; set; }

        [StringLength(255)]
        public string Al_User { get; set; }

        [StringLength(255)]
        public string Al_User_Comment { get; set; }

        [StringLength(255)]
        public string Al_User_Full { get; set; }

        [StringLength(255)]
        public string Al_Station { get; set; }

        public int? Al_Deleted { get; set; }

        public DateTime? Al_Event_Time { get; set; }

        public int? Al_Event_Time_ms { get; set; }

        public DateTime? Last_Update { get; set; }

        public int? Last_Update_ms { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? TagTimeStamp { get; set; }

        [Key]
        public DateTime DBTimeStamp { get; set; }
    }
}
