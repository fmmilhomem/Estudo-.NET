namespace AtivosVIDI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Historicos
    {
        public int Id { get; set; }


        public int? AtivoId { get; set; }

        public int? ColaboradorIdFinal { get; set; }

        public bool AssinouTermoEntrega { get; set; }

        public bool AssinouTermoDevolucao { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataUserInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataUserFinal { get; set; }

        public int? IntermediarioIdAssinouTermo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataIntermediarioRetirou { get; set; }

        public int? IntermediarioIdRecebeu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataIntermediarioIdRecebeu { get; set; }

        public string Obs { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataFinalExperiencia { get; set; }

        public virtual Ativos Ativos { get; set; }

        public virtual Celulares Celulares { get; set; }

        public virtual Chips Chips { get; set; }

        public virtual Chips Chips1 { get; set; }

        public virtual Colaboradores Colaboradores { get; set; }

        public virtual Colaboradores Colaboradores1 { get; set; }

        public virtual Colaboradores Colaboradores2 { get; set; }

        public virtual Computadores Computadores { get; set; }
    }
}
