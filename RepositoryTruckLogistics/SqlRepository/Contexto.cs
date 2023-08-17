using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SqlRepository
{
    public class Contexto : DbContext
    {
        public Contexto() : base(@"data source=ANGEL-PC\SQLEXPRESS; initial catalog=TruckDriver; User id=sa; Password=angel123;MultipleActiveResultSets=True;App=EntityFramework")
        {

        }

        public virtual DbSet<Conductor.Conductor> Conductors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conductor.Conductor>()
                .HasKey(e => e.Id)
                .Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Conductor.Conductor>()
                .Property(p => p.Nombre)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Conductor.Conductor>()
                .Property(p => p.Pais)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Conductor.Conductor>()
                .Property(p => p.Ciudad)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Conductor.Conductor>()
                .Property(p => p.Telefono)
                .IsUnicode(false);
        }
    }
}
