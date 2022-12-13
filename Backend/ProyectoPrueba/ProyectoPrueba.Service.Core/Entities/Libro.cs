using ProyectoPrueba.Service.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Service.Core.Entities
{
    public class Libro: EntityBase
    {
        public Guid LibroId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Version { get; set; }
        public Guid AutorId { get; set; }
        public Autor Autor {get; set;}

    }
}
