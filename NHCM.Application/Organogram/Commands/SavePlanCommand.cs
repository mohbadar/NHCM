using MediatR;
using NHCM.Application.Organogram.Models;
using NHCM.Domain.Entities;
using NHCM.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NHCM.Application.Organogram.Commands
{
    public class SavePlanCommand : IRequest<List<SearchedPlan>>
    {


        public int? Id { get; set; }
        public int OrganizationId { get; set; }
        public short StatusId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ReferenceNo { get; set; }
        public int? Year { get; set; }
        public DateTime? PreparedDate { get; set; }
        public DateTime? AppreovedDate { get; set; }
        public int? NumberOfPositions { get; set; }

        
    }


    public class SaveOrganogramCommandHandler : IRequestHandler<SavePlanCommand, List<SearchedPlan>>
    {
        private readonly HCMContext _context;
        private readonly IMediator _mediator; 
        public SaveOrganogramCommandHandler(HCMContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;

        }

        public async  Task<List<SearchedPlan>> Handle(SavePlanCommand request, CancellationToken cancellationToken)
        {

            List<SearchedPlan> result = new List<SearchedPlan>();


            if (request.Id == null || request.Id == default(decimal))
            {

                using (_context)
                {
                    OrganoGram organogram = new OrganoGram()
                    {
                        OrganizationId = request.OrganizationId,
                        StatusId = request.StatusId,
                        ModifiedOn = request.ModifiedOn,
                        ModifiedBy = request.ModifiedBy,
                        CreatedOn = request.CreatedOn,
                        CreatedBy = request.CreatedBy,
                        ReferenceNo = request.ReferenceNo,
                        Year = request.Year,
                        PreparedDate = request.PreparedDate,
                        AppreovedDate = request.AppreovedDate,
                        NumberOfPositions=request.NumberOfPositions 
                        

                    };

                    _context.OrganoGram.Add(organogram);
                    await _context.SaveChangesAsync(cancellationToken);


                    result = await _mediator.Send(new Queries.SearchPlanQuery() { Id = organogram.Id });


                }
            }
             
            else
            { 
                using (_context)
                {
                    OrganoGram toUpdateRecord = await (from org in _context.OrganoGram
                                                       where org.Id == request.Id 
                                                        select org).SingleOrDefaultAsync();

                    toUpdateRecord.OrganizationId = request.OrganizationId;
                    toUpdateRecord.StatusId = request.StatusId;
                    toUpdateRecord.ModifiedOn = request.ModifiedOn;
                    toUpdateRecord.ModifiedBy = request.ModifiedBy;
                    toUpdateRecord.CreatedOn = request.CreatedOn;
                    toUpdateRecord.CreatedBy = request.CreatedBy;
                    toUpdateRecord.ReferenceNo = request.ReferenceNo;
                    toUpdateRecord.Year = request.Year;
                    toUpdateRecord.PreparedDate = request.PreparedDate;
                    toUpdateRecord.AppreovedDate = request.AppreovedDate;
                    toUpdateRecord.NumberOfPositions = request.NumberOfPositions;
                    await _context.SaveChangesAsync(cancellationToken);

                    result = await _mediator.Send(new Queries.SearchPlanQuery() { Id = toUpdateRecord.Id });
                }
            }
            return result;
        }
    }
}
