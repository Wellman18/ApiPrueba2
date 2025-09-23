using FinanzaPersonalAPI.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FinanzaPersonalAPI.Controllers
{
    [ApiController]
    [Route("")]

    public class UsuarioController : ControllerBase
    {
        IUsuario iusuario;

        public UsuarioController(IUsuario _usuario)
        {
            this.iusuario = _usuario;
        }

        [HttpPost]
        [Route("CrearUsuario")]

        public dynamic Datos([FromBody] Model.Usuario usuario)
        {
            try
            {
                var datosSerializados = JsonSerializer.Serialize(usuario);

                var datosModelo = JsonSerializer.Deserialize<Model.Usuario>(datosSerializados);

                iusuario.InsertarUsuario(datosModelo);

                return new
                {
                    success = true,
                    estado = StatusCode(200)
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    estado = ex.Message.ToString()
                };
            }




        }
    }
}
