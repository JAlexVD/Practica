using ProyectoPrueba.Service.Application.IRepositories;
using ProyectoPrueba.Service.Core.Entities;
using ProyectoPrueba.Service.Infraestructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Service.Infraestructure.Repositories
{
    public class AutorRepository: RepositoryBase<Autor>,IAutorRepository
    {
        public AutorRepository (DBContext dbcontext): base(dbcontext) { }
    }
}
