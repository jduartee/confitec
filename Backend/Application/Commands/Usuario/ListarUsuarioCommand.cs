using Confitec.Application.ValueObjects.Usuario;
using MediatR;
using System;
using System.Collections.Generic;

namespace Confitec.Application.Commands
{
    public class ListarUsuarioCommand: IRequest<List<UsuarioListaVO>>
    {
        public ListarUsuarioCommand(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;
        }

        public string NomeCompleto { get; private set; }
    }
}
