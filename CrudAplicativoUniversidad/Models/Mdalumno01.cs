using System;
using System.Collections.Generic;

namespace CrudAplicativoUniversidad.Models;

public partial class Mdalumno01
{
    public int Id01 { get; set; }

    public string Nombres01 { get; set; } = null!;

    public string Apellidos01 { get; set; } = null!;

    public virtual ICollection<Mqsolicitudcab06> Mqsolicitudcab06s { get; } = new List<Mqsolicitudcab06>();
}
