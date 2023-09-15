using inlock_codeFirst.Domains;
using Microsoft.EntityFrameworkCore;

namespace inlock_codeFirst.Context
{
    public class InLockContext : DbContext
    {
        public DbSet<EstudioDomain> Estudio { get; set; }

        public DbSet<JogoDomain> Jogo { get; set; }

        public DbSet<TipoUsuarioDomain> TipoUsuario { get; set; }

        public DbSet<UsuarioDomain> Usuario { get; set; }

        //define as opcoes de construcao do banco(StringConexao)

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE22-S15;Database=InLock_CodeFirst_Manha;User Id=sa; Pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);

        }
    }
}
