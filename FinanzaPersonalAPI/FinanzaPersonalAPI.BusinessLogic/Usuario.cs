using FinanzaPersonalAPI.BusinessLogic.Interface;
using FinanzaPersonalAPI.DataAccess.Interface;

namespace FinanzaPersonalAPI.BusinessLogic
{
    public class Usuario : BusinessLogic.Interface.IUsuario
    {
        private readonly DataAccess.Interface.IUsuario iusuario;


        public Usuario(DataAccess.Interface.IUsuario _iusuario)
        {
            this.iusuario= _iusuario;
        }


        public void InsertarUsuario(Model.Usuario usuario)
        {
            iusuario.InsertarUsuario(usuario);
        }
    }
}