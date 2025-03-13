using Microsoft.AspNetCore.Mvc;
using Tarefa5.Domain.Interfaces.Service;
using Tarefa5.Domain.Models;

namespace Tarefa5.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController(IPessoaService pessoaService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await pessoaService.BuscarTodosAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var pessoa = await pessoaService.BuscarPorIdAsync(id);
            return pessoa == null ? NotFound() : Ok(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pessoa pessoa) => Ok(await pessoaService.CriarAsync(pessoa));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Pessoa pessoa) => Ok(await pessoaService.AtualizarAsync(pessoa));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            var sucesso = await pessoaService.DeletarAsync(id);
            return sucesso ? Accepted() : NotFound();
        }
    }

}
