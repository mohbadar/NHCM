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

namespace NHCM.Application.Organogram.Queries
{
    public class SearchPlanQuery : IRequest<List<SearchedPlan>>
    {
        public int? Id { get; set; }
        public int? OrganizationId { get; set; }
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

        public string statustext { get; set; }
        public string OrganizationText { get; set; }
        public string TitleText { get; set; }
    }


    public class SearchOrganogramQueryHandler : IRequestHandler<SearchPlanQuery, List<SearchedPlan>>
    {
        private HCMContext _context;
        public SearchOrganogramQueryHandler(HCMContext context) { _context = context; }

        public async Task<List<SearchedPlan>> Handle(SearchPlanQuery request, CancellationToken cancellationToken)
        {
            List<SearchedPlan> result = new List<SearchedPlan>();
            if (request.OrganizationId != null && request.Year != null)
            {
                using (_context)
                {
                    result = await (from Organogram in _context.OrganoGram

                                    join Orgunit in _context.Organization on Organogram.OrganizationId equals Orgunit.Id into orgs
                                    from resultOrgUnit in orgs.DefaultIfEmpty()

                                    join st in _context.Status on Organogram.StatusId equals st.Id into se
                                    from resultStatus in se.DefaultIfEmpty()


                                    where Organogram.OrganizationId == request.OrganizationId && Organogram.Year == request.Year
                                    select new SearchedPlan
                                    {
                                        Id = Organogram.Id,
                                        OrganizationId = Organogram.OrganizationId,
                                        StatusId = Organogram.StatusId,
                                        Year = Organogram.Year,
                                        AppreovedDate = Organogram.AppreovedDate,
                                        PreparedDate = Organogram.PreparedDate,
                                        NumberOfPositions = Organogram.NumberOfPositions,
                                        //(N'تشکیل ', S.Dari, N' سال ', O.Year, N' ', OU.Dari) Title
                                        statustext = resultStatus.Dari,
                                        OrganizationText = resultOrgUnit.Dari,
                                        TitleText = " تشکیل " + resultStatus.Dari + " سال " + Organogram.Year + " " + resultOrgUnit.Dari

                                    }).ToListAsync(cancellationToken);
                }
            }
            else if (request.Id != null || request.OrganizationId!=null)
            {
                using (_context)
                {
                    ///Change OrganoGram to Organogram
                    result = await (from Organogram in _context.OrganoGram

                                    join organization in _context.Organization on Organogram.OrganizationId equals organization.Id into orgs
                                    from resultOrgUnit in orgs.DefaultIfEmpty()

                                    join st in _context.Status on Organogram.StatusId equals st.Id into se
                                    from resultStatus in se.DefaultIfEmpty()


                                    where Organogram.Id == request.Id || Organogram.OrganizationId==request.OrganizationId
                                    select new SearchedPlan
                                    {
                                        Id = Organogram.Id,
                                        OrganizationId = Organogram.OrganizationId,
                                        StatusId = Organogram.StatusId,
                                        Year = Organogram.Year,
                                        AppreovedDate = Organogram.AppreovedDate,
                                        PreparedDate = Organogram.PreparedDate,
                                        NumberOfPositions = Organogram.NumberOfPositions,
                                        //(N'تشکیل ', S.Dari, N' سال ', O.Year, N' ', OU.Dari) Title
                                        statustext = resultStatus.Dari,
                                        OrganizationText = resultOrgUnit.Dari,
                                        TitleText = " تشکیل " + resultStatus.Dari + " سال " + Organogram.Year + " " + resultOrgUnit.Dari


                                    }).ToListAsync(cancellationToken);
                }
            }


            else
            {
                using (_context)
                {
                    result = await (from Organogram in _context.OrganoGram

                                    join Orgunit in _context.Organization on Organogram.OrganizationId equals Orgunit.Id into orgs
                                    from resultOrgUnit in orgs.DefaultIfEmpty()

                                    join st in _context.Status on Organogram.StatusId equals st.Id into se
                                    from resultStatus in se.DefaultIfEmpty()

                                    select new SearchedPlan
                                    {
                                        Id = Organogram.Id,
                                        OrganizationId = Organogram.OrganizationId,
                                        StatusId = Organogram.StatusId,
                                        Year = Organogram.Year,
                                        AppreovedDate = Organogram.AppreovedDate,
                                        PreparedDate = Organogram.PreparedDate,
                                        NumberOfPositions = Organogram.NumberOfPositions,
                                        //(N'تشکیل ', S.Dari, N' سال ', O.Year, N' ', OU.Dari) Title
                                        statustext = resultStatus.Dari,
                                        OrganizationText = resultOrgUnit.Dari,
                                        TitleText = " تشکیل " + resultStatus.Dari + " سال " + Organogram.Year + " " + resultOrgUnit.Dari

                                    }).ToListAsync(cancellationToken);
                }
            }
            return result;
        }
    }
}
