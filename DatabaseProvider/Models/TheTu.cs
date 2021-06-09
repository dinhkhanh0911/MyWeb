namespace DatabaseProvider.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheTu")]
    public partial class TheTu
    {
        [Key]
        public int idTheTu { get; set; }

        public int idHocPHan { get; set; }

        [Required]
        [StringLength(20)]
        public string engWord { get; set; }

        [Required]
        [StringLength(50)]
        public string viWord { get; set; }

        [StringLength(50)]
        public string images { get; set; }

        [StringLength(50)]
        public string example { get; set; }

        public virtual HocPhan HocPhan { get; set; }
    }
}
