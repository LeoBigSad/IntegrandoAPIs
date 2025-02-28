using Microsoft.AspNetCore.Mvc;
using Tarefa5.Domain.Models;
using Tarefa5.Domain.Interfaces.Service;

[ApiController]
[Route("api/[controller]")]
public class EnderecoController : ControllerBase
{
    private readonly IEnderecoService _enderecoService;

    public EnderecoController(IEnderecoService enderecoService)
    {
        _enderecoService = enderecoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var enderecos = await _enderecoService.BuscarTodosAsync();
        return Ok(enderecos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var endereco = await _enderecoService.BuscarPorIdAsync(id);
        return endereco == null ? NotFound() : Ok(endereco);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Endereco endereco)
    {
        if (endereco == null)
            return BadRequest("Dados inválidos.");

        var novoEndereco = await _enderecoService.CriarAsync(endereco);
        return CreatedAtAction(nameof(Get), new { id = novoEndereco.Id }, novoEndereco);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Endereco endereco)
    {
        if (endereco == null || endereco.Id != id)
            return BadRequest("Dados inválidos.");

        var enderecoAtualizado = await _enderecoService.AtualizarAsync(endereco);
        return Ok(enderecoAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var sucesso = await _enderecoService.DeletarAsync(id);
        return sucesso ? NoContent() : NotFound();
    }
}
