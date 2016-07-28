namespace AtivosVIDI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Softwares
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Softwares()
        {
            SoftwaresComputadores = new HashSet<SoftwaresComputadores>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NomeSoftware { get; set; }

        public byte MaximoInstalacoes { get; set; }

        [Required]
        [StringLength(50)]
        public string KeySoftware { get; set; }

        [Column(TypeName = "money")]
        public decimal Valor { get; set; }

        [Required]
        [StringLength(50)]
        public string Fornecedor { get; set; }

        [Required]
        [StringLength(50)]
        public string OrigemCompra { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataCompra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoftwaresComputadores> SoftwaresComputadores { get; set; }
    }
}
