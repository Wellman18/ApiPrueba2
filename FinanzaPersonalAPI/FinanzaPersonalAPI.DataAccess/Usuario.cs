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
            //_context.Database
            //    .ExecuteSqlInterpolated($"EXEC usp_Usuario_Insertar {usuario.Nombre}, {usuario.Correo}");
           
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            
            //iusuario.InsertarUsuario(usuario);
        }

        public void ModificarUsuario(Model.Usuario usuario)
        {
            _context.Database
                .ExecuteSqlInterpolated($"EXEC usp_Usuario_Modificar {usuario.Id}, {usuario.Nombre}, {usuario.Correo}");
            //iusuario.InsertarUsuario(usuario);
        }

        public void EliminarUsuario(Model.Usuario usuario)
        {
            _context.Database
                .ExecuteSqlInterpolated($"EXEC usp_Usuario_Eliminar {usuario.Id}");
            //iusuario.InsertarUsuario(usuario);
        }

        public IEnumerable<Model.Usuario> ListarUsuario()
        {
            //var listaUsuarios =  _context.Usuarios
            //                    .FromSqlInterpolated($"usp_Usuario_Listar {usuario}")
            //                    .ToList();

            var listaUsuarios= _context.Usuarios.ToList();

            return listaUsuarios;
        }
    }
}