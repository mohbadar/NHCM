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
namespace NHCM.Application.Employment.Commands
{
    public class CreateSelectionCommand : IRequest<List<SearchedSelectionModel>>
    {

        // public Person Person { get; set; }

        public decimal PositionId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal Id { get; set; }
        public int EventTypeId { get; set; }
        public decimal PersonId { get; set; }
        public short? CategoryId { get; set; }
        public decimal? EventId { get; set; }
        public string Remarks { get; set; }
        public string OldPosition { get; set; }
        public decimal? OrganizationId { get; set; }
        public DateTime? VerdictDate { get; set; }
        public string VerdictRegNo { get; set; }
        public string FinalNo { get; set; }
        public short? RankId { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }

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
            // Save
            if (request.Id == null || request.Id == default(decimal))
            {
                using (_context)
                {
                    Selection d = new Selection()
                    {
                        PositionId = request.PositionId,
                        PersonId = request.PersonId,
                        EffectiveDate = request.EffectiveDate,
                        VerdictDate = request.VerdictDate,
                        EventTypeId = request.EventTypeId,
                        VerdictRegNo = request.VerdictRegNo,
                        Remarks = request.Remarks,
                        FinalNo = request.FinalNo
                    };
                    _context.Selection.Add(d);
                    // Before Saving the changes. Get the ID of inserted person and insert a new record to pol.Employee
                    await _context.SaveChangesAsync(cancellationToken);
                    // Search and Return the saved object
                    //PersonCommon common = new PersonCommon(_context);
                    result = await _mediator.Send(new SearchSelectionQuery() { Id = d.Id });
                    return result;
                }
            }
            // Update
            else
            {
                using (_context)
                {
                    Selection d = (from p in _context.Selection
                                   where p.Id == request.Id
                                   select p).First();
                    d.PositionId = request.PositionId;
                    d.PersonId = request.PersonId;
                    d.EventTypeId = request.EventTypeId;
                    d.EffectiveDate = request.EffectiveDate;
                    d.VerdictDate = request.VerdictDate;
                    d.VerdictRegNo = request.VerdictRegNo;
                    d.Remarks = request.Remarks;
                    d.FinalNo = request.FinalNo;
                    // Before Saving the changes. Get the ID of inserted person and insert a new record to pol.Employee
                    await _context.SaveChangesAsync();
                    // Search and Return the saved object
                    //PersonCommon common = new PersonCommon(_context);
                    result = await _mediator.Send(new SearchSelectionQuery() { Id = d.Id });
                    return result;
                }
            }
        }
    }
}
