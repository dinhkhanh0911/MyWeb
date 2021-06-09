namespace DatabaseProvider.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocPhan")]
    public partial class HocPhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocPhan()
        {
            HocPhanNgoaiTaos = new HashSet<HocPhanNgoaiTao>();
            TheTus = new HashSet<TheTu>();
        }

        [Key]
        public int idHocPhan { get; set; }

        [Required]
        [StringLength(100)]
        public string tenHocPhan { get; set; }

        public bool? isPrivate { get; set; }

        public DateTime? dateCreated { get; set; }

        public int idUser { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocPhanNgoaiTao> HocPhanNgoaiTaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TheTu> TheTus { get; set; }
    }
}
