using System;
using System.Collections.Generic;

namespace Gestión_Puertas.Models.Data;

public partial class BPersonas
{
    public int Id { get; set; }

    public int? FoEquipoTrabajo { get; set; }

    public int? FoPerfil { get; set; }

    public string Nombre { get; set; } = null!;

    public string? MostrarComo { get; set; }

    public bool EsUsuario { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? CodigoRfid { get; set; }

    public bool EsBaja { get; set; }

    public bool EsVisita { get; set; }

    public string? Dni { get; set; }

    public int? FoEmpresa { get; set; }

    public int? FoGrupoVisita { get; set; }

    public int? FoDepartamento { get; set; }

    public bool EsResponsableDepartamento { get; set; }

    public bool EsResponsableEquipoTrabajo { get; set; }

    public int? FoCategoria { get; set; }

    public bool? PuedeValidarAlarma { get; set; }

    public int? FoZona { get; set; }

    public string CodigoTarjeta { get; set; } = null!;

    public string? Info { get; set; }

    public bool EsOculta { get; set; }

    public bool EsContrata { get; set; }

    public string? Email { get; set; }

    public bool? EsVisibleEnPanelOperador { get; set; }

    public int? FoTarjeta { get; set; }

    public virtual ICollection<CpFichajes> CpFichajesFoPersonaReceptoraNavigation { get; } = new List<CpFichajes>();

    public virtual ICollection<CpFichajes> CpFichajesFoTrabajadorNavigation { get; } = new List<CpFichajes>();

    public virtual BZonas? FoZonaNavigation { get; set; }

    public virtual ICollection<IPersonasAccesos> IPersonasAccesos { get; } = new List<IPersonasAccesos>();
}
