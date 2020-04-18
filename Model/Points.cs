namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Points
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Points()
        {
            Rules = new HashSet<Rules>();
        }

        [Key]
        public int PointID { get; set; }

        public int BGroupID { get; set; }

        [Required]
        [StringLength(2)]
        public string Direction { get; set; }

        [StringLength(255)]
        public string Tagname { get; set; }

        public int? PeriodID { get; set; }

        public float? ValidMistake { get; set; }

        public int? SourceID { get; set; }

        [StringLength(50)]
        public string PointName { get; set; }

        public virtual BGroups BGroups { get; set; }

        public virtual Periods Periods { get; set; }

        public virtual Sources Sources { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rules> Rules { get; set; }
    }
}
