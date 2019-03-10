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
using NHCM.Application.Recruitment.Queries;
using NHCM.Application.Recruitment.Models;
using NHCM.Application.Common;


namespace NHCM.Application.Recruitment.Commands
{
    public class SavePersonEducation :IRequest<List<SearchedPersonEducations>>
    {

        public decimal? Id { get; set; }
        public decimal PersonId { get; set; }
        public short EducationLevelId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
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


    public class SavePersonEducationHandler : IRequestHandler<SavePersonEducation, List<SearchedPersonEducations>>
    {

        private readonly HCMContext _context;
        private readonly IMediator _mediator;
   
        public SavePersonEducationHandler(HCMContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
           
        }
        public async Task<List<SearchedPersonEducations>> Handle(SavePersonEducation request, CancellationToken cancellationToken)
        {
           
            List<SearchedPersonEducations> dbResult = new List<SearchedPersonEducations>();

            // Save
            if (request.Id == null || request.Id == default(decimal))
            {

                using (_context)
                {



                    // Construct Education Object
                    Education education = new Education()
                    {
                        PersonId = request.PersonId,
                        EducationLevelId = request.EducationLevelId,
                        ModifiedOn = request.ModifiedOn,
                        ModifiedBy = request.ModifiedBy,
                        ReferenceNo = request.ReferenceNo,
                        CreatedOn = request.CreatedOn,
                        CreatedBy = request.CreatedBy,
                        StartDate = request.StartDate,
                        Enddate = request.Enddate,
                        OfficialDocumentNo = request.OfficialDocumentNo,
                        LocationId = request.LocationId,
                        Institute = request.Institute,
                        Course = request.Course,
                        Department = request.Department,
                        Inservice = request.Inservice,
                        Major = request.Major,
                        Remarks = request.Remarks,
                        MigratedLocation = request.MigratedLocation,
                        Faculty = request.Faculty
                    };

                    _context.Education.Add(education);

                    dbResult = await _mediator.Send(new SearchPersonEducationQuery() { Id = education.Id });
                    return dbResult;
    
              

                   
                }
            }
            // Update
            else
            {

                using (_context)
                {


                    Education education =await (from e in _context.Education
                                           where e.Id == request.Id
                                           select e).FirstOrDefaultAsync();


                    education.PersonId = request.PersonId;
                    education.EducationLevelId = request.EducationLevelId;
                    education.ModifiedOn = request.ModifiedOn;
                    education.ModifiedBy = request.ModifiedBy;
                    education.ReferenceNo = request.ReferenceNo;
                    education.CreatedOn = request.CreatedOn;
                    education.CreatedBy = request.CreatedBy;
                    education.StartDate = request.StartDate;
                    education.Enddate = request.Enddate;
                    education.OfficialDocumentNo = request.OfficialDocumentNo;
                    education.LocationId = request.LocationId;
                    education.Institute = request.Institute;
                    education.Course = request.Course;
                    education.Department = request.Department;
                    education.Inservice = request.Inservice;
                    education.Major = request.Major;
                    education.Remarks = request.Remarks;
                    education.MigratedLocation = request.MigratedLocation;
                    education.Faculty = request.Faculty;





                    await _context.SaveChangesAsync();


                    dbResult = await _mediator.Send(new SearchPersonEducationQuery() { Id = education.Id });

                    return dbResult;

                }

            }
        }
    }
}
