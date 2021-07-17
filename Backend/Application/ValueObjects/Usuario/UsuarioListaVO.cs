using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Application.ValueObjects.Usuario
{
    public class UsuarioListaVO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Escolaridade { get; set; }
    }
}
