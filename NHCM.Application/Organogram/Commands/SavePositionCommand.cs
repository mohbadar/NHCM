using MediatR;
using Microsoft.EntityFrameworkCore;
using NHCM.Application.Organogram.Models;
using NHCM.Domain.Entities;
using NHCM.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NHCM.Application.Organogram.Commands
{
    public class SavePositionCommand : IRequest<List<SearchedPosition>>
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
        public int? EducationLevelId { get; set; }
        public short? ExperienceNoOfYear { get; set; }
        public string PositionResponsibilityAndPurpose { get; set; }
    }

    public class SavePositionCommandHandler : IRequestHandler<SavePositionCommand, List<SearchedPosition>>
    {
        private readonly HCMContext _context;
        private readonly IMediator _mediator;
        public SavePositionCommandHandler(HCMContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;

        }

        public async Task<List<SearchedPosition>> Handle(SavePositionCommand request, CancellationToken cancellationToken)
        {
            List<SearchedPosition> result = new List<SearchedPosition>();

            if (request.Id == null || request.Id == default(decimal))
            {

                using (_context)
                {
                    Position PData = new Position()
                    {   
                        Name = request.Name,
                        ModifiedOn = request.ModifiedOn,
                        ModifiedBy = request.ModifiedBy,
                        ReferenceNo = request.ReferenceNo,
                        CreatedOn = request.CreatedOn,
                        CreatedBy = request.CreatedBy,
                        ParentId = request.ParentId,
                        OrgunitId = request.OrgunitId,
                        PositionTypeId = request.PositionTypeId,
                        RankId = request.RankId,
                        StatusId = request.StatusId,
                        Code = request.Code,
                        LocationId = request.LocationId,
                        DirectorateId = request.DirectorateId,
                        Profession = request.Profession,
                        Kadr = request.Kadr,
                        Remarks = request.Remarks,
                        SalaryTypeId = request.SalaryTypeId,
                        Sorter = request.Sorter,
                        OrganoGramId = request.OrganoGramId,
                        TransferPositionId = request.TransferPositionId,
                        PlanTypeId = request.PlanTypeId,
                        EducationLevelId = request.EducationLevelId,
                        ExperienceNoOfYear = request.ExperienceNoOfYear,
                        PositionResponsibilityAndPurpose = request.PositionResponsibilityAndPurpose,

                    };

                    _context.Position.Add(PData);
                    await _context.SaveChangesAsync(cancellationToken);


                    result = await _mediator.Send(new Queries.SearchPositionQuery() { Id = PData.Id });


                }
            }
            else
            {
                using (_context)
                {
                    Position toUpdateRecord = await (from po in _context.Position
                                                     where po.Id == request.Id
                                                     select po).SingleOrDefaultAsync();

                    toUpdateRecord.Name = request.Name;
                    toUpdateRecord.ModifiedOn = request.ModifiedOn;
                    toUpdateRecord.ModifiedBy = request.ModifiedBy;
                    toUpdateRecord.ReferenceNo = request.ReferenceNo;
                    toUpdateRecord.CreatedOn = request.CreatedOn;
                    toUpdateRecord.CreatedBy = request.CreatedBy;
                    toUpdateRecord.ParentId = request.ParentId;
                    toUpdateRecord.OrgunitId = request.OrgunitId;
                    toUpdateRecord.PositionTypeId = request.PositionTypeId;
                    toUpdateRecord.RankId = request.RankId;
                    toUpdateRecord.StatusId = request.StatusId;
                    toUpdateRecord.Code = request.Code;
                    toUpdateRecord.LocationId = request.LocationId;
                    toUpdateRecord.DirectorateId = request.DirectorateId;
                    toUpdateRecord.Profession = request.Profession;
                    toUpdateRecord.Kadr = request.Kadr;
                    toUpdateRecord.Remarks = request.Remarks;
                    toUpdateRecord.SalaryTypeId = request.SalaryTypeId;
                    toUpdateRecord.Sorter = request.Sorter;
                    toUpdateRecord.OrganoGramId = request.OrganoGramId;
                    toUpdateRecord.TransferPositionId = request.TransferPositionId;
                    toUpdateRecord.PlanTypeId = request.PlanTypeId;
                    toUpdateRecord.EducationLevelId = request.EducationLevelId;
                    toUpdateRecord.ExperienceNoOfYear = request.ExperienceNoOfYear;
                    toUpdateRecord.PositionResponsibilityAndPurpose = request.PositionResponsibilityAndPurpose;

                    await _context.SaveChangesAsync(cancellationToken);

                    result = await _mediator.Send(new Queries.SearchPositionQuery() { Id = toUpdateRecord.Id });
                }
            }
            return result;
        }
    }
}
