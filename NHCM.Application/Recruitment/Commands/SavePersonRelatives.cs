using MediatR;
using NHCM.Application.Recruitment.Models;
using NHCM.Domain.Entities;
using NHCM.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NHCM.Application.Common;

namespace NHCM.Application.Recruitment.Commands
{
    public class SavePersonRelatives : IRequest<List<SearchedPersonRelative>>
    {

        public decimal? Id { get; set; }


        public string FatherName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? PersonId { get; set; }
        public string GrandFatherName { get; set; }
        public short? RelationShipId { get; set; }
        public string NidNo { get; set; }
        public string Profession { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public string EmailAddress { get; set; }
        public string Village { get; set; }
        public int? LocationId { get; set; }
        public string Remark { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
    }

    public class SavePersonRelativesHandler : IRequestHandler<SavePersonRelatives, List<SearchedPersonRelative>>
    {
        private readonly HCMContext _context;
        public SavePersonRelativesHandler(HCMContext context)
        {
            _context = context;
        }
        public async Task<List<SearchedPersonRelative>> Handle(SavePersonRelatives request, CancellationToken cancellationToken)
        {
            List<SearchedPersonRelative> result = new List<SearchedPersonRelative>();

           

            if (request.Id == null || request.Id == default(decimal))
            {
                using (_context)
                {


                    Relative relative = new Relative()
                    {

                        RelationShipId = request.RelationShipId,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        FatherName = request.FatherName,
                        GrandFatherName = request.GrandFatherName,
                        Profession = request.Profession,
                        LocationId = request.LocationId,
                        PersonId = request.PersonId,
                        NidNo = request.NidNo,
                        Address = request.Address,
                        ContactInfo = request.ContactInfo,
                        EmailAddress = request.EmailAddress,
                        Village = request.Village,
                        Remark = request.Remark,

                        CreatedOn = request.CreatedOn,
                        ModifiedBy = request.ModifiedBy,

                        ModifiedOn = request.ModifiedOn,
                        CreatedBy = request.CreatedBy


                    };
                    _context.Relative.Add(relative);
                    await _context.SaveChangesAsync(cancellationToken);


                    PersonCommon common = new PersonCommon(_context);

                    // Return Saved Relative
                    result = await common.SearchPersonRelative(new Queries.SearchPersonRelativeQuery() { Id = relative.Id }, cancellationToken);
                    

              //result = new List<SearchedPersonRelative>();
              //      result = await (from r in _context.Relative
              //                      join relationship in _context.Relationship on r.RelationShipId equals relationship.Id into rR
              //                      from resultRr in rR.DefaultIfEmpty()
              //                      join l in _context.Location on r.LocationId equals l.Id into rL
              //                      from resultrL in rL.DefaultIfEmpty()
                                    
              //                      where r.Id == relative.Id
              //                      select new SearchedPersonRelative
              //                      {

              //                          Id = relative.Id,
              //                          FatherName = relative.FatherName,
              //                          FirstName = relative.FirstName,
              //                          PersonId = relative.PersonId,
              //                          GrandFatherName = relative.GrandFatherName,
              //                          RelationShipId = relative.RelationShipId,
              //                          NidNo = relative.NidNo,
              //                          Profession = relative.Profession,
              //                          Address = relative.Address,
              //                          ContactInfo = relative.ContactInfo,
              //                          EmailAddress = relative.EmailAddress,
              //                          Village = relative.Village,
              //                          LocationId = relative.LocationId,
              //                          Remark = relative.Remark,
              //                          RelationShipIdText = resultRr.Name,
              //                          LocationText  = resultrL.Dari


              //                      }).ToListAsync(cancellationToken);


              
                    
                }
            }



            else
            {
                using (_context)
                {
                    Relative UpdateableRecord = await (from r in _context.Relative
                                                 where r.Id == request.Id
                                                 select r).FirstOrDefaultAsync(cancellationToken);

                   

                    UpdateableRecord.FatherName = request.FatherName;
                    UpdateableRecord.FirstName = request.FirstName;
                    UpdateableRecord.LastName = request.LastName;
                    UpdateableRecord.PersonId = request.PersonId;
                    UpdateableRecord.GrandFatherName = request.GrandFatherName;
                    UpdateableRecord.RelationShipId = request.RelationShipId;
                    UpdateableRecord.NidNo = request.NidNo;
                    UpdateableRecord.Profession = request.Profession;
                    UpdateableRecord.Address = request.Address;
                    UpdateableRecord.ContactInfo = request.ContactInfo;
                    UpdateableRecord.EmailAddress = request.EmailAddress;
                    UpdateableRecord.Village = request.Village;
                    UpdateableRecord.Remark = request.Remark;
                    UpdateableRecord.ModifiedBy = request.ModifiedBy;
                    UpdateableRecord.ModifiedOn = request.ModifiedOn;

                    await _context.SaveChangesAsync(cancellationToken);
                    PersonCommon common = new PersonCommon(_context);
                    // Return Saved Relative
                    result = await common.SearchPersonRelative(new Queries.SearchPersonRelativeQuery() { Id = UpdateableRecord.Id }, cancellationToken);
                }
            }


            return result;
        }
    }
}
