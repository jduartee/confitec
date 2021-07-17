using Confitec.Application.Commands;
using Confitec.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Services.Handlers
{
    public class AlterarUsuarioHandler : IRequestHandler<AlterarUsuarioCommand>
    {
        private readonly ApplicationDbContext _context;

        public AlterarUsuarioHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AlterarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var escolaridade = await _context.Escolaridades.Where(x => x.EscolaridadeId == request.EscolaridadeId).FirstOrDefaultAsync();
            var usuario = await _context.Usuarios.Where(x => x.UsuarioId == request.Id).FirstOrDefaultAsync();

            usuario.Atualizar(request.Nome, request.Sobrenome, request.Email, request.DataNascimento, escolaridade);

            _context.Update(usuario);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
