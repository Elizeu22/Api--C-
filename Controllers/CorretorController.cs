using Corretora.DB.CorretoraLista.DB;
using Corretora.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using EntityState = Microsoft.EntityFrameworkCore.EntityState;
using System.Linq;


namespace Corretora.Controllers
{
    public class CorretorController : ControllerBase
    {




        private readonly CorretoraContext _contextCorretor;

        public CorretorController(CorretoraContext context)
        {

            _contextCorretor = context;

        }



        [HttpPost("Corretor")]
        public async Task<ActionResult<Corretor>>
               PostCorretor(Corretor cadastro)
        {
            _contextCorretor.Corretores.Add(cadastro);
            await _contextCorretor.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCorretor), new { id = cadastro.idCorretor }, cadastro);
        }



        [HttpGet("Corretor")]
        public async Task<ActionResult<Corretor>>
        GetCorretor(int id)
        {
            var cnpjCorretor = await _contextCorretor.Corretores.FindAsync(id);

            if (cnpjCorretor == null)
            {
                return NotFound();
            }

            return cnpjCorretor;
        }




    }
}
