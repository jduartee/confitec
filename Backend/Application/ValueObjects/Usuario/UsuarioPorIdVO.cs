using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Application.ValueObjects
{
    public class UsuarioPorIdVO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }
    }
}
