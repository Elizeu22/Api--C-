namespace Corretora.DB
{
    using Corretora.Model;
    using Microsoft.EntityFrameworkCore;


    namespace CorretoraLista.DB
    {
        public class CorretoraContext : DbContext
        {

            public CorretoraContext(DbContextOptions<CorretoraContext> options) : base(options) { }

            public DbSet<CorretoraCadastro> Corretoras { get; set; }

            public DbSet<Corretor> Corretores { get; set; }


        



        }
    }



}

