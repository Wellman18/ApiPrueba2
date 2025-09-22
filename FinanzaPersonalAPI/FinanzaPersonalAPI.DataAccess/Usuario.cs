using FinanzaPersonalAPI.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinanzaPersonalAPI.DataAccess
{


    public class Usuario : IUsuario
    {
        private readonly ConnectionManagerDbContext _context;

        public Usuario(ConnectionManagerDbContext context)
        {
            _context = context;
        }

        public void InsertarUsuario(Model.Usuario usuario)
        {
            _context.Database
                .ExecuteSqlInterpolated($"EXEC sp_Usuario_Insertar {usuario.Nombre}, {usuario.Correo}");
            //iusuario.InsertarUsuario(usuario);
        }
    }
}