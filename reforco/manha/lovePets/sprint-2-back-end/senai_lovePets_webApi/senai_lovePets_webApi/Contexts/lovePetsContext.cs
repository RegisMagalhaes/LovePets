using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_lovePets_webApi.Domains;

#nullable disable

namespace senai_lovePets_webApi.Contexts
{
    public partial class lovePetsContext : DbContext
    {
        public lovePetsContext()
        {
        }

        public lovePetsContext(DbContextOptions<lovePetsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Atendimento> Atendimentos { get; set; }
        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Dono> Donos { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Raca> Racas { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoPet> TipoPets { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Veterinario> Veterinarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-30RGV41\\SQLEXPRESS; initial catalog=lovePets_manha; user Id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Atendimento>(entity =>
            {
                entity.HasKey(e => e.IdAtendimento)
                    .HasName("PK__atendime__CCF8C80C139E68F8");

                entity.ToTable("atendimento");

                entity.Property(e => e.IdAtendimento).HasColumnName("idAtendimento");

                entity.Property(e => e.DataAtendimento)
                    .HasColumnType("datetime")
                    .HasColumnName("dataAtendimento");

                entity.Property(e => e.Descricao)
                    .HasColumnType("text")
                    .HasColumnName("descricao")
                    .HasDefaultValueSql("('sem descrição informada')");

                entity.Property(e => e.IdPet).HasColumnName("idPet");

                entity.Property(e => e.IdSituacao)
                    .HasColumnName("idSituacao")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.IdVeterinario).HasColumnName("idVeterinario");

                entity.HasOne(d => d.IdPetNavigation)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.IdPet)
                    .HasConstraintName("FK__atendimen__idPet__46E78A0C");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__atendimen__idSit__48CFD27E");

                entity.HasOne(d => d.IdVeterinarioNavigation)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.IdVeterinario)
                    .HasConstraintName("FK__atendimen__idVet__45F365D3");
            });

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__clinica__C73A605521F5EAFE");

                entity.ToTable("clinica");

                entity.HasIndex(e => e.Cnpj, "UQ__clinica__35BD3E48BA18AFFC")
                    .IsUnique();

                entity.HasIndex(e => e.Endereco, "UQ__clinica__9456D4065E161BA8")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoSocial, "UQ__clinica__9BF93A30CC8EB182")
                    .IsUnique();

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cnpj")
                    .IsFixedLength(true);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");
            });

            modelBuilder.Entity<Dono>(entity =>
            {
                entity.HasKey(e => e.IdDono)
                    .HasName("PK__dono__DE143B4F1A7EA545");

                entity.ToTable("dono");

                entity.Property(e => e.IdDono).HasColumnName("idDono");

                entity.Property(e => e.NomeDono)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeDono");
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(e => e.IdPet)
                    .HasName("PK__pet__3D78D11227A9CB54");

                entity.ToTable("pet");

                entity.HasIndex(e => e.Ra, "UQ__pet__321433160EAD2275")
                    .IsUnique();

                entity.Property(e => e.IdPet).HasColumnName("idPet");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.IdDono).HasColumnName("idDono");

                entity.Property(e => e.IdRaca).HasColumnName("idRaca");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomePet)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomePet");

                entity.Property(e => e.Ra)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ra")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdDonoNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.IdDono)
                    .HasConstraintName("FK__pet__idDono__3A81B327");

                entity.HasOne(d => d.IdRacaNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.IdRaca)
                    .HasConstraintName("FK__pet__idRaca__398D8EEE");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__pet__idUsuario__3B75D760");
            });

            modelBuilder.Entity<Raca>(entity =>
            {
                entity.HasKey(e => e.IdRaca)
                    .HasName("PK__raca__E1222B0235A06C70");

                entity.ToTable("raca");

                entity.HasIndex(e => e.NomeRaca, "UQ__raca__CCCCA2DF3AD0DD93")
                    .IsUnique();

                entity.Property(e => e.IdRaca).HasColumnName("idRaca");

                entity.Property(e => e.IdTipoPet).HasColumnName("idTipoPet");

                entity.Property(e => e.NomeRaca)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeRaca");

                entity.HasOne(d => d.IdTipoPetNavigation)
                    .WithMany(p => p.Racas)
                    .HasForeignKey(d => d.IdTipoPet)
                    .HasConstraintName("FK__raca__idTipoPet__2D27B809");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__situacao__12AFD19763D3264B");

                entity.ToTable("situacao");

                entity.HasIndex(e => e.NomeSituacao, "UQ__situacao__E5144E4BE11DAFE9")
                    .IsUnique();

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.NomeSituacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeSituacao");
            });

            modelBuilder.Entity<TipoPet>(entity =>
            {
                entity.HasKey(e => e.IdTipoPet)
                    .HasName("PK__tipoPet__FE6B57ABC1369B4C");

                entity.ToTable("tipoPet");

                entity.HasIndex(e => e.NomeTipoPet, "UQ__tipoPet__9A5D8CB8018B2F3D")
                    .IsUnique();

                entity.Property(e => e.IdTipoPet).HasColumnName("idTipoPet");

                entity.Property(e => e.NomeTipoPet)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoPet");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF868999AB");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__tipoUsua__A017BD9FE5EFE1E0")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A62370B498");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E6164D7AC7F27")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__35BCFE0A");
            });

            modelBuilder.Entity<Veterinario>(entity =>
            {
                entity.HasKey(e => e.IdVeterinario)
                    .HasName("PK__veterina__5097261308024876");

                entity.ToTable("veterinario");

                entity.HasIndex(e => e.Crmv, "UQ__veterina__F2379DCA38A05C20")
                    .IsUnique();

                entity.Property(e => e.IdVeterinario).HasColumnName("idVeterinario");

                entity.Property(e => e.Crmv)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CRMV")
                    .IsFixedLength(true);

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeVeterinario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeVeterinario");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Veterinarios)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__veterinar__idCli__3F466844");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Veterinarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__veterinar__idUsu__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
