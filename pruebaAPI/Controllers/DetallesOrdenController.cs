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
    public class DetallesOrdenController : ControllerBase
    {
        public readonly DbApiContext _dbcontext;

        public DetallesOrdenController(DbApiContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<DetallesOrden> Lista = new List<DetallesOrden>();
            try
            {
                Lista = _dbcontext.DetallesOrdens.Include(c => c.oOrden).ToList();
                Lista = _dbcontext.DetallesOrdens.Include(c => c.oProducto).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se han listado correctamente los detalles", response = Lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = Lista });

            }
        }

        [HttpGet]
        [Route("Obtener/{idDetalle:int}")]
        public IActionResult Obtener(int idDetalle)
        {
            DetallesOrden oDetalle = _dbcontext.DetallesOrdens.Find(idDetalle);

            if (oDetalle == null)
            {
                return BadRequest("Detalle no encontrado");

            }

            try
            {
                oDetalle = _dbcontext.DetallesOrdens.Include(c => c.oProducto).Where(p => p.IdDetalle == idDetalle).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Detalle encontrado", response = oDetalle });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oDetalle });

            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] DetallesOrden objeto)
        {

            try
            {
                _dbcontext.DetallesOrdens.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "El detalle se guardó con exito" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] DetallesOrden objeto)
        {
            DetallesOrden oDetalle = _dbcontext.DetallesOrdens.Find(objeto.IdDetalle);


            if (oDetalle == null)
            {
                return BadRequest("detalle no encontrado");

            }

            try
            {
                oDetalle.IdOrden = objeto.IdOrden is null ? oDetalle.IdOrden : objeto.IdOrden;
                oDetalle.IdProducto = objeto.IdProducto is null ? oDetalle.IdProducto : objeto.IdProducto;
                oDetalle.Cantidad= objeto.Cantidad is null ? oDetalle.Cantidad : objeto.Cantidad;
                oDetalle.Precio = objeto.Precio is null ? oDetalle.Precio : objeto.Precio;



                _dbcontext.DetallesOrdens.Update(oDetalle);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se actualizó la información" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        [HttpDelete]
        [Route("Eliminar/{idDetalle:int}")]
        public IActionResult Eliminar(int idDetalle)
        {
            DetallesOrden oDetalle = _dbcontext.DetallesOrdens.Find(idDetalle);


            if (oDetalle == null)
            {
                return BadRequest("Detalle no encontrado");

            }

            try
            {
                _dbcontext.DetallesOrdens.Remove(oDetalle);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se eliminó el detalle" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }
    }
}
