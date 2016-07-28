namespace AtivosVIDI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SoftwaresComputadores
    {
        public int Id { get; set; }

        public int SoftwareId { get; set; }

        public int ComputadorId { get; set; }

        public virtual Computadores Computadores { get; set; }

        public virtual Softwares Softwares { get; set; }
    }
}
