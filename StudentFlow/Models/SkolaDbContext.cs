using System;
using System.Linq;                 // behövs för ToList(), Where, GroupBy
using SkolSystem.Models;          // ditt scaffold-namespace
using Microsoft.EntityFrameworkCore; // behövs för Add(), Find(), SaveChanges() osv.


namespace SkolSystem.Models;

public partial class SkolaDbContext : DbContext
{
    public SkolaDbContext()
    {
    }

    public SkolaDbContext(DbContextOptions<SkolaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Klassrum> Klassrums { get; set; }

    public virtual DbSet<KursLärare> KursLärares { get; set; }

    public virtual DbSet<Kurser> Kursers { get; set; }

    public virtual DbSet<Lärare> Lärares { get; set; }

    public virtual DbSet<Registreringar> Registreringars { get; set; }

    public virtual DbSet<Studenter> Studenters { get; set; }

    public virtual DbSet<VwRegistreringarRapport> VwRegistreringarRapports { get; set; }

    public virtual DbSet<VwStudenterPublic> VwStudenterPublics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=YONIS\\SQLEXPRESS03;Database=SkolaDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Klassrum>(entity =>
        {
            entity.HasKey(e => e.KlassrumId).HasName("PK__Klassrum__245590B3D03E0511");

            entity.ToTable("Klassrum");

            entity.Property(e => e.KlassrumId).HasColumnName("KlassrumID");
            entity.Property(e => e.Namn).HasMaxLength(50);
            entity.Property(e => e.SkapadDatum)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<KursLärare>(entity =>
        {
            entity.HasKey(e => e.KursLärareId).HasName("PK__KursLära__FCE37D32579E5F50");

            entity.ToTable("KursLärare");

            entity.Property(e => e.KursLärareId).HasColumnName("KursLärareID");
            entity.Property(e => e.KursId).HasColumnName("KursID");
            entity.Property(e => e.LärareId).HasColumnName("LärareID");

            entity.HasOne(d => d.Kurs).WithMany(p => p.KursLärares)
                .HasForeignKey(d => d.KursId)
                .HasConstraintName("FK_KursLärare_Kurser");

            entity.HasOne(d => d.Lärare).WithMany(p => p.KursLärares)
                .HasForeignKey(d => d.LärareId)
                .HasConstraintName("FK_KursLärare_Lärare");
        });

        modelBuilder.Entity<Kurser>(entity =>
        {
            entity.HasKey(e => e.KursId).HasName("PK__Kurser__BCCFFF3B5F3FA6A7");

            entity.ToTable("Kurser");

            entity.Property(e => e.KursId).HasColumnName("KursID");
            entity.Property(e => e.KlassrumId).HasColumnName("KlassrumID");
            entity.Property(e => e.Kursnamn).HasMaxLength(100);
            entity.Property(e => e.SkapadDatum)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Klassrum).WithMany(p => p.Kursers)
                .HasForeignKey(d => d.KlassrumId)
                .HasConstraintName("FK_Kurser_Klassrum");
        });

        modelBuilder.Entity<Lärare>(entity =>
        {
            entity.HasKey(e => e.LärareId).HasName("PK__Lärare__F90078CD8F39710A");

            entity.ToTable("Lärare");

            entity.Property(e => e.LärareId).HasColumnName("LärareID");
            entity.Property(e => e.Efternamn).HasMaxLength(50);
            entity.Property(e => e.Förnamn).HasMaxLength(50);
            entity.Property(e => e.SkapadDatum)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Registreringar>(entity =>
        {
            entity.HasKey(e => e.RegistreringId).HasName("PK__Registre__DF2A68A51055624D");

            entity.ToTable("Registreringar");

            entity.Property(e => e.RegistreringId).HasColumnName("RegistreringID");
            entity.Property(e => e.Betyg)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.KursId).HasColumnName("KursID");
            entity.Property(e => e.SkapadDatum)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Kurs).WithMany(p => p.Registreringars)
                .HasForeignKey(d => d.KursId)
                .HasConstraintName("FK_Registreringar_Kurser");

            entity.HasOne(d => d.Student).WithMany(p => p.Registreringars)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Registreringar_Studenter");
        });

        modelBuilder.Entity<Studenter>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Studente__32C52A79888604A4");

            entity.ToTable("Studenter");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Efternamn).HasMaxLength(50);
            entity.Property(e => e.Förnamn).HasMaxLength(50);
            entity.Property(e => e.SkapadDatum)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<VwRegistreringarRapport>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_RegistreringarRapport");

            entity.Property(e => e.Betyg)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Efternamn).HasMaxLength(50);
            entity.Property(e => e.Förnamn).HasMaxLength(50);
            entity.Property(e => e.Kursnamn).HasMaxLength(100);
            entity.Property(e => e.SkapadDatum).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwStudenterPublic>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_StudenterPublic");

            entity.Property(e => e.Efternamn).HasMaxLength(50);
            entity.Property(e => e.Förnamn).HasMaxLength(50);
            entity.Property(e => e.StudentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("StudentID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
