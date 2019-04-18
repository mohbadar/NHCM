using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using NHCM.Domain;
using NHCM.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using NHCM.Persistence.Extensions;
using NHCM.Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NHCM.Application.Employment.Models;
using NHCM.Application.Employment.Queries;
using NHCM.Application.Organogram.Queries;
using NHCM.Application.Organogram.Models;

namespace NHCM.Application.Employment.Commands
{
    public class CreateSelectionCommand : IRequest<List<SearchedSelectionModel>>
    {
         
        public decimal PositionId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal? Id { get; set; }
        public int EventTypeId { get; set; }
        public decimal PersonId { get; set; }
        public string Remarks { get; set; }
        public DateTime? VerdictDate { get; set; }
        public string VerdictRegNo { get; set; }
        public string FinalNo { get; set; }

    }
     
    public class CreateSelectionCommandHandler : IRequestHandler<CreateSelectionCommand, List<SearchedSelectionModel>>
    { 
        private readonly HCMContext _context;
        private readonly IMediator _mediator;
        public CreateSelectionCommandHandler(HCMContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<List<SearchedSelectionModel>> Handle(CreateSelectionCommand request, CancellationToken cancellationToken)
        {
            List<SearchedSelectionModel> result = new List<SearchedSelectionModel>(); 
            if (request.Id == null || request.Id == default(decimal))
            {
                _context.Selections.Add(new Selection()
                {
                    PositionId = request.PositionId,
                    PersonId = request.PersonId,
                    EffectiveDate = request.EffectiveDate,
                    VerdictDate = request.VerdictDate.Value,
                    EventTypeId = request.EventTypeId,
                    VerdictRegNo = request.VerdictRegNo,
                    Remarks = request.Remarks,
                    FinalNo = request.FinalNo, 
                }); 
                await _context.SaveChangesAsync(cancellationToken); 
                result = await _mediator.Send(new SearchSelectionQuery() { OrganoGramId = _context.Position.Where(a => a.Id == request.PositionId).SingleOrDefault().OrganoGramId });
                return result;
            } 
            else
            {
                Selection d = (from p in _context.Selection
                               where p.Id == request.Id
                               select p).First();
                d.PositionId = request.PositionId;
                d.PersonId = request.PersonId;
                d.EventTypeId = request.EventTypeId;
                d.EffectiveDate = request.EffectiveDate;
                d.VerdictDate = request.VerdictDate.Value;
                d.VerdictRegNo = request.VerdictRegNo;
                d.Remarks = request.Remarks;
                d.FinalNo = request.FinalNo; 
                await _context.SaveChangesAsync(); 
                result = await _mediator.Send(new SearchSelectionQuery() { OrganoGramId = _context.Position.Where(a => a.Id == request.PositionId).SingleOrDefault().OrganoGramId });
                return result; 
            } 
        }
    }
}
