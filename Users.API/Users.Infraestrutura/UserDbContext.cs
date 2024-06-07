using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Users.Domain.Entidades;

namespace Users.Infraestrutura
{
    public class UserDbContext  : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<User> Users { get; set; }

        public UserDbContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        //esse é o método de conexão com o banco
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var typeDatabase = _configuration["TypeDatabase"];
            var connectionString = _configuration.GetConnectionString(typeDatabase);

            if(typeDatabase == "SqlServer")
            {
                optionsBuilder.UseSqlServer(connectionString);//fazendo a conexão da string com o Builder
            }
        }
    }
}
