using System;
using System.Collections.Generic;

namespace Gestión_Puertas.Models.Data;

public partial class CfgTipoDispositivo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool EsAdam { get; set; }

    public bool EsCamara { get; set; }

    public bool EsKretaAcceso { get; set; }

    public bool EsKretaPresencia { get; set; }

    public bool EsContadorSiemens { get; set; }

    public bool EsConcentradorContadores { get; set; }

    public bool EsContadorGas { get; set; }

    public bool EsFlexyAcceso { get; set; }

    public virtual ICollection<CfgDispositivos> CfgDispositivos { get; } = new List<CfgDispositivos>();
}
