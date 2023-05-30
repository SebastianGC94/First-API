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
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = Lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = Lista });

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

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }
    }
}
