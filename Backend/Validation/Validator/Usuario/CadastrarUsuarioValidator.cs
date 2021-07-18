using Confitec.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Validation.Validator.Usuario
{
    public class CadastrarUsuarioValidator : AbstractValidator<CadastrarUsuarioCommand>
    {
        public CadastrarUsuarioValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome é obrigatório")
                .MaximumLength(75)
                .WithMessage("O nome não pode ultrapassar 75 caracteres.");

            RuleFor(x => x.Sobrenome)
                .NotEmpty()
                .WithMessage("O Sobrenome é obrigatório")
                .MaximumLength(100)
                .WithMessage("O Sobrenome não pode ultrapassar 100 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O E-mail é obrigatório")
                .MaximumLength(150)
                .WithMessage("O E-mail não pode ultrapassar 150 caracteres.");

            RuleFor(x => x.DataNascimento)
                .GreaterThan(DateTime.Today)
                .WithMessage("A data de nascimento não pode ser superior a atual.");

            RuleFor(x => x.EscolaridadeId)
                .Equal(0)
                .WithMessage("A Escolaridade é obrigatória.");
        }
    }
}
