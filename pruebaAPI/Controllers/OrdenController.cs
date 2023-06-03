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
    public class OrdenController : ControllerBase
    {
        public readonly DbApiContext _dbcontext;

        public OrdenController(DbApiContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Orden> Lista = new List<Orden>();
            try
            {
                Lista = _dbcontext.Ordens.Include(c => c.oUsuario).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se han listado correctamente las ordenes", response = Lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = Lista });

            }
        }

        [HttpGet]
        [Route("Obtener/{idOrden:int}")]
        public IActionResult Obtener(int idOrden)
        {
            Orden oOrden = _dbcontext.Ordens.Find(idOrden);

            if (oOrden == null)
            {
                return BadRequest("Orden no encontrada");

            }

            try
            {
                oOrden = _dbcontext.Ordens.Include(c => c.oUsuario).Where(p => p.IdOrden == idOrden).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Orden encontrada", response = oOrden });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oOrden });

            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Orden objeto)
        {

            try
            {
                _dbcontext.Ordens.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "La orden se guardó con exito" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Orden objeto)
        {
            Orden oOrden = _dbcontext.Ordens.Find(objeto.IdOrden);


            if (oOrden == null)
            {
                return BadRequest("Orden no encontrada");

            }

            try
            {
                oOrden.Descripcion = objeto.Descripcion is null ? oOrden.Descripcion : objeto.Descripcion;
                oOrden.Fecha = objeto.Fecha is null ? oOrden.Fecha : objeto.Fecha;
                oOrden.IdUsuario= objeto.IdUsuario is null ? oOrden.IdUsuario : objeto.IdUsuario;
                

                _dbcontext.Ordens.Update(oOrden);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se actualizó la información" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        [HttpDelete]
        [Route("Eliminar/{idOrden:int}")]
        public IActionResult Eliminar(int idOrden)
        {
            Orden oOrden = _dbcontext.Ordens.Find(idOrden);


            if (oOrden == null)
            {
                return BadRequest("Orden no encontrada");

            }

            try
            {
                _dbcontext.Ordens.Remove(oOrden);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se eliminó la orden" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }
    }
}
