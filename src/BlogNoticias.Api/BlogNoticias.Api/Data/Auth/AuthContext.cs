using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BlogNoticias.Api.Data.Auth
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public class YourDbContextFactory : IDesignTimeDbContextFactory<AuthContext>
        {
            public AuthContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AuthContext>();
                optionsBuilder.UseSqlServer("Server=LAPTOP-9BD5LE14\\SQLEXPRESS;Database=db_noticias;Persist Security Info=True;User ID=fiap_user_pos;Password=IR3578#jr;TrustServerCertificate=True");
                return new AuthContext(optionsBuilder.Options);
            }
        }

    }

}
