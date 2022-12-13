using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Service.Core.Entities.Base
{
    public class EntityBase
    {
        public DateTime Created { get; set; }

        public DateTime ? Updated { get; set; }

        public DateTime ? Deleted { get; set; }
    }
}
