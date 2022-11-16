using System;
using System.Collections.Generic;

namespace CrudAplicativoUniversidad.Models;

public partial class Mdcarreras05
{
    public int Id05 { get; set; }

    public string Descripcion05 { get; set; } = null!;

    public virtual ICollection<Mqsolicitudcab06> Mqsolicitudcab06s { get; } = new List<Mqsolicitudcab06>();
}
