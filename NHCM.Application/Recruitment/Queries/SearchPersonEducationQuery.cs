using MediatR;
using NHCM.Application.Recruitment.Models;
using NHCM.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NHCM.Application.Recruitment.Queries
{
  public  class SearchPersonEducationQuery : IRequest<List<SearchedPersonEducations>>
    {

        // One of these two fields should have a value in runtime else the search will not return any result set.
        public decimal? Id { get; set; }
        public decimal? PersonId { get; set; }



        public short EducationLevelId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? Enddate { get; set; }
        public string OfficialDocumentNo { get; set; }
        public int? LocationId { get; set; }
        public string Institute { get; set; }
        public string Course { get; set; }
        public string Department { get; set; }
        public bool? Inservice { get; set; }
        public string Major { get; set; }
        public string Remarks { get; set; }
        public string MigratedLocation { get; set; }
        public string Faculty { get; set; }
    }


    public class SearchPersonEducationQueryHandler : IRequestHandler<SearchPersonEducationQuery, List<SearchedPersonEducations>>
    {

        private HCMContext _context;
        public SearchPersonEducationQueryHandler(HCMContext context)
        {
            _context = context;
        }
        public async Task<List<SearchedPersonEducations>> Handle(SearchPersonEducationQuery request, CancellationToken cancellationToken)
        {
            List<SearchedPersonEducations> result = new List<SearchedPersonEducations>();


            if (request.Id != null)
            {


                result = await (from edu in _context.Education
                                join l in _context.Location on edu.LocationId equals l.Id

                                where edu.Id == request.Id
                                select new SearchedPersonEducations
                                {
                                    Id = edu.Id,
                                    PersonId = edu.PersonId,

                                    EducationLevelId = edu.EducationLevelId,
                                    StartDate = edu.StartDate,
                                    Enddate = edu.Enddate,
                                    OfficialDocumentNo = edu.OfficialDocumentNo,
                                    LocationId = edu.LocationId,
                                    Institute = edu.Institute,
                                    Course = edu.Course,
                                    Department = edu.Department,
                                    Inservice = edu.Inservice,
                                    Major = edu.Major,
                                    Remarks = edu.Remarks,
                                    MigratedLocation = edu.MigratedLocation,
                                    Faculty = edu.Faculty,

                                    LocationText = l.Dari




                                }).ToListAsync(cancellationToken);
            }


            else if (request.PersonId != null)
            {
                result = await (from edu in _context.Education
                                join l in _context.Location on edu.LocationId equals l.Id

                                where edu.PersonId == request.PersonId
                                select new SearchedPersonEducations
                                {
                                    Id = edu.Id,
                                    PersonId = edu.PersonId,

                                    EducationLevelId = edu.EducationLevelId,
                                    StartDate = edu.StartDate,
                                    Enddate = edu.Enddate,
                                    OfficialDocumentNo = edu.OfficialDocumentNo,
                                    LocationId = edu.LocationId,
                                    Institute = edu.Institute,
                                    Course = edu.Course,
                                    Department = edu.Department,
                                    Inservice = edu.Inservice,
                                    Major = edu.Major,
                                    Remarks = edu.Remarks,
                                    MigratedLocation = edu.MigratedLocation,
                                    Faculty = edu.Faculty,

                                    LocationText = l.Dari




                                }).ToListAsync(cancellationToken);
            }






            return result;
        }
    }
}
