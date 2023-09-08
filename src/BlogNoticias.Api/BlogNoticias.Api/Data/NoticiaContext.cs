using BlogNoticias.Api.Data.Auth;
using BlogNoticias.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BlogNoticias.Api.Data
{
    public class NoticiaContext : DbContext
    {
        public NoticiaContext(DbContextOptions<NoticiaContext> options) : base(options)
        {
                
        }
               
        public DbSet<Noticia> Noticias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NoticiaContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public class YourDbContextFactory : IDesignTimeDbContextFactory<NoticiaContext>
        {
            public NoticiaContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<NoticiaContext>();
                optionsBuilder.UseSqlServer("Server=LAPTOP-9BD5LE14\\SQLEXPRESS;Database=db_noticias;Persist Security Info=True;User ID=fiap_user_pos;Password=IR3578#jr;TrustServerCertificate=True");
                return new NoticiaContext(optionsBuilder.Options);
            }
        }

    }
}
