using System;
using System.Collections.Generic;

namespace CrudAplicativoUniversidad.Models;

public partial class Mdcursos02
{
    public int Id02 { get; set; }

    public string Nombre02 { get; set; } = null!;

    public string Descripcion02 { get; set; } = null!;

    public int NroCreditos02 { get; set; }

    public int Activo02 { get; set; }

    public virtual ICollection<Mqsolicituddet07> Mqsolicituddet07s { get; } = new List<Mqsolicituddet07>();
}
