namespace AtivosVIDI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ativos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ativos()
        {
            Historicos = new HashSet<Historicos>();
        }

        public int Id { get; set; }


        public int? CelularId { get; set; }

        public int? ComputadorId { get; set; }

        public int? ChipId { get; set; }




        [StringLength(50)]
        public string Modelo { get; set; }

        public int? ColaboradorId { get; set; }



        [Column(TypeName = "money")]
        public decimal Valor { get; set; }



        [Column(TypeName = "date")]
        public DateTime DataCompra { get; set; }

        public int NumeroPatrimonio { get; set; }

        public virtual Colaboradores Colaboradores { get; set; }
        public virtual Computadores Computadores { get; set; }
        public virtual Celulares Celulares { get; set; }
        public virtual Chips Chips { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historicos> Historicos { get; set; }
    }
}
