using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using NHCM.Application.Recruitment.Models;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using NHCM.Persistence;
using NHCM.Application.Common;
using NHCM.Application.Employment.Models;

namespace NHCM.Application.Employment.Queries
{
    public class SearchSelectionQuery : IRequest<List<SearchedSelectionModel>>
    {

        public decimal? Id { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public decimal? ParentId { get; set; }
        public decimal? OrgunitId { get; set; }
        public short? PositionTypeId { get; set; }
        public short? RankId { get; set; }
        public int? StatusId { get; set; }
        public string Code { get; set; }
        public int? LocationId { get; set; }
        public int? DirectorateId { get; set; }
        public string Profession { get; set; }
        public string Kadr { get; set; }
        public string Remarks { get; set; }
        public int? SalaryTypeId { get; set; }
        public string Sorter { get; set; }
        public int? OrganoGramId { get; set; }
        public decimal? TransferPositionId { get; set; }
        public short? PlanTypeId { get; set; }


    }


    public class SearchSelectionQueryHandler : IRequestHandler<SearchSelectionQuery, List<SearchedSelectionModel>>
    {

        private readonly HCMContext _context;
        //private readonly IMediator _mediator;

        public SearchSelectionQueryHandler(HCMContext context/*, IMediator mediator*/)
        {
            _context = context;
            //_mediator = mediator;
        }

        public async Task<List<SearchedSelectionModel>> Handle(SearchSelectionQuery request, CancellationToken cancellationToken)
        {
            List<SearchedSelectionModel> result = new List<SearchedSelectionModel>();
            if (request.Id != null)
            {
                result = await (from d in _context.Selection

                                where d.Id == request.Id
                                select new SearchedSelectionModel
                                {
                                    Id = d.Id,




                                      PositionId  = d.PositionId,
       EffectiveDate= d.EffectiveDate,

                                    EventTypeId= d.EventTypeId,
                                    PersonId =d.PersonId,
                                    CategoryId =d.CategoryId,
                                    EventId =d.EventId,
                                    Remarks =d.Remarks,
                                    OldPosition =d.OldPosition,
                                    OrganizationId= d.OrganizationId,
                                    VerdictDate= d.VerdictDate,
                                    VerdictRegNo =d.VerdictRegNo,
                                    FinalNo =d.FinalNo,
                                    RankId= d.RankId,
                                    ModifiedOn =d.ModifiedOn,
                                    ModifiedBy =d.ModifiedBy,
                                    ReferenceNo=d.ReferenceNo,
                                    CreatedOn= d.CreatedOn,
                                    CreatedBy =d.CreatedBy,

                                    // TEMP:
                                    DateText = PersianLibrary.PersianDate.GetFormatedString(d.VerdictDate.Value),

                                }).OrderByDescending(c => c.CreatedOn).ToListAsync(cancellationToken);
            }
            else
            {
                result = await (from d in _context.Selection
                                where d.Id == request.Id
                                select new SearchedSelectionModel
                                {
                                    Id = d.Id
                                }).OrderByDescending(c => c.CreatedOn).ToListAsync(cancellationToken);
            }
            return result;
        }
    }
}
