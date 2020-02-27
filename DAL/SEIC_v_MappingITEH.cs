namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SEIC_v_MappingITEH
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string LSName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string DBName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(16)]
        public string TableName { get; set; }

        [StringLength(255)]
        public string TagName { get; set; }
    }
}
