using System;
using System.Collections.Generic;

namespace CrudAplicativoUniversidad.Models;

public partial class Mdtipocolaborador03
{
    public int Id03 { get; set; }

    public string Tipo03 { get; set; } = null!;

    public virtual ICollection<Mdtrabajador04> Mdtrabajador04s { get; } = new List<Mdtrabajador04>();
}
