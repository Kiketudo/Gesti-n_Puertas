using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Gestión_Puertas.Models.Data;

public partial class EntitiesContext : DbContext
{
    public EntitiesContext()
    {
    }

    public EntitiesContext(DbContextOptions<EntitiesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BPersonas> BPersonas { get; set; }

    public virtual DbSet<BTarjetasKimaldi> BTarjetasKimaldi { get; set; }

    public virtual DbSet<BZonas> BZonas { get; set; }

    public virtual DbSet<CfgDispositivos> CfgDispositivos { get; set; }

    public virtual DbSet<CfgTipoDispositivo> CfgTipoDispositivo { get; set; }

    public virtual DbSet<CpFichajes> CpFichajes { get; set; }

    public virtual DbSet<IPersonasAccesos> IPersonasAccesos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["EntitiesContext"].ConnectionString);
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseSqlServer("Server=srvbu-bd\\SQL2019;Database=itcl_presencia;User ID=itclpresencia;Password=presencia;Trusted_Connection=False;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BPersonas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Trabajadores");

            entity.ToTable("B_Personas");

            entity.HasIndex(e => e.Nombre, "UK_B_Personas_Nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodigoRfid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CodigoRFID");
            entity.Property(e => e.CodigoTarjeta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EsVisibleEnPanelOperador)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.FoCategoria).HasColumnName("Fo_Categoria");
            entity.Property(e => e.FoDepartamento).HasColumnName("Fo_Departamento");
            entity.Property(e => e.FoEmpresa).HasColumnName("Fo_Empresa");
            entity.Property(e => e.FoEquipoTrabajo).HasColumnName("Fo_EquipoTrabajo");
            entity.Property(e => e.FoGrupoVisita).HasColumnName("Fo_GrupoVisita");
            entity.Property(e => e.FoPerfil).HasColumnName("Fo_Perfil");
            entity.Property(e => e.FoTarjeta).HasColumnName("Fo_Tarjeta");
            entity.Property(e => e.FoZona).HasColumnName("Fo_Zona");
            entity.Property(e => e.Info).IsUnicode(false);
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MostrarComo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PuedeValidarAlarma)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.HasOne(d => d.FoZonaNavigation).WithMany(p => p.BPersonas)
                .HasForeignKey(d => d.FoZona)
                .HasConstraintName("FK_B_Personas_B_Zonas");
        });

        modelBuilder.Entity<BTarjetasKimaldi>(entity =>
        {
            entity.ToTable("B_TarjetasKimaldi");

            entity.Property(e => e.CodigoRfid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CodigoRFID");
            entity.Property(e => e.FlxUserId).HasColumnName("FlxUserID");
        });

        modelBuilder.Entity<BZonas>(entity =>
        {
            entity.ToTable("B_Zonas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EsZonaFisica)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Fbaja)
                .HasColumnType("smalldatetime")
                .HasColumnName("FBaja");
            entity.Property(e => e.FoArea).HasColumnName("Fo_Area");
            entity.Property(e => e.FoCalendario).HasColumnName("Fo_Calendario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CfgDispositivos>(entity =>
        {
            entity.ToTable("CFG_Dispositivos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Eui64)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("EUI64");
            entity.Property(e => e.FechaBaja).HasColumnType("datetime");
            entity.Property(e => e.FoFabricante).HasColumnName("Fo_Fabricante");
            entity.Property(e => e.FoTipoDispositivo).HasColumnName("Fo_TipoDispositivo");
            entity.Property(e => e.FoZona).HasColumnName("Fo_Zona");
            entity.Property(e => e.HorasEstablecerIncidenciaEntrada)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("A las horas definidas en este campo, separadas por ';', le estableceremos por código la incidencia de Entrada (emular el pulsar flecha verde del dispositivo kreta)");
            entity.Property(e => e.HorasEstablecerIncidenciaSalida)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("A las horas definidas en este campo, separadas por ';', le estableceremos por código la incidencia de Salida(emular el pulsar flecha roja del dispositivo kreta)");
            entity.Property(e => e.Ip)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("IP");
            entity.Property(e => e.MonitorizacionEsOk).HasDefaultValueSql("((0))");
            entity.Property(e => e.MonitorizacionFecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MonitorizacionTexto)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RutaGrabacion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UltimaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.FoTipoDispositivoNavigation).WithMany(p => p.CfgDispositivos)
                .HasForeignKey(d => d.FoTipoDispositivo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CFG_Dispositivos_CFG_TipoDispositivo");

            entity.HasOne(d => d.FoZonaNavigation).WithMany(p => p.CfgDispositivos)
                .HasForeignKey(d => d.FoZona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CFG_Dispositivos_Zonas");
        });

        modelBuilder.Entity<CfgTipoDispositivo>(entity =>
        {
            entity.ToTable("CFG_TipoDispositivo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CpFichajes>(entity =>
        {
            entity.ToTable("CP_Fichajes", tb => tb.HasTrigger("FichajesActualizaHoras"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DescripcionError)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaHoraEntrada).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraEntradaReal).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraEntradaTeorica).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraSalida).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraSalidaReal).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraSalidaTeorica).HasColumnType("datetime");
            entity.Property(e => e.FoDispositivo).HasColumnName("Fo_Dispositivo");
            entity.Property(e => e.FoEventoKretaModoEntrada)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FoEventoKretaModoSalida)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FoEventoKretaResultadoEntrada)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FoEventoKretaResultadoSalida)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FoPeriodoDiaCalendario).HasColumnName("Fo_PeriodoDiaCalendario");
            entity.Property(e => e.FoPeriodoDiaCalendarioTrabajador).HasColumnName("Fo_PeriodoDiaCalendarioTrabajador");
            entity.Property(e => e.FoPersonaReceptora).HasColumnName("Fo_PersonaReceptora");
            entity.Property(e => e.FoTipoIncidenciaEntrada).HasColumnName("Fo_TipoIncidenciaEntrada");
            entity.Property(e => e.FoTipoIncidenciaEntradaReal).HasColumnName("Fo_TipoIncidenciaEntradaReal");
            entity.Property(e => e.FoTipoIncidenciaSalida).HasColumnName("Fo_TipoIncidenciaSalida");
            entity.Property(e => e.FoTipoIncidenciaSalidaReal).HasColumnName("Fo_TipoIncidenciaSalidaReal");
            entity.Property(e => e.FoTipoMarcaje).HasColumnName("Fo_TipoMarcaje");
            entity.Property(e => e.FoTrabajador).HasColumnName("Fo_Trabajador");
            entity.Property(e => e.Horas).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.HorasExtra)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(9, 2)");
            entity.Property(e => e.HorasReal)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(9, 2)");
            entity.Property(e => e.HorasTeoricas).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.Tarjeta)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.FoDispositivoNavigation).WithMany(p => p.CpFichajes)
                .HasForeignKey(d => d.FoDispositivo)
                .HasConstraintName("FK_CP_Fichajes_CFG_Dispositivos");

            entity.HasOne(d => d.FoPersonaReceptoraNavigation).WithMany(p => p.CpFichajesFoPersonaReceptoraNavigation)
                .HasForeignKey(d => d.FoPersonaReceptora)
                .HasConstraintName("FK_CP_Fichajes_B_Personas_Receptora");

            entity.HasOne(d => d.FoTrabajadorNavigation).WithMany(p => p.CpFichajesFoTrabajadorNavigation)
                .HasForeignKey(d => d.FoTrabajador)
                .HasConstraintName("FK_CP_Fichajes_Trabajadores");
        });

        modelBuilder.Entity<IPersonasAccesos>(entity =>
        {
            entity.ToTable("I_Personas_Accesos");

            entity.HasIndex(e => new { e.FoDispositivo, e.FoPersona }, "UK_I_Personas_Accesos_Dispositivo_Persona").IsUnique();

            entity.Property(e => e.FoDispositivo).HasColumnName("Fo_Dispositivo");
            entity.Property(e => e.FoPersona).HasColumnName("Fo_Persona");

            entity.HasOne(d => d.FoDispositivoNavigation).WithMany(p => p.IPersonasAccesos)
                .HasForeignKey(d => d.FoDispositivo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_I_Personas_Accesos_CFG_Dispositivos");

            entity.HasOne(d => d.FoPersonaNavigation).WithMany(p => p.IPersonasAccesos)
                .HasForeignKey(d => d.FoPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_I_Personas_Accesos_B_Personas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
