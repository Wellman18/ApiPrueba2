using FinanzaPersonalAPI.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzaPersonalAPI.DataAccess
{
    public class ConnectionManagerDbContext : DbContext, IConnectionManagerDbContext
    {
        public ConnectionManagerDbContext(DbContextOptions<ConnectionManagerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Model.Usuario> Usuarios { get; set; }
    }
}
