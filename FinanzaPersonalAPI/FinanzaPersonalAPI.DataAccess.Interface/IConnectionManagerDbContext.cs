using FinanzaPersonalAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzaPersonalAPI.DataAccess.Interface
{
    public interface IConnectionManagerDbContext 
    {
        DbSet<Usuario> Usuarios { get; set; }
    }
}
