using MediatR;
using NHCM.Application.Employment.Models;
using NHCM.Application.Employment.Queries;
using NHCM.Application.Infrastructure.Exceptions;
using NHCM.Domain.Entities;
using NHCM.Persistence;
using NHCM.Persistence.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NHCM.Application.Employment.Commands
{
   public  class SetIdentityCardCommand : IRequest<List<SearchedIdentityCardModel>>
    {

        public long Id { get; set; }
        public string CardCode { get; set; }
        public decimal PersonId { get; set; }
        public DateTime? ValidUpto { get; set; }
        public string PhotoPath { get; set; }
       // public bool? CardPrinted { get; set; }
    }
    public class SetIdentityCardCommandHandler : IRequestHandler<SetIdentityCardCommand, List<SearchedIdentityCardModel>>
    {
        private readonly HCMContext _context;
        private readonly ICurrentUser _currentUser;
        private readonly IMediator _mediator;
        public SetIdentityCardCommandHandler(HCMContext context, ICurrentUser currentUser, IMediator mediator)
        {
            _context = context;
            _currentUser = currentUser;
            _mediator = mediator;
        }
        public async Task<List<SearchedIdentityCardModel>> Handle(SetIdentityCardCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await _currentUser.GetUserId();

            List<SearchedIdentityCardModel> listOfCards = new List<SearchedIdentityCardModel>();

            // Check if person is employed

            if(_context.Selection.Where(s => s.PersonId == request.PersonId).Any())
            {

                IdentityCard card = new IdentityCard()
                {
                    CardCode = "CardCode",
                    PersonId = request.PersonId,
                    ValidUpto = request.ValidUpto,
                    PhotoPath = request.PhotoPath,
                    CardPrinted = false
                };

                _context.IdentityCard.Add(card);
                await _context.SaveChangesAsync( cancellationToken);

                listOfCards = await _mediator.Send(new GetIdentityCardsQuery() { Id = card.Id });

            }
            else
            {
                throw new BusinessRulesException("کارمند انتخاب شده تعیینات نشده است");
            }
            return listOfCards;
            
        }
    }
}
