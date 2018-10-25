using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inspectral.Models
{
    public class Informe
    {
        public int InformeID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CodigoSEC { get; set; }
        public string Titulo { get; set; }
        public Individualizacion Individualizacion { get; set; }
        public int IndividualizacionID { get; set; }
        public IList<Seccion> Secciones { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
