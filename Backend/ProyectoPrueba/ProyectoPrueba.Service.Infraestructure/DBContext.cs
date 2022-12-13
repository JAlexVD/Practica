using Microsoft.EntityFrameworkCore;
using ProyectoPrueba.Service.Core.Entities;
using ProyectoPrueba.Service.Core.Entities.Base;
using ProyectoPrueba.Service.Infraestructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Service.Infraestructure
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options):base(options) { }
        public DbSet <Autor> Autor { get; set; }
        public DbSet <Libro> Libro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("practica");
            modelConfig(modelBuilder);
        }

        private void modelConfig(ModelBuilder modelBuilder)
        {
            new AutorConfiguration(modelBuilder.Entity<Autor>());
            new LibroConfiguration(modelBuilder.Entity<Libro>());

            modelBuilder.Entity<Autor>().ToTable("Autores");
            modelBuilder.Entity<Libro>().ToTable("Libros");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken=new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Updated = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
