using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAdminElGas.Data
{
    public partial class ELGASContext : DbContext
    {

        public ELGASContext(DbContextOptions<ELGASContext> options)
         : base(options)
        {

        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Bodega> Bodega { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Cobertura> Cobertura { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<CompraCancelada> CompraCancelada { get; set; }
        public virtual DbSet<Distribuidor> Distribuidor { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }
        public virtual DbSet<PuntoCobertura> PuntoCobertura { get; set; }
        public virtual DbSet<PuntoSector> PuntoSector { get; set; }
        public virtual DbSet<Ruta> Ruta { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<SectorDistribuidor> SectorDistribuidor { get; set; }
        public virtual DbSet<TipoSuscripcion> TipoSuscripcion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=developmentds.eastus.cloudapp.azure.com;Database=ELGAS;User Id=sa;password=Digital_2018;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.HasKey(e => e.IdBodega);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombreBodega)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NombreContacto)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TelfContacto)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.IdCiudad);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N/A')");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceId)
                    .HasColumnName("DeviceID")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.IdAspNetUser).HasMaxLength(128);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SistemaOperativo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAspNetUserNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdAspNetUser)
                    .HasConstraintName("FK_Cliente_AspNetUsers");

                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdSector)
                    .HasConstraintName("FK_Cliente_Sector");
            });

            modelBuilder.Entity<Cobertura>(entity =>
            {
                entity.HasKey(e => e.IdCobertura);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Barrio)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('No Definido')");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((0))");

                entity.Property(e => e.EstadoNotificacion).HasDefaultValueSql("((0))");

                entity.Property(e => e.FechaAplica).HasColumnType("datetime");

                entity.Property(e => e.FechaFinalizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaPedido).HasColumnType("datetime");

                entity.Property(e => e.Referencia)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Sector)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('No Definido')");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("RefCliente1");

                entity.HasOne(d => d.IdDistribuidorNavigation)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.IdDistribuidor)
                    .HasConstraintName("RefDistribuidor2");
            });

            modelBuilder.Entity<CompraCancelada>(entity =>
            {
                entity.HasKey(e => e.IdCompraCancelada);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.CompraCancelada)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_CompraCancelada_Cliente");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.CompraCancelada)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompraCancelada_Compra");

                entity.HasOne(d => d.IdDistribuidorNavigation)
                    .WithMany(p => p.CompraCancelada)
                    .HasForeignKey(d => d.IdDistribuidor)
                    .HasConstraintName("FK_CompraCancelada_Distribuidor");
            });

            modelBuilder.Entity<Distribuidor>(entity =>
            {
                entity.HasKey(e => e.IdDistribuidor)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceId)
                    .HasColumnName("DeviceID")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.FirebaseId)
                    .HasColumnName("FirebaseID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdAspNetUser).HasMaxLength(128);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PlacaVehiculo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBodegaNavigation)
                    .WithMany(p => p.Distribuidor)
                    .HasForeignKey(d => d.IdBodega)
                    .HasConstraintName("FK_Distribuidor_Bodega");

                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany(p => p.Distribuidor)
                    .HasForeignKey(d => d.IdSector)
                    .HasConstraintName("FK_Distribuidor_Sector1");
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdDocumento);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasKey(e => e.IdParametro)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PuntoCobertura>(entity =>
            {
                entity.HasKey(e => e.IdPuntoCobertura);

                entity.HasOne(d => d.IdCoberturaNavigation)
                    .WithMany(p => p.PuntoCobertura)
                    .HasForeignKey(d => d.IdCobertura)
                    .HasConstraintName("FK_PuntoCobertura_Cobertura");
            });

            modelBuilder.Entity<PuntoSector>(entity =>
            {
                entity.HasKey(e => e.IdPuntoSector);

                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany(p => p.PuntoSector)
                    .HasForeignKey(d => d.IdSector)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PuntoSector_Sector");
            });

            modelBuilder.Entity<Ruta>(entity =>
            {
                entity.HasKey(e => e.IdRuta)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdDistribuidorNavigation)
                    .WithMany(p => p.Ruta)
                    .HasForeignKey(d => d.IdDistribuidor)
                    .HasConstraintName("RefDistribuidor3");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.HasKey(e => e.IdSector);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(140)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Sector)
                    .HasForeignKey(d => d.IdCiudad)
                    .HasConstraintName("FK_Sector_Ciudad");
            });

            modelBuilder.Entity<SectorDistribuidor>(entity =>
            {
                entity.HasKey(e => e.IdSectorDistribuidor);

                entity.HasOne(d => d.IdDistribuidorNavigation)
                    .WithMany(p => p.SectorDistribuidor)
                    .HasForeignKey(d => d.IdDistribuidor)
                    .HasConstraintName("FK_SectorDistribuidor_Distribuidor");

                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany(p => p.SectorDistribuidor)
                    .HasForeignKey(d => d.IdSector)
                    .HasConstraintName("FK_SectorDistribuidor_Sector");
            });

            modelBuilder.Entity<TipoSuscripcion>(entity =>
            {
                entity.HasKey(e => e.IdTipoSuscripcion)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.IdTipoSuscripcion).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
