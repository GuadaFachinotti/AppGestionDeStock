using Gestion.Core.Configuration;
using Gestion.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestion.Core.Data
{
    internal class GestionContext : DbContext

    {
        private readonly Config _config;

        public GestionContext(Config config)
        {
            _config = config;
        }



        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.ConnectionString);
        }

        /*
  
         El método OnModelCreating y las configuraciones dentro de él son utilizados para configurar el modelo de datos 
         cuando se está creando el contexto de base de datos. 
         La configuración específica que has mencionado define explícitamente la relación entre las entidades Bueno y Jedi.
          modelBuilder.Entity<Venta>(): Esto especifica que estás configurando la entidad Venta.

         .HasOne(v => v.Producto): Esto define que la entidad Venta tiene una relación uno-a-uno o uno-a-muchos con la entidad Producto. 
          En este caso, v => v.Producto especifica la propiedad de navegación en la entidad Venta que hace referencia a la entidad Producto.

         .WithMany(): Esto especifica que la entidad Jedi puede estar relacionada con muchas instancias de la entidad Bueno. 
          La relación es uno-a-muchos.

         .HasForeignKey(v => v.ProductoId): Esto define que la relación entre Venta y Producto utiliza una clave foránea (Foreign Key). 
          En este caso, la propiedad ProductoId en la entidad Venta actúa como la clave foránea que referencia la clave primaria de la entidad 
          Producto.

         En resumen, este código asegura que cada instancia de Venta tiene una referencia a una instancia de Producto a través de 
         la propiedad ProductoId, y que una instancia de Producto puede estar asociada a múltiples instancias de Venta. 
         Esta configuración explícita puede ayudar a evitar errores y asegurar que las relaciones 
         entre las entidades se configuren correctamente, especialmente si las convenciones predeterminadas de Entity Framework 
         no se aplican de manera adecuada.
  
 
         No es absolutamente necesario anotar la relación en el método OnModelCreating, 
         ya que Entity Framework suele inferir las relaciones correctamente a partir de las convenciones de nomenclatura y tipos de datos. 
         Sin embargo, definir explícitamente las relaciones puede ayudarte a evitar errores 
         y asegurar que las relaciones se configuren correctamente, 
         especialmente si las convenciones no se cumplen o si tienes configuraciones más complejas.
          */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //--------------Venta-----------------------------------
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Producto)    //Propiedad de navegación dentro de Venta que hace referencia al producto
                .WithMany()                 //producto tiene muchas ventas
                .HasForeignKey(v => v.ProductoId);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Usuario)    //Propiedad de navegación dentro de Venta que hace referencia al Usuario
                .WithMany()                //Usuario tiene muchas ventas
                .HasForeignKey(v => v.UsuarioId);
            //--------------Compra-----------------------------------
            modelBuilder.Entity<Compra>()
               .HasOne(v => v.Producto)    //Propiedad de navegación dentro de Compra que hace referencia al producto
               .WithMany()                 //producto tiene muchas Compra
               .HasForeignKey(v => v.ProductoId);

            modelBuilder.Entity<Compra>()
                .HasOne(v => v.Usuario)    //Propiedad de navegación dentro de Compra que hace referencia al Usuario
                .WithMany()                //Usuario tiene muchas Compras
                .HasForeignKey(v => v.UsuarioId);

            //--------------Producto-----------------------------------
            modelBuilder.Entity<Producto>()
               .HasOne(v => v.Categoria)    //Propiedad de navegación dentro de Producto que hace referencia a la Categoría
               .WithMany()                 //Categoría tiene muchos Productos
               .HasForeignKey(v => v.CategoriaId);

        }

    }
}
