namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_TREND002
    {
        [Key]
        public DateTime Time_Stamp { get; set; }

        public float? tag2 { get; set; }
    }
}
