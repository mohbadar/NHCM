using MediatR;
using Microsoft.EntityFrameworkCore;
using NHCM.Application.Employment.Models;
using NHCM.Persistence;
using NHCM.Persistence.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NHCM.Application.Employment.Queries
{
    public class GetIdentityCardsQuery: IRequest<List<SearchedIdentityCardModel>>
    {
        public long? Id { get; set; }
        public decimal PersonId { get; set; }
        public DateTime? ValidUpto { get; set; }
    }

    public class GetIdentityCardsQueryHandler : IRequestHandler<GetIdentityCardsQuery, List<SearchedIdentityCardModel>>
    {
        private readonly HCMContext _context;
        private readonly ICurrentUser _currentUser;
        public GetIdentityCardsQueryHandler(HCMContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }
        public async Task<List<SearchedIdentityCardModel>> Handle(GetIdentityCardsQuery request, CancellationToken cancellationToken)
        {

            List<SearchedIdentityCardModel> listOfCards = new List<SearchedIdentityCardModel>();

            if(request.Id != null && request.Id != default(long))
            {
                listOfCards = await (from c in _context.IdentityCard
                              where c.Id == request.Id
                              select new SearchedIdentityCardModel
                              {
                                  Id = c.Id,
                                  CardCode = c.CardCode,
                                  PersonId = c.PersonId,
                                  ValidUpto = c.ValidUpto,
                                  CardPrinted = c.CardPrinted
                              }).ToListAsync();
               
            }

            return listOfCards;
        }
    }
}
