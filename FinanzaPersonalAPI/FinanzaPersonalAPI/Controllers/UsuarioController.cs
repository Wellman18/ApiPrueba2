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
        IEnumerable<Model.Usuario> listaUsuarios = Enumerable.Empty<Model.Usuario>();

        public UsuarioController(IUsuario _usuario)
        {
            this.iusuario = _usuario;
        }

        [HttpPost]
        [Route("CrearUsuario")]

        public async Task<ActionResult> CrearUsuario([FromBody] Model.Usuario usuario)
        {
            try
            {
                //var datosSerializados = JsonSerializer.Serialize(usuario);

                //var datosModelo = JsonSerializer.Deserialize<Model.Usuario>(datosSerializados);

                iusuario.InsertarUsuario(usuario);

                return Ok( new
                {
                    success = true,
                    estado = StatusCode(200)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    estado = ex.Message.ToString()
                });
            }
        }

        [HttpPost]
        [Route("ModificarUsuario")]

        public async Task<ActionResult> ModificarUsuario([FromBody] Model.Usuario usuario)
        {
            try
            {
                //var datosSerializados = JsonSerializer.Serialize(usuario);

                //var datosModelo = JsonSerializer.Deserialize<Model.Usuario>(datosSerializados);

                iusuario.ModificarUsuario(usuario);

                return Ok(new
                {
                    success = true,
                    estado = StatusCode(200)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    estado = ex.Message.ToString()
                });
            }
        }


        [HttpPost]
        [Route("EliminarUsuario")]

        public async Task<ActionResult> EliminarUsuario([FromBody] Model.Usuario usuario)
        {
            try
            {
                //var datosSerializados = JsonSerializer.Serialize(usuario);

                //var datosModelo = JsonSerializer.Deserialize<Model.Usuario>(datosSerializados);

                iusuario.EliminarUsuario(usuario);

                return Ok(new
                {
                    success = true,
                    estado = StatusCode(200)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    estado = ex.Message.ToString()
                });
            }
        }




        [HttpGet]
        [Route("ObtenerUsuario")]

        public async Task<IEnumerable<Model.Usuario>> ObtenerUsuario()
        {
            try
            {
                //usuario = usuario?.Trim();

                listaUsuarios= iusuario.ListarUsuario();

                return listaUsuarios;
            }
            catch (Exception ex)
            {
                return listaUsuarios;
            }

        }

        //public async Task<ActionResult<IEnumerable<Model.Usuario>> ObtenerUsuario([FromBody] Model.Usuario usuario)
        //{
        //    try
        //    {
        //        var datosSerializados = JsonSerializer.Serialize(usuario);

        //        var datosModelo = JsonSerializer.Deserialize<Model.Usuario>(datosSerializados);

        //        iusuario.InsertarUsuario(datosModelo);

        //        return new
        //        {
        //            success = true,
        //            estado = StatusCode(200)
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new
        //        {
        //            success = false,
        //            estado = ex.Message.ToString()
        //        };
        //    }
        //}


    }
}
