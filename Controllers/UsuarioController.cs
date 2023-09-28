using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechChallenge.Models.Usuario;
using TechChallenge_Fiap_Soat4.Data;

namespace TechChallenge.Controllers
{
    [ApiController]
    [Route("api/v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<List<Usuario>> GetAsync()
        //{
        //    return null;
        //}

        //[HttpPost("cria")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<Usuario> PostAsync([FromBody] Pedido usuario)
        //{
        //    return null;
        //}

        //[HttpPut("atualiza/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<Usuario> PutAsync([FromRoute] int id, [FromBody] Usuario usuario)
        //{
        //    return null;
        //}

        //[HttpDelete("remove/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<Usuario> DeleteAsync([FromRoute] int id)
        //{
        //    return null;
        //}

        private readonly ApplicationDbContext _context;
        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        /// <summary>
        /// Retorna o Usuario conforme o ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string CPF)
        {
            var usuario = await _context.Usuario.FindAsync(CPF);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost("cria")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("atualiza/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Usuario>> PutUsuario(string CPF, Usuario usuario)
        {
            if (CPF != usuario.CPF)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(CPF))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("remove/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(string id)
        {
            return _context.Usuario.Any(e => e.CPF == id);
        }

    }
}
