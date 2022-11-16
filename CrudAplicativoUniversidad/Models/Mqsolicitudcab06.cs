using System;
using System.Collections.Generic;

namespace CrudAplicativoUniversidad.Models;

public partial class Mqsolicitudcab06
{
    public int Id06 { get; set; }

    public int IdAlumno01 { get; set; }

    public DateTime FechaSolicitud06 { get; set; }

    public int IdRegistrante04 { get; set; }

    public int Carrera05 { get; set; }

    public string Periodo06 { get; set; } = null!;

    public virtual Mdcarreras05 Carrera05Navigation { get; set; } = null!;

    public virtual Mdalumno01 IdAlumno01Navigation { get; set; } = null!;

    public virtual Mdtrabajador04 IdRegistrante04Navigation { get; set; } = null!;

    public virtual ICollection<Mqsolicituddet07> Mqsolicituddet07s { get; } = new List<Mqsolicituddet07>();
}
