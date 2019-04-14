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
using NHCM.Application.Organogram.Models;
using NHCM.Application.Organogram.Queries;
using NHCM.Domain.Entities;

namespace NHCM.Application.Employment.Queries
{
    public class SearchSelectionQuery : IRequest<List<SearchedSelectionModel>>
    {
        public int? OrganoGramId { get; set; }

    }


    public class SearchSelectionQueryHandler : IRequestHandler<SearchSelectionQuery, List<SearchedSelectionModel>>
    {
        private readonly HCMContext _context;
        private readonly IMediator _mediator;

        public SearchSelectionQueryHandler(HCMContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<List<SearchedSelectionModel>> Handle(SearchSelectionQuery request, CancellationToken cancellationToken)
        {
            List<SearchedSelectionModel> result = new List<SearchedSelectionModel>();
            List<SearchedPosition> Positions = await _mediator.Send(new SearchPositionQuery() { OrganoGramId = request.OrganoGramId });

            foreach (SearchedPosition P in Positions)
            {
                SearchedSelectionModel Record = new SearchedSelectionModel();
                if (_context.Selection.Any(c => c.PositionId == P.Id && c.StatusId != 2))
                {
                    Selection selected = await _context.Selection.Where(c => c.PositionId == P.Id && c.StatusId != 2).SingleOrDefaultAsync();
                    Record.SelectionId = selected.Id;
                    Record.EffectiveDate = selected.EffectiveDate;
                    Record.EventTypeId = selected.EventTypeId;
                    Record.Remarks = selected.Remarks;
                    Record.FinalNo = selected.FinalNo;
                    Record.VerdictDate = selected.VerdictDate;
                    Record.VerdictRegNo = selected.VerdictRegNo;
                    Record.PersonId = selected.PersonId;
                }
                Record.Id = P.Id;
                Record.ParentId = Convert.ToInt32(P.ParentId);
                Record.OrganogramId = Convert.ToInt32(P.OrganoGramId);
                Record.WorkAreaText = P.WorkAreaText;
                Record.PositionTypeText = P.PositionTypeText;
                Record.RankText = P.RankText;
                Record.OrgUnitText = P.OrgUnitText;
                Record.Sorter = P.Sorter;
                Record.Code = P.Code;
                Record.RankText = P.RankText;
                Record.LocationText = P.LocationText;
                Record.Title = P.PositionTypeText + " " + P.WorkAreaText;
                result.Add(Record);
            }
            return result;
        }
    }
}
