namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BGroups
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BGroups()
        {
            BGroups1 = new HashSet<BGroups>();
            Points = new HashSet<Points>();
        }

        [Key]
        public int BGroupID { get; set; }

        public int? BGroupIDParent { get; set; }

        public short ResourceID { get; set; }

        [StringLength(255)]
        public string BGroupName { get; set; }

        public float? ValidDisbalance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BGroups> BGroups1 { get; set; }

        public virtual BGroups BGroups2 { get; set; }

        public virtual Resources Resources { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Points> Points { get; set; }
    }
}
