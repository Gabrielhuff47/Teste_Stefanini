
using Api.Model;
using Api.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("Api/Usuario")]
public class AutenticacaoController : ControllerBase
{
    private readonly TokenServico _tokenServico;
    private readonly AutenticacaoServico _autenticaoServico;

    public AutenticacaoController(TokenServico tokenServico, AutenticacaoServico autenticacaoServico)
    {
        _tokenServico = tokenServico;
        _autenticaoServico = autenticacaoServico;
    }

    [HttpPost("Entrar")]
    public async Task<IActionResult> Login([FromBody] usuarioModel model)
    {
        var token = await _autenticaoServico.AutenticarUsuario(model);

        if (token == null)
        {
            return Unauthorized(new { message = "Usuário ou senha inválidos." });
        }
        return Ok(new { token = token });
    }
}
