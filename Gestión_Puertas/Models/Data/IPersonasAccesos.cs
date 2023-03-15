using System;
using System.Collections.Generic;

namespace Gestión_Puertas.Models.Data;

public partial class IPersonasAccesos
{
    public int Id { get; set; }

    public int FoPersona { get; set; }

    public int FoDispositivo { get; set; }

    public bool TieneAcceso { get; set; }

    public virtual CfgDispositivos FoDispositivoNavigation { get; set; } = null!;

    public virtual BPersonas FoPersonaNavigation { get; set; } = null!;
}
