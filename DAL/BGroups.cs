namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BGroups
    {
        [Key]
        [Column(Order = 0)]
        public int BGroupID { get; set; }

        public int? BGroupIDParent { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short ResourceID { get; set; }

        [StringLength(255)]
        public string BGroupName { get; set; }

        public float? ValidDisbalance { get; set; }
    }
}
