namespace DatabaseProvider.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LopHoc")]
    public partial class LopHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LopHoc()
        {
            HocSinhs = new HashSet<HocSinh>();
        }

        [Key]
        public int idLopHoc { get; set; }

        public int? idUser { get; set; }

        [StringLength(100)]
        public string tenLop { get; set; }

        [StringLength(200)]
        public string descriptionClass { get; set; }

        public DateTime? dateCreated { get; set; }

        [StringLength(20)]
        public string codeShare { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocSinh> HocSinhs { get; set; }

        public virtual User User { get; set; }
    }
}
