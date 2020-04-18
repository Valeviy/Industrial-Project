namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rules
    {
        [Key]
        public int RuleID { get; set; }

        public int? PointID { get; set; }

        [StringLength(255)]
        public string Formula { get; set; }

        public virtual Points Points { get; set; }
    }
}
