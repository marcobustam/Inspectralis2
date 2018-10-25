using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inspectral.Models
{
    public class GaleriaImágenes
    {
        public int GaleriaImagenesID { get; set; }
        public string Titulo { get; set; }
    }
    public class Imagen
    {
        public int ImagenID { get; set; }
        public string Ubicacion { get; set; }
        public string Titular { get; set; }
        public string Descripcion { get; set; }
    }
}
