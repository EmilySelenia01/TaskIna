using inaApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Data
{
    public class ApplicationDbContext : DbContext {

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        //--------------------------------------------------------
        //entidades seteadas
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }


        //--------------------------------------------------------
        //fluent api funciona para definir nuestra BD

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
            //investigar el incluid para agregar el service y ver la categoria 
            base.OnModelCreating(modelBuilder);

            //un producto tiene una categoria y una categoria tiene muchos productos,
            //onDelete evita que si borro una categoria se borren los productos relacionados
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict);

        }//end METHOD 

    }//end CLASS

}//end NAMESPACE
