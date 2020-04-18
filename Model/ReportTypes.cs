namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReportTypes
    {
        [StringLength(100)]
        public string ReportName { get; set; }

        [StringLength(100)]
        public string ReportTemplName { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short ReportType { get; set; }
    }
}
