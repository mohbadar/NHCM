using MediatR;
using Microsoft.EntityFrameworkCore;
using NHCM.Domain.Entities;
using NHCM.Persistence;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NHCM.Application.Lookup.Queries
{
    public class GetReportToQuery : IRequest<List<Position>>
    {
        public decimal? Id { get; set; }
        public int? organogramid { get; set; }
    }

    public class GetReportToHandler : IRequestHandler<GetReportToQuery, List<Position>>
    {
         private readonly HCMContext _dbContext;
        public GetReportToHandler(HCMContext context)
        {
            _dbContext = context;
        }
        public async Task<List<Position>> Handle(GetReportToQuery request, CancellationToken cancellationToken)
        {

            List<Position> list = new List<Position>();

            //if (request.Id == null || request.Id == default(short))
            //{


            //    list = await _dbContext.Position.ToListAsync(cancellationToken);

            //    return list;


            //}
            //else
            //{

            //    list = await _dbContext.Position.Where(p => p.Id == request.Id).ToListAsync(cancellationToken);
            //    return list;

            //}

             

            if (request.Id != null)
            {

                list = await _dbContext.Position.Where(p => p.Id == request.Id).ToListAsync(cancellationToken);
                return list;
            }
            else if (request.organogramid != null)
            {
                // Get List of Organiztin "Report to list" by parent id id
                list = await _dbContext.Position.Where(p => p.OrganoGramId == request.organogramid).ToListAsync(cancellationToken);
                return list;
            }
            else
            {

                list = await _dbContext.Position.ToListAsync(cancellationToken);
                return list;

            }


        }
    }
    
}
