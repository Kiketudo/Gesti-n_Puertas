using System;
using System.Collections.Generic;

namespace Gestión_Puertas.Models.Data;

public partial class CpFichajes
{
    public int Id { get; set; }

    public int? FoDispositivo { get; set; }

    public int? FoTrabajador { get; set; }

    public string? Tarjeta { get; set; }

    public DateTime? FechaHoraEntrada { get; set; }

    public DateTime? FechaHoraSalida { get; set; }

    public int? Semana { get; set; }

    public int? FoTipoIncidenciaEntrada { get; set; }

    public int? FoTipoIncidenciaSalida { get; set; }

    public decimal? Horas { get; set; }

    public DateTime? FechaHoraEntradaTeorica { get; set; }

    public DateTime? FechaHoraSalidaTeorica { get; set; }

    public decimal? HorasTeoricas { get; set; }

    public decimal? HorasExtra { get; set; }

    public string? FoEventoKretaModoEntrada { get; set; }

    public string? FoEventoKretaResultadoEntrada { get; set; }

    public string? FoEventoKretaModoSalida { get; set; }

    public string? FoEventoKretaResultadoSalida { get; set; }

    public bool EsErroneo { get; set; }

    public int? FoPeriodoDiaCalendario { get; set; }

    public int? FoPeriodoDiaCalendarioTrabajador { get; set; }

    public string? DescripcionError { get; set; }

    public int? FoPersonaReceptora { get; set; }

    public bool EsVisita { get; set; }

    public DateTime? FechaHoraEntradaReal { get; set; }

    public DateTime? FechaHoraSalidaReal { get; set; }

    public bool EsFestivo { get; set; }

    public bool EsSabado { get; set; }

    public bool EsDomingo { get; set; }

    public int? DiaSemana { get; set; }

    public decimal? HorasReal { get; set; }

    public int? FoTipoMarcaje { get; set; }

    public int? FoTipoIncidenciaEntradaReal { get; set; }

    public int? FoTipoIncidenciaSalidaReal { get; set; }

    public bool EsExterno { get; set; }

    public virtual CfgDispositivos? FoDispositivoNavigation { get; set; }

    public virtual BPersonas? FoPersonaReceptoraNavigation { get; set; }

    public virtual BPersonas? FoTrabajadorNavigation { get; set; }
}
