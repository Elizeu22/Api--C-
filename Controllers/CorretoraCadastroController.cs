using Corretora.DB.CorretoraLista.DB;
using Corretora.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Corretora.Controllers
{
    public class CorretoraCadastroController : ControllerBase
    {

        private readonly CorretoraContext _context;

        public CorretoraCadastroController(CorretoraContext context)
        {

            _context = context;

        }


        [Authorize]
        [HttpGet("CorretoraCadastro")]
        public async Task<ActionResult<IEnumerable<CorretoraCadastro>>>
            GetTodos()
        {

            return await _context.Corretoras.ToListAsync();

        }

        [Authorize]
        [HttpGet("cnpj")]
        public async Task<ActionResult<CorretoraCadastro>>
           GetCorretora(string cnpj)
        {
            var cnpjCorretora = await _context.Corretoras.FirstOrDefaultAsync(c => c.cnpj == cnpj);

            if (cnpjCorretora.ToString() == "")
            {
                return NotFound();
            }

            return cnpjCorretora;
        }


        [HttpPost("CorretoraCadastro")]
        public async Task<ActionResult<CorretoraCadastro>>
            PostCorretora(CorretoraCadastro cadastro)
        {
            _context.Corretoras.Add(cadastro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCorretora), new { cnpj = cadastro.cnpj }, cadastro);
        }

        [Authorize]
        [HttpPut("cnpj")]
        public async Task<IActionResult>
            PutCorretora(string cnpj, CorretoraCadastro atualizaCorretora)
        {
            if (cnpj != atualizaCorretora.cnpj)
            {
                return BadRequest();
            }

            _context.Entry(atualizaCorretora).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }




        [Authorize]
        [HttpDelete("cnpj")]
        public async Task<ActionResult<CorretoraCadastro>>
         DeleteCorretora(string cnpj)
        {
            var cnpjCorretora = await _context.Corretoras.FirstOrDefaultAsync(c => c.cnpj == cnpj);

            if (cnpjCorretora.ToString() == "")
            {
                return NotFound();
            }

            _context.Corretoras.Remove(cnpjCorretora);

            await _context.SaveChangesAsync();

            return cnpjCorretora;
        }
    }
}
