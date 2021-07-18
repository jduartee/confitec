using Confitec.Api.Model;
using Confitec.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("incluir-usuario")]
        public async Task<ActionResult> Incluir([FromBody] UsuarioVM model)
        {
            try
            {
                var result = await _mediator.Send(new CadastrarUsuarioCommand(model.Nome, model.Sobrenome, model.Email, model.DataNascimento, model.EscolaridadeId)).ConfigureAwait(false);

                if (result.Errors.Any())
                {
                    return BadRequest(result.Errors);
                }


                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("alterar-usuario/{id}")]
        public async Task<ActionResult> Alterar(int id, UsuarioVM model)
        {
            try
            {
                var result = await _mediator.Send(new AlterarUsuarioCommand(id, model.Nome, model.Sobrenome, model.Email, model.DataNascimento, model.EscolaridadeId));
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet()]
        [Route("listar-usuarios/{id}")]
        public async Task<ActionResult> Obter(int id)
        {
            try
            {
                var result = await _mediator.Send(new ObterUsuarioPorIdCommand(id));
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet()]
        [Route("listar-usuarios")]
        public async Task<ActionResult> ObterUsuarios(string nomeCompleto)
        {
            try
            {
                var result = await _mediator.Send(new ListarUsuarioCommand(nomeCompleto));
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("deletar-usuario/{id}")]
        public async Task<ActionResult> DeletarUsuario(int id)
        {
            try
            {
                return Ok(await _mediator.Send(new DeletarUsuarioCommand(id)));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
