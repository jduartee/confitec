using Confitec.Application.Commands;
using Confitec.Application.ValueObjects;
using Confitec.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Services.Handlers.Escolaridade
{
    public class ObterEscolaridadeAtivaHandler : IRequestHandler<ObterEscolaridadeAtivaCommand, List<EscolaridadeVO>>
    {
        private readonly ApplicationDbContext _context;

        public ObterEscolaridadeAtivaHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EscolaridadeVO>> Handle(ObterEscolaridadeAtivaCommand request, CancellationToken cancellationToken)
        {
            return await _context.Escolaridades.Where(x => x.Ativo == true).Select(x=> new EscolaridadeVO { Id = x.EscolaridadeId, Descricao = x.Descricao})
                .ToListAsync();
        }
    }
}
