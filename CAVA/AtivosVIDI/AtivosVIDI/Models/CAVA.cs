namespace AtivosVIDI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CAVA : DbContext
    {
        public CAVA()
            : base("name=SistemaAtivo")
        {
        }

        public virtual DbSet<Ativos> Ativos { get; set; }
        public virtual DbSet<Celulares> Celulares { get; set; }
        public virtual DbSet<Chips> Chips { get; set; }
        public virtual DbSet<Colaboradores> Colaboradores { get; set; }
        public virtual DbSet<Computadores> Computadores { get; set; }
        public virtual DbSet<Historicos> Historicos { get; set; }
        public virtual DbSet<Softwares> Softwares { get; set; }
        public virtual DbSet<SoftwaresComputadores> SoftwaresComputadores { get; set; }
        public virtual DbSet<TipoColaboradores> TipoColaboradores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Ativos>()
                .Property(e => e.Modelo)
                .IsUnicode(false);


            modelBuilder.Entity<Ativos>()
                .Property(e => e.Valor)
                .HasPrecision(19, 4);

            //modelBuilder.Entity<Ativos>()
            //    .HasMany(e => e.Historicos)
            //    .WithOptional(e => e.Ativos)
            //    .HasForeignKey(e => e.AtivoId)
            //    .WillCascadeOnDelete();


            ///////////////////
            modelBuilder.Entity<Computadores>()//pk
                .HasMany(a => a.Ativos)//fk
                .WithOptional(a => a.Computadores)
                .HasForeignKey(c => c.ComputadorId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Celulares>()
               .HasMany(a => a.Ativos)
               .WithOptional(a => a.Celulares)
               .HasForeignKey(c => c.CelularId)
               .WillCascadeOnDelete();

            modelBuilder.Entity<Chips>()
               .HasMany(a => a.Ativos)
               .WithOptional(a => a.Chips)
               .HasForeignKey(c => c.ChipId)
               .WillCascadeOnDelete();

            ///////////////////////////
            modelBuilder.Entity<Celulares>()
                .Property(e => e.Valor)
                .HasPrecision(19, 4);

            //modelBuilder.Entity<Celulares>()
            //    .HasMany(e => e.Historicos)
            //    .WithOptional(e => e.Celulares)
            //    .HasForeignKey(e => e.CelularId);

            modelBuilder.Entity<Chips>()
                .Property(e => e.NumeroChip)
                .IsFixedLength();

            modelBuilder.Entity<Chips>()
                .Property(e => e.Plano)
                .IsUnicode(false);

            //modelBuilder.Entity<Chips>()
            //    .HasMany(e => e.Historicos)
            //    .WithOptional(e => e.Chips)
            //    .HasForeignKey(e => e.ChipId);

            //modelBuilder.Entity<Chips>()
            //    .HasMany(e => e.Historicos1)
            //    .WithOptional(e => e.Chips1)
            //    .HasForeignKey(e => e.ColaboradorIdFinal);

            modelBuilder.Entity<Colaboradores>()
                .Property(e => e.CPF)
                .IsFixedLength();

            modelBuilder.Entity<Colaboradores>()
                .Property(e => e.TelefoneFixo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Colaboradores>()
                .Property(e => e.TelefoneCelular)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Colaboradores>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Colaboradores>()
                .Property(e => e.Estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Colaboradores>()
                .Property(e => e.NomeCompleto)
                .IsUnicode(false);

            modelBuilder.Entity<Colaboradores>()
                .Property(e => e.Genero)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Colaboradores>()
                .HasMany(e => e.Ativos)
                .WithOptional(e => e.Colaboradores)
                .HasForeignKey(e => e.ColaboradorId);

            modelBuilder.Entity<Colaboradores>()
                .HasMany(e => e.Celulares)
                .WithOptional(e => e.Colaboradores)
                .HasForeignKey(e => e.ColaboradorId);

            modelBuilder.Entity<Colaboradores>()
                .HasMany(e => e.Chips)
                .WithOptional(e => e.Colaboradores)
                .HasForeignKey(e => e.ColaboradorId);

            modelBuilder.Entity<Colaboradores>()
                .HasMany(e => e.Computadores)
                .WithOptional(e => e.Colaboradores)
                .HasForeignKey(e => e.ColaboradorId);

            //modelBuilder.Entity<Colaboradores>()
            //    .HasMany(e => e.Historicos)
            //    .WithOptional(e => e.Colaboradores)
            //    .HasForeignKey(e => e.ColaboradorIdFinal);

            //modelBuilder.Entity<Colaboradores>()
            //    .HasMany(e => e.Historicos1)
            //    .WithOptional(e => e.Colaboradores1)
            //    .HasForeignKey(e => e.IntermediarioIdRecebeu);

            //modelBuilder.Entity<Colaboradores>()
            //    .HasMany(e => e.Historicos2)
            //    .WithOptional(e => e.Colaboradores2)
            //    .HasForeignKey(e => e.IntermediarioIdAssinouTermo);

            modelBuilder.Entity<Computadores>()
                .Property(e => e.NumeroSerie)
                .IsUnicode(false);

            modelBuilder.Entity<Computadores>()
                .Property(e => e.Processador)
                .IsUnicode(false);

            modelBuilder.Entity<Computadores>()
                .Property(e => e.Marca)
                .IsUnicode(false);

            modelBuilder.Entity<Computadores>()
                .Property(e => e.Modelo)
                .IsUnicode(false);

            modelBuilder.Entity<Computadores>()
                .Property(e => e.Origem)
                .IsUnicode(false);

            modelBuilder.Entity<Computadores>()
                .Property(e => e.Obs)
                .IsUnicode(false);

            modelBuilder.Entity<Computadores>()
                .Property(e => e.VersaoWindows)
                .IsUnicode(false);

            modelBuilder.Entity<Computadores>()
                .Property(e => e.Valor)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Computadores>()
                .Property(e => e.Fornecedor)
                .IsUnicode(false);

            modelBuilder.Entity<Computadores>()
                .Property(e => e.OrigemCompra)
                .IsUnicode(false);

            //modelBuilder.Entity<Computadores>()
            //    .HasMany(e => e.Historicos)
            //    .WithOptional(e => e.Computadores)
            //    .HasForeignKey(e => e.ComputadorId);

            modelBuilder.Entity<Computadores>()
                .HasMany(e => e.SoftwaresComputadores)
                .WithRequired(e => e.Computadores)
                .HasForeignKey(e => e.ComputadorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Historicos>()
                .Property(e => e.Obs)
                .IsUnicode(false);

            modelBuilder.Entity<Softwares>()
                .Property(e => e.NomeSoftware)
                .IsUnicode(false);

            modelBuilder.Entity<Softwares>()
                .Property(e => e.KeySoftware)
                .IsUnicode(false);

            modelBuilder.Entity<Softwares>()
                .Property(e => e.Valor)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Softwares>()
                .Property(e => e.Fornecedor)
                .IsUnicode(false);

            modelBuilder.Entity<Softwares>()
                .Property(e => e.OrigemCompra)
                .IsUnicode(false);

            modelBuilder.Entity<Softwares>()
                .HasMany(e => e.SoftwaresComputadores)
                .WithRequired(e => e.Softwares)
                .HasForeignKey(e => e.SoftwareId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoColaboradores>()
                .Property(e => e.Descricao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TipoColaboradores>()
                .HasMany(e => e.Colaboradores)
                .WithRequired(e => e.TipoColaboradores)
                .HasForeignKey(e => e.TipoColaborador)
                .WillCascadeOnDelete(false);
        }
    }
}
