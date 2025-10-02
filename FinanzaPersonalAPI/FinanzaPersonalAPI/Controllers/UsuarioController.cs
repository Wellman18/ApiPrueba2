using FinanzaPersonalAPI.BusinessLogic.Interface;
using FinanzaPersonalAPI.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FinanzaPersonalAPI.Controllers
{
    [ApiController]
    [Route("")]

    public class UsuarioController : ControllerBase
    {
        IUsuario iusuario;
        IEnumerable<Model.Usuario> listaUsuarios = Enumerable.Empty<Model.Usuario>();
        private readonly ConnectionManagerDbContext _context;

        public UsuarioController(IUsuario _usuario, ConnectionManagerDbContext context)
        {
            this.iusuario = _usuario;
            this._context = context;
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

                var _usuario = _context.Usuarios.Find(usuario.Id);

                if (_usuario != null)
                {
                    _usuario.Nombre= usuario.Nombre;
                    _usuario.Correo= usuario.Correo;
                }

                iusuario.ModificarUsuario(_usuario);

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

                var _usuario = _context.Usuarios.Find(usuario.Id);

                iusuario.EliminarUsuario(_usuario);

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
