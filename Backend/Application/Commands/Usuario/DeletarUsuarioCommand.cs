using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Application.Commands
{
    public class DeletarUsuarioCommand : IRequest
    {
        public DeletarUsuarioCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
