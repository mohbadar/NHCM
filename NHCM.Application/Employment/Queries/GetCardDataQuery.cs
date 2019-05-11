using MediatR;
using Microsoft.EntityFrameworkCore;
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

namespace NHCM.Application.Employment.Queries
{
    public class GetCardDataQuery : IRequest<List<CardDataModel>>
    {
        public string HrCode { get; set; }

    }

    public class GetCardDataQueryHandler : IRequestHandler<GetCardDataQuery, List<CardDataModel>>
    {
        private readonly HCMContext _context;
        private readonly ICurrentUser _currentUser;
        private readonly IMediator _mediator;
        public GetCardDataQueryHandler(HCMContext context, ICurrentUser currentUser, IMediator mediator)
        {
            _context = context;
            _currentUser = currentUser;
            _mediator = mediator;
        }
        public async Task<List<CardDataModel>> Handle(GetCardDataQuery request, CancellationToken cancellationToken)
        {
            List<CardDataModel> listOfCardData = new List<CardDataModel>();
            
            if (!string.IsNullOrEmpty(request.HrCode))
            {
                // p => Person, s => Selection, pt => PositionType, po => Position
                listOfCardData = await (from p in _context.Person
                                        join s in _context.Selection on p.Id equals s.PersonId into joinOne
                                        from resultjoinOne in joinOne.DefaultIfEmpty()

                                        join po in _context.Position on resultjoinOne.PositionId equals po.Id into joinTwo
                                        from resultjoinTwo in joinTwo.DefaultIfEmpty()

                                        join pt in _context.PositionType on resultjoinTwo.PositionTypeId equals pt.Id into joinThree
                                        from resultJoinThree in joinThree.DefaultIfEmpty()

                                        join wa in _context.WorkArea on resultjoinTwo.WorkingAreaId equals wa.Id into joinFour
                                        from resultJoinFour in joinFour.DefaultIfEmpty()

                                        where p.Hrcode == request.HrCode
                                        select new CardDataModel
                                        {
                                            FullName = new StringBuilder() { }.Append(p.FirstName).Append(" ").Append(p.LastName).ToString(),
                                            FullNameE = new StringBuilder() { }.Append(p.FirstNameEng).Append(" ").Append(p.LastNameEng).ToString(),
                                            PositionTitle = resultJoinThree.Name,
                                            OrgUnitName = resultJoinFour.Title,
                                            PositionTitleE = resultJoinThree.NameEng
                                        }
                                       ).ToListAsync();

            }
            else
            {
                throw new BusinessRulesException("کودکادری خالی بوده نمیتواند");
            }

            return listOfCardData;

        }
    }
}
