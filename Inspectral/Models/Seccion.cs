using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inspectral.Models
{
    public class Seccion
    {
        public int SeccionID { get; set; }
        public int Orden { get; set; }
        public string Titulo { get; set; }
        [DataType(DataType.Html)]
        public string Contenido { get; set; }
        public int InformeID { get; set; }

        public Seccion (int infId)
        {
            InformeID = infId;
            Titulo = "";
            Contenido = "";
        }
        public Seccion ()
        {
            InformeID = 0;
            Orden = 0;
            Titulo = "";
            Contenido = "";
        }
    }
}
