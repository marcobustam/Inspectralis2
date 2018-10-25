using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inspectral.Models
{
    public class Individualizacion
    {
        public int IndividualizacionID { get; set; }
        public string Tanque { get; set; }
        public string Comprador { get; set; }
        public string Fabricante { get; set; }
        public DateTime FechaFabricación { get; set; }
        public string Capacidad { get; set; }
        public string Material { get; set; }
        public string TipoTanque { get; set; }
        public string NormaReferencia { get; set; }
        public DateTime FechaInicioInspeccion { get; set; }
        public DateTime FechaTerminoInspeccion { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraTermino { get; set; }
    }
}
