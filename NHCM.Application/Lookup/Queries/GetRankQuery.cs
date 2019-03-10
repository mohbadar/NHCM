using MediatR;
using NHCM.Domain.Entities;
using NHCM.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NHCM.Application.Lookup.Queries
{
    public class GetRankQuery : IRequest<List<Rank>>
    {
        public int? ID { get; set; }
    }
    public class GetRankQueryHandler : IRequestHandler<GetRankQuery, List<Rank>>
    {
        private HCMContext _context;
        public GetRankQueryHandler(HCMContext context)
        {
            _context = context;
        }

        public async Task<List<Rank>> Handle(GetRankQuery request, CancellationToken cancellationToken)
        {
            List<Rank> result = new List<Rank>();

            if (request.ID == null || request.ID == default(int)) result = await _context.Rank.ToListAsync(cancellationToken);
            else result = await _context.Rank.Where(e => e.Id == request.ID).ToListAsync(cancellationToken);


            return result;
        }
    }
}
