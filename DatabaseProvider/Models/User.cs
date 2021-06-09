namespace DatabaseProvider.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            HocPhans = new HashSet<HocPhan>();
            HocPhanNgoaiTaos = new HashSet<HocPhanNgoaiTao>();
            HocSinhs = new HashSet<HocSinh>();
            LopHocs = new HashSet<LopHoc>();
        }

        [Key]
        public int idUser { get; set; }

        [Required]
        [StringLength(20)]
        public string userName { get; set; }

        [StringLength(100)]
        public string fullName { get; set; }

        public int? age { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        public bool? isAdmin { get; set; }

        [Required]
        [StringLength(50)]
        public string userPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocPhan> HocPhans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocPhanNgoaiTao> HocPhanNgoaiTaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocSinh> HocSinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHoc> LopHocs { get; set; }
    }
}
