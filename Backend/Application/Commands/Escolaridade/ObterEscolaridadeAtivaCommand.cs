using Confitec.Application.ValueObjects;
using MediatR;
using System.Collections.Generic;

namespace Confitec.Application.Commands
{
    public class ObterEscolaridadeAtivaCommand : IRequest<List<EscolaridadeVO>>
    {
    }
}
