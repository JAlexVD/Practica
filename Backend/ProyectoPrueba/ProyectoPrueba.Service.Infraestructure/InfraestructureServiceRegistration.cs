using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProyectoPrueba.Service.Application.IRepositories;
using ProyectoPrueba.Service.Application.IRepositories.Base;
using ProyectoPrueba.Service.Infraestructure.Repositories;
using ProyectoPrueba.Service.Infraestructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Service.Infraestructure
{
    public static class InfraestructureServiceRegistration
    {

        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsHistoryTable("__EFMigrationHistory")));
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IAutorRepository, AutorRepository>();

            return services;
        }
    }
}
