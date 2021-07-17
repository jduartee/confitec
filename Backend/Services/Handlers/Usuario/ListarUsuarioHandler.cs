using Confitec.Application.Commands;
using Confitec.Application.ValueObjects.Usuario;
using Confitec.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Services.Handlers
{
    public class ListarUsuarioHandler : IRequestHandler<ListarUsuarioCommand, List<UsuarioListaVO>>
    {
        private readonly ApplicationDbContext _context;

        public ListarUsuarioHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UsuarioListaVO>> Handle(ListarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var query = _context.Usuarios.Include(x => x.Escolaridade);

            if (!string.IsNullOrWhiteSpace(request.NomeCompleto))
            {
                query.Where(x => x.Nome.ToLower().Contains(request.NomeCompleto.ToLower()));
            }

            return await query.Select(x => new UsuarioListaVO
            {
                Id = x.UsuarioId,
                NomeCompleto = $"{x.Nome} {x.Sobrenome}",
                DataNascimento = x.DataNascimento,
                Email = x.Email,
                Escolaridade = x.Escolaridade.Descricao
            }).ToListAsync();
        }
    }
}
