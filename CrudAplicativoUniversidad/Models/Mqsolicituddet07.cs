using System;
using System.Collections.Generic;

namespace CrudAplicativoUniversidad.Models;

public partial class Mqsolicituddet07
{
    public int Id07 { get; set; }

    public int IdSolicitud06 { get; set; }

    public int IdCurso02 { get; set; }

    public int IdProfesor04 { get; set; }

    public string Aula07 { get; set; } = null!;

    public string Sede07 { get; set; } = null!;

    public string Observacion07 { get; set; } = null!;

    public virtual Mdcursos02 IdCurso02Navigation { get; set; } = null!;

    public virtual Mdtrabajador04 IdProfesor04Navigation { get; set; } = null!;

    public virtual Mqsolicitudcab06 IdSolicitud06Navigation { get; set; } = null!;
}
