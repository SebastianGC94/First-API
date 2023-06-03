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
    public class DatosController : ControllerBase
    {
        public readonly DbApiContext _dbcontext;

        public DatosController(DbApiContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Datos> Lista = new List<Datos>();
            try
            {
                Lista = _dbcontext.Datos.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se han listado correctamente los datos", response = Lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = Lista });

            }
        }

        [HttpGet]
        [Route("Obtener/{idDatos:int}")]
        public IActionResult Obtener(int idDatos)
        {
            Datos oDatos = _dbcontext.Datos.Find(idDatos);

            if (oDatos == null)
            {
                return BadRequest("Dato no encontrado");

            }

            try
            {
                oDatos = _dbcontext.Datos.Where(p => p.IdDatos == idDatos).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Dato encontrado", response = oDatos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oDatos });

            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Datos objeto)
        {

            try
            {
                _dbcontext.Datos.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "El dato se guardó con exito" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Datos objeto)
        {
            Datos oDatos = _dbcontext.Datos.Find(objeto.IdDatos);


            if (oDatos == null)
            {
                return BadRequest("Dato no encontrado");

            }

            try
            {
                oDatos.Descripcion = objeto.Descripcion is null ? oDatos.Descripcion : objeto.Descripcion;


                _dbcontext.Datos.Update(oDatos);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se actualizó la información" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        [HttpDelete]
        [Route("Eliminar/{idDatos:int}")]
        public IActionResult Eliminar(int idDatos)
        {
            Datos oDatos = _dbcontext.Datos.Find(idDatos);


            if (oDatos == null)
            {
                return BadRequest("Dato no encontrado");

            }

            try
            {
                _dbcontext.Datos.Remove(oDatos);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se eliminó el dato" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }
    }
}
