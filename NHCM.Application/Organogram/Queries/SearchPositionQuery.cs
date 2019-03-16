using MediatR;
using NHCM.Application.Organogram.Models;
using NHCM.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NHCM.Application.Organogram.Queries
{
    public class SearchPositionQuery : IRequest<List<SearchedPosition>>
    {

        public decimal? Id { get; set; }
        public int? OrganoGramId { get; set; }
        public short? PositionTypeId { get; set; }
        public short? RankId { get; set; }
    }

    public class SearchPositionQueryHandler : IRequestHandler<SearchPositionQuery, List<SearchedPosition>>
    {
        private HCMContext _context;
        public SearchPositionQueryHandler(HCMContext context)
        {
            _context = context;
        }

        public async Task<List<SearchedPosition>> Handle(SearchPositionQuery request, CancellationToken cancellationToken)
        {
            List<SearchedPosition> result = new List<SearchedPosition>();
            if (request.Id != null)
            {
                result = await (from position in _context.Position

                                join pt in _context.PositionType on position.PositionTypeId equals pt.Id into pot
                                from resultpot in pot.DefaultIfEmpty()
                                join locatin in _context.Location on position.LocationId equals locatin.Id into poslo
                                from resultposlo in poslo.DefaultIfEmpty()
                                join rank in _context.Rank on position.RankId equals rank.Id into posr
                                from resultposr in posr.DefaultIfEmpty()
                                join parent in _context.Position on position.ParentId equals parent.Id into posp
                                from resultposp in posp.DefaultIfEmpty()
                                join status in _context.Status on position.StatusId equals status.Id into PS
                                from resultPS in PS.DefaultIfEmpty()
                                join plantype in _context.PlanType on position.PlanTypeId equals plantype.Id into ppt
                                from resultppt in ppt.DefaultIfEmpty()
                                join salarytype in _context.SalaryType on position.SalaryTypeId equals salarytype.Id into pst
                                from resultpst in pst.DefaultIfEmpty()

                                //join orgPyear in _context.OrganoGram on position.OrganoGramId equals orgPyear.Id into orgy
                                //from resultorgy in orgy.DefaultIfEmpty()


                                where position.Id == request.Id
                                select new SearchedPosition
                                {
                                    Id = position.Id,
                                    ParentId = position.ParentId,
                                    OrgunitId = position.OrgunitId,
                                    PositionTypeId = position.PositionTypeId,
                                    RankId = position.RankId,
                                    //StatusId = position.StatusId,
                                    Code = position.Code,
                                    LocationId = position.LocationId,
                                    DirectorateId = position.DirectorateId,
                                    Profession = position.Profession,
                                    Kadr = position.Kadr,
                                    //Remarks = position.Remarks,
                                    SalaryTypeId = position.SalaryTypeId,
                                    Sorter = position.Sorter,
                                    OrganoGramId = position.OrganoGramId,
                                    TransferPositionId = position.TransferPositionId,
                                    PlanTypeId = position.PlanTypeId,
                                    EducationLevelId = position.EducationLevelId,
                                    ExperienceNoOfYear = position.ExperienceNoOfYear,
                                   // PositionResponsibilityAndPurpose = position.PositionResponsibilityAndPurpose,

                                    Name = position.Name,
                                    PlanTypeText = resultppt.Name,
                                    PositionTypeText = resultpot.Name,
                                    LocationText = resultposlo.Dari,
                                    RankText = resultposr.Name,
                                    ParentText = resultposp.Name,
                                    StatusText = resultPS.Dari,
                                    SalaryTypeText = resultpst.Dari

                                }).ToListAsync(cancellationToken);
            }

            else if (request.RankId != null)
            {
                result = await (from position in _context.Position

                                join pt in _context.PositionType on position.PositionTypeId equals pt.Id into pot
                                from resultpot in pot.DefaultIfEmpty() 
                                join locatin in _context.Location on position.LocationId equals locatin.Id into poslo
                                from resultposlo in poslo.DefaultIfEmpty() 
                                join rank in _context.Rank on position.RankId equals rank.Id into posr
                                from resultposr in posr.DefaultIfEmpty() 
                                join parent in _context.Position on position.ParentId equals parent.Id into posp
                                from resultposp in posp.DefaultIfEmpty() 
                                join status in _context.Status on position.StatusId equals status.Id into PS
                                from resultPS in PS.DefaultIfEmpty() 
                                join plantype in _context.PlanType on position.PlanTypeId equals plantype.Id into ppt
                                from resultppt in ppt.DefaultIfEmpty() 
                                join salarytype in _context.SalaryType on position.SalaryTypeId equals salarytype.Id into pst
                                from resultpst in pst.DefaultIfEmpty()
                                

                                where (position.OrganoGramId == request.OrganoGramId) && (position.RankId == request.RankId)
                                select new SearchedPosition
                                {
                                    Id=position.Id,
                                    ParentId = position.ParentId,
                                    OrgunitId = position.OrgunitId,
                                    PositionTypeId = position.PositionTypeId,
                                    RankId = position.RankId,
                                    //StatusId = position.StatusId,
                                    Code = position.Code,
                                    LocationId = position.LocationId,
                                    DirectorateId = position.DirectorateId,
                                    Profession = position.Profession,
                                    Kadr = position.Kadr,
                                   // Remarks = position.Remarks,
                                    SalaryTypeId = position.SalaryTypeId,
                                    Sorter = position.Sorter,
                                    OrganoGramId = position.OrganoGramId,
                                    TransferPositionId = position.TransferPositionId,
                                    PlanTypeId = position.PlanTypeId,
                                    EducationLevelId=position.EducationLevelId,
                                    ExperienceNoOfYear=position.ExperienceNoOfYear,
                                    //PositionResponsibilityAndPurpose=position.PositionResponsibilityAndPurpose,
                                     
                                    Name = position.Name,
                                    PlanTypeText = resultppt.Name,
                                    PositionTypeText = resultpot.Name,
                                    LocationText = resultposlo.Dari,
                                    RankText = resultposr.Name,
                                    ParentText = resultposp.Name,
                                    StatusText = resultPS.Dari,
                                    SalaryTypeText = resultpst.Dari


                                     
                                }).ToListAsync(cancellationToken);
            }
            
            else
            {
                result = await (from position in _context.Position

                                join pt in _context.PositionType on position.PositionTypeId equals pt.Id into pot
                                from resultpot in pot.DefaultIfEmpty()
                                join locatin in _context.Location on position.LocationId equals locatin.Id into poslo
                                from resultposlo in poslo.DefaultIfEmpty()
                                join rank in _context.Rank on position.RankId equals rank.Id into posr
                                from resultposr in posr.DefaultIfEmpty()
                                join parent in _context.Position on position.ParentId equals parent.Id into posp
                                from resultposp in posp.DefaultIfEmpty()
                                join status in _context.Status on position.StatusId equals status.Id into PS
                                from resultPS in PS.DefaultIfEmpty()
                                join plantype in _context.PlanType on position.PlanTypeId equals plantype.Id into ppt
                                from resultppt in ppt.DefaultIfEmpty()
                                join salarytype in _context.SalaryType on position.SalaryTypeId equals salarytype.Id into pst
                                from resultpst in pst.DefaultIfEmpty()

                                where position.OrganoGramId == request.OrganoGramId 
                                select new SearchedPosition
                                {
                                    Id = position.Id,
                                    ParentId = position.ParentId,
                                    OrgunitId = position.OrgunitId,
                                    PositionTypeId = position.PositionTypeId,
                                    RankId = position.RankId,
                                   // StatusId = position.StatusId,
                                    Code = position.Code,
                                    LocationId = position.LocationId,
                                    DirectorateId = position.DirectorateId,
                                    Profession = position.Profession,
                                    Kadr = position.Kadr,
                                   // Remarks = position.Remarks,
                                    SalaryTypeId = position.SalaryTypeId,
                                    Sorter = position.Sorter,
                                    OrganoGramId = position.OrganoGramId,
                                    TransferPositionId = position.TransferPositionId,
                                    PlanTypeId = position.PlanTypeId,
                                    EducationLevelId = position.EducationLevelId,
                                    ExperienceNoOfYear = position.ExperienceNoOfYear,
                                    //PositionResponsibilityAndPurpose = position.PositionResponsibilityAndPurpose,

                                    Name = position.Name,
                                    PlanTypeText = resultppt.Name,
                                    PositionTypeText = resultpot.Name,
                                    LocationText = resultposlo.Dari,
                                    RankText = resultposr.Name,
                                    ParentText = resultposp.Name,
                                    StatusText = resultPS.Dari,
                                    SalaryTypeText = resultpst.Dari



                                }).ToListAsync(cancellationToken);
            }

            return result;
        }
    }
}
