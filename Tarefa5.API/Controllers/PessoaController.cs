using Microsoft.AspNetCore.Mvc;
using Tarefa5.Domain.Interfaces.Service;
using Tarefa5.Domain.Models;

namespace Tarefa5.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _pessoaService.BuscarTodosAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var pessoa = await _pessoaService.BuscarPorIdAsync(id);
            return pessoa == null ? NotFound() : Ok(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pessoa pessoa) => Ok(await _pessoaService.CriarAsync(pessoa));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Pessoa pessoa) => Ok(await _pessoaService.AtualizarAsync(pessoa));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) => Ok(await _pessoaService.DeletarAsync(id));
    }

}
