using Confitec.Application.Commands;
using Confitec.Application.ValueObjects;
using Confitec.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Services.Handlers
{
    public class ObterUsuarioPorIdHandler : IRequestHandler<ObterUsuarioPorIdCommand, UsuarioPorIdVO>
    {
        private readonly ApplicationDbContext _context;

        public ObterUsuarioPorIdHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioPorIdVO> Handle(ObterUsuarioPorIdCommand request, CancellationToken cancellationToken)
        {
            return await _context.Usuarios
                .Include(x => x.Escolaridade)
                .Where(x => x.UsuarioId == request.Id)
                .Select(x => new UsuarioPorIdVO
                {
                    Id = x.UsuarioId,
                    Nome = x.Nome,
                    Sobrenome = x.Sobrenome,
                    Email= x.Email,
                    DataNascimento = x.DataNascimento,
                    EscolaridadeId = x.Escolaridade.EscolaridadeId
                }).FirstOrDefaultAsync();
        }
    }
}
