using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoPrueba.Service.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Service.Infraestructure.Configuration
{
    public class LibroConfiguration
    {
        public LibroConfiguration(EntityTypeBuilder<Libro> entityTypeBuilder) { 
        
            entityTypeBuilder.HasKey(x => x.LibroId);
           
        }
    }
}
