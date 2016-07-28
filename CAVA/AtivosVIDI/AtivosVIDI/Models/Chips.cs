namespace AtivosVIDI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Chips
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chips()
        {
            Historicos = new HashSet<Historicos>();
            Historicos1 = new HashSet<Historicos>();
        }

        public int Id { get; set; }

        [StringLength(15)]
        public string NumeroChip { get; set; }

        public int Conta { get; set; }

        public bool Ativado { get; set; }

        [Required]
        [StringLength(50)]
        public string Plano { get; set; }

        public int? ColaboradorId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historicos> Historicos { get; set; }

        public virtual Colaboradores Colaboradores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historicos> Historicos1 { get; set; }
    }
}
