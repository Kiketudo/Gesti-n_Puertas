using System;
using System.Collections.Generic;

namespace Gestión_Puertas.Models.Data;

public partial class CfgDispositivos
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? SolicitudActualizacion { get; set; }

    public int FoZona { get; set; }

    public int FoTipoDispositivo { get; set; }

    public string? Ip { get; set; }

    public DateTime? FechaBaja { get; set; }

    public bool? MonitorizacionEsOk { get; set; }

    public DateTime? MonitorizacionFecha { get; set; }

    public string? MonitorizacionTexto { get; set; }

    public int? MinutosCiclo { get; set; }

    public int? MinutosCortesia { get; set; }

    public string? RutaGrabacion { get; set; }

    public bool? DetectarMovimiento { get; set; }

    public DateTime? UltimaActualizacion { get; set; }

    public int? DiasConservacionVideos { get; set; }

    public int? SegundosHastaAlarma { get; set; }

    public int? SegundosReleApertura { get; set; }

    public int? SegundosDuracionAlarma { get; set; }

    public bool? EsSumarConsumoTotal { get; set; }

    public bool EsOcultarEnInformes { get; set; }

    public int Puerto { get; set; }

    public string? Usuario { get; set; }

    public string? Pass { get; set; }

    public int? FrameRate { get; set; }

    public int? KretaAsociado { get; set; }

    public int? FoFabricante { get; set; }

    /// <summary>
    /// A las horas definidas en este campo, separadas por &apos;;&apos;, le estableceremos por código la incidencia de Entrada (emular el pulsar flecha verde del dispositivo kreta)
    /// </summary>
    public string? HorasEstablecerIncidenciaEntrada { get; set; }

    /// <summary>
    /// A las horas definidas en este campo, separadas por &apos;;&apos;, le estableceremos por código la incidencia de Salida(emular el pulsar flecha roja del dispositivo kreta)
    /// </summary>
    public string? HorasEstablecerIncidenciaSalida { get; set; }

    public string? Eui64 { get; set; }

    public virtual ICollection<CpFichajes> CpFichajes { get; } = new List<CpFichajes>();

    public virtual CfgTipoDispositivo FoTipoDispositivoNavigation { get; set; } = null!;

    public virtual BZonas FoZonaNavigation { get; set; } = null!;

    public virtual ICollection<IPersonasAccesos> IPersonasAccesos { get; } = new List<IPersonasAccesos>();
}
