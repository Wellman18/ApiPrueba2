using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzaPersonalAPI.Model;

namespace FinanzaPersonalAPI.BusinessLogic.Interface
{
    public interface IUsuario
    {
        void InsertarUsuario(Usuario usuario);

        void ModificarUsuario(Usuario usuario);

        IEnumerable<Usuario> ListarUsuario();
    }
}
