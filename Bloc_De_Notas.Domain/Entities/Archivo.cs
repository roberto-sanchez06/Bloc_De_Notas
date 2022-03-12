using System;
using System.Collections.Generic;
using System.Text;

namespace Bloc_De_Notas.Domain.Entities
{
    public class Archivo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Ruta  { get; set; }
        public string Contenido { get; set; }
    }
}
