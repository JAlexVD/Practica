using ProyectoPrueba.Service.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Service.Core.Entities
{
    public class Autor: EntityBase
    {
        public Guid AutorId { get; set; }
        public string Nombre { get; set; }
        public string Doi { get; set; }
        public string Apellidos { get; set; }
        public string FechaNacimiento { get; set; }

    }
}
