using Confitec.Application.Commands;
using Confitec.Domain.Entities;
using Confitec.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Services.Handlers
{
    public class CadastrarUsuarioHandler : IRequestHandler<CadastrarUsuarioCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CadastrarUsuarioHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var escolaridade = await _context.Escolaridades.Where(x => x.EscolaridadeId == request.EscolaridadeId).FirstOrDefaultAsync();
            var usuario = new Usuario(request.Nome, request.Sobrenome, request.Email, request.DataNascimento);

            usuario.SetarEscolaridade(escolaridade);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario.UsuarioId;
        }
    }
}
