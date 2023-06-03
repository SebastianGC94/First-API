using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using pruebaAPI.Models;

using Microsoft.AspNetCore.Cors;



namespace pruebaAPI.Controllers
{
    [EnableCors("ReglasCors")]

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly DbApiContext _dbcontext;

        public UsuarioController(DbApiContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Usuario> Lista = new List<Usuario>();
            try
            {
                Lista = _dbcontext.Usuarios.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Listado generado correctamente", response = Lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = Lista });

            }
        }

        [HttpGet]
        [Route("Obtener/{idUsuario:int}")]
        public IActionResult Obtener(int idUsuario)
        {
            Usuario oUsuario = _dbcontext.Usuarios.Find(idUsuario);

            if (oUsuario == null)
            {
                return BadRequest("Usuario no encontrado");

            }

            try
            {
                oUsuario = _dbcontext.Usuarios.Where(p => p.IdUsuario == idUsuario).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Usuario encontrado", response = oUsuario });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oUsuario });

            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Usuario objeto)
        {

            try
            {
                _dbcontext.Usuarios.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se guardó el usuario" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Usuario objeto)
        {
            Usuario? oUsuario = _dbcontext.Usuarios.Find(objeto.IdUsuario);

            if (oUsuario == null)
            {
                return BadRequest("Usuario no encontrado");
            }

            try
               {
                oUsuario.Identificacion = objeto.Identificacion is null ? oUsuario.Identificacion : objeto.Identificacion;
                oUsuario.Nombre = objeto.Nombre is null ? oUsuario.Nombre : objeto.Nombre;
                oUsuario.Apellido = objeto.Apellido is null ? oUsuario.Apellido : objeto.Apellido;
                oUsuario.Direccion = objeto.Direccion is null ? oUsuario.Direccion : objeto.Direccion;
                oUsuario.Correo = objeto.Correo is null ? oUsuario.Correo : objeto.Correo;
                oUsuario.Telefono = objeto.Telefono is null ? oUsuario.Telefono : objeto.Telefono;


                _dbcontext.Usuarios.Update(oUsuario);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se actualizó la información" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        [HttpDelete]
        [Route("Eliminar/{idUsuario:int}")]
        public IActionResult Eliminar(int idUsuario)
        {
            Usuario oUsuario = _dbcontext.Usuarios.Find(idUsuario);


            if (oUsuario == null)
            {
                return BadRequest("Usuario no encontrado");

            }

            try
            {
                _dbcontext.Usuarios.Remove(oUsuario);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se eliminó el usuario" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }
    }
}
