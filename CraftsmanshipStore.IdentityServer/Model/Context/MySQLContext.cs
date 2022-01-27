using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CraftsmanshipStore.IdentityServer.Model.Context
{
    public class MySQLContext : IdentityDbContext<ApplicationUser>
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = @"Server=localhost;DataBase=craftsmanship_identity_server;Uid=root;Pwd=0v0AWkBn";

            optionsBuilder.UseMySql(conn, new MySqlServerVersion(new Version(8, 0, 5)));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
