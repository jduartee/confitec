using Confitec.Application.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Application.Commands
{
    public class ObterUsuarioPorIdCommand : IRequest<UsuarioPorIdVO>
    {
        public ObterUsuarioPorIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
