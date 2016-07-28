namespace AtivosVIDI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Colaboradores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Colaboradores()
        {
            Ativos = new HashSet<Ativos>();
            Celulares = new HashSet<Celulares>();
            Chips = new HashSet<Chips>();
            Computadores = new HashSet<Computadores>();
            Historicos = new HashSet<Historicos>();
            Historicos1 = new HashSet<Historicos>();
            Historicos2 = new HashSet<Historicos>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string CPF { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(15)]
        public string TelefoneFixo { get; set; }

        [StringLength(15)]
        public string TelefoneCelular { get; set; }

        [Required]
        [StringLength(40)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string Estado { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeCompleto { get; set; }

        [StringLength(1)]
        public string Genero { get; set; }

        public int TipoColaborador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ativos> Ativos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Celulares> Celulares { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chips> Chips { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Computadores> Computadores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historicos> Historicos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historicos> Historicos1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historicos> Historicos2 { get; set; }

        public virtual TipoColaboradores TipoColaboradores { get; set; }
    }
}
