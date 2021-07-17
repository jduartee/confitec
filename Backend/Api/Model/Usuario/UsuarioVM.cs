using System;

namespace Confitec.Api.Model
{
    public class UsuarioVM
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }
    }
}
