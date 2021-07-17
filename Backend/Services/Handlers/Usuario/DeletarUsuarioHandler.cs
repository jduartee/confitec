using Confitec.Application.Commands;
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
    public class DeletarUsuarioHandler : IRequestHandler<DeletarUsuarioCommand>
    {

        private readonly ApplicationDbContext _context;

        public DeletarUsuarioHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _context.Usuarios.Where(x => x.UsuarioId == request.Id).FirstOrDefaultAsync();

            _context.Usuarios.Remove(usuario);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
