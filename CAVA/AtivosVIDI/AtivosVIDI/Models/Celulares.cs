namespace AtivosVIDI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Celulares
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Celulares()
        {
            Historicos = new HashSet<Historicos>();
        }

        public int Id { get; set; }

        public int? ColaboradorId { get; set; }

        [Required]
        [StringLength(50)]
        public string Modelo { get; set; }

        [Required]
        [StringLength(30)]
        public string OrigemCelular { get; set; }

        public int NumeroPatrimonio { get; set; }

        public int SenhaDesbloqueio { get; set; }

        [Required]
        [StringLength(40)]
        public string NumeroSerie { get; set; }

        public long? Imei { get; set; }

        [Required]
        [StringLength(40)]
        public string LoginLoja { get; set; }

        [Required]
        [StringLength(40)]
        public string SenhaLoja { get; set; }

        [Required]
        [StringLength(20)]
        public string Marca { get; set; }

        [Column(TypeName = "money")]
        public decimal Valor { get; set; }

        [Required]
        [StringLength(30)]
        public string Fornecedor { get; set; }

        [Required]
        [StringLength(30)]
        public string OrigemCompra { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataCompra { get; set; }

        public virtual Colaboradores Colaboradores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historicos> Historicos { get; set; }
    }
}
