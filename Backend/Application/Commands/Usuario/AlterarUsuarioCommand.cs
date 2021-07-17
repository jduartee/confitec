using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Application.Commands
{
    public class AlterarUsuarioCommand: IRequest
    {
        public AlterarUsuarioCommand(int id, string nome, string sobrenome, string email,DateTime dataNascimento, int escolaridadeId)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            EscolaridadeId = escolaridadeId;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int EscolaridadeId { get; private set; }
    }
}
