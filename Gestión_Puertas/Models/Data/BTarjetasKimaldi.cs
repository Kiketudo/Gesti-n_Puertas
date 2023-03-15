using System;
using System.Collections.Generic;

namespace Gestión_Puertas.Models.Data;

public partial class BTarjetasKimaldi
{
    public int Id { get; set; }

    public string CodigoRfid { get; set; } = null!;

    public short FlxUserId { get; set; }
}
