using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NHCM.Domain.Entities;
using NHCM.Persistence;
using Microsoft.EntityFrameworkCore;

namespace NHCM.Application.Lookup.Queries
{

    /// <summary>
    /// This request only includes the language id. If provided, the specific lanaugage will be returned as response. If not provided
    /// all the languages will be returned.
    /// </summary>
    public class GetWorkAreaQuery : IRequest<List<WorkArea>>
    {
       
        public int? ID { get; set; }
    }

    public class GetWorkAreaQueryHandler : IRequestHandler<GetWorkAreaQuery, List<WorkArea>>
    {
        private readonly HCMContext _dbContext;
        public GetWorkAreaQueryHandler(HCMContext context)
        {
            _dbContext = context;
        }


        public async Task<List<WorkArea>> Handle(GetWorkAreaQuery request, CancellationToken cancellationToken)
        {
            List<WorkArea> resultlist = new List<WorkArea>();

            if (request.ID != null)
            {
                // Return specific language.
                resultlist = await _dbContext.WorkArea.Where(l => l.Id == request.ID).ToListAsync(cancellationToken);
                return resultlist;
            }
            else
            {
                // Return all languages.
                resultlist = await _dbContext.WorkArea.ToListAsync(cancellationToken);
                return resultlist;

            }


        }
    }
}
