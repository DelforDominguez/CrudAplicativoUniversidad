using System;
using System.Collections.Generic;

namespace CrudAplicativoUniversidad.Models;

public partial class Mdtrabajador04
{
    public int Id04 { get; set; }

    public string Nombres04 { get; set; } = null!;

    public string Apellidos04 { get; set; } = null!;

    public int IdTipo03 { get; set; }

    public virtual Mdtipocolaborador03 IdTipo03Navigation { get; set; } = null!;

    public virtual ICollection<Mqsolicitudcab06> Mqsolicitudcab06s { get; } = new List<Mqsolicitudcab06>();

    public virtual ICollection<Mqsolicituddet07> Mqsolicituddet07s { get; } = new List<Mqsolicituddet07>();

}
