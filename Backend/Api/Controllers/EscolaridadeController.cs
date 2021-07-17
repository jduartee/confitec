using Confitec.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EscolaridadeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EscolaridadeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [Route("obter-escolaridade-ativa")]
        public async Task<IActionResult> ListarEscolaridadeAtiva()
        {
            try
            {
                return Ok(await _mediator.Send(new ObterEscolaridadeAtivaCommand()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
