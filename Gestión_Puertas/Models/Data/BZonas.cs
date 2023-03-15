using System;
using System.Collections.Generic;

namespace Gestión_Puertas.Models.Data;

public partial class BZonas
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int FoArea { get; set; }

    public int? FoCalendario { get; set; }

    public bool? EsZonaFisica { get; set; }

    public DateTime? Fbaja { get; set; }

    public virtual ICollection<BPersonas> BPersonas { get; } = new List<BPersonas>();

    public virtual ICollection<CfgDispositivos> CfgDispositivos { get; } = new List<CfgDispositivos>();
}
