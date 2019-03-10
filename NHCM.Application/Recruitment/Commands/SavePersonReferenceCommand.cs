using MediatR;
using NHCM.Application.Recruitment.Models;
using NHCM.Domain.Entities;
using NHCM.Persistence;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NHCM.Application.Recruitment.Commands
{
   public  class SavePersonReferenceCommand : IRequest<List<SearchedPersonReference>>
    {

        public decimal? Id { get; set; }
        public decimal PersonId { get; set; }

        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Occupation { get; set; }
        public string Organization { get; set; }
        public string TelephoneNo { get; set; }
        public string District { get; set; }
        public int? LocationId { get; set; }
        public string RelationShip { get; set; }
        public short? ReferenceTypeId { get; set; }
        //public string Amount { get; set; }
        //public int? BankId { get; set; }
        //public string ReceiptNumber { get; set; }
        //public string DocumentNumber { get; set; }
        //public DateTime? DocumentDate { get; set; }
        public string Remark { get; set; }
    }
    public class SavePersonReferenceCommandHandler : IRequestHandler<SavePersonReferenceCommand, List<SearchedPersonReference>>
    {
        private readonly HCMContext _context;
        private readonly IMediator _mediator;

        public SavePersonReferenceCommandHandler(HCMContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;

        }
        public async Task<List<SearchedPersonReference>> Handle(SavePersonReferenceCommand request, CancellationToken cancellationToken)
        {
            List<SearchedPersonReference> result = new List<SearchedPersonReference>();


            if (request.Id == null || request.Id == default(decimal))
            {

                using (_context)
                {

                    Reference reference = new Reference()
                    {
                         
                        PersonId  = request.PersonId,
                        ModifiedOn = request.ModifiedOn,
                        ModifiedBy = request.ModifiedBy,
                        ReferenceNo = request.ReferenceNo,
                        CreatedOn = request.CreatedOn,
                        CreatedBy = request.CreatedBy,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        FatherName = request.FatherName,
                        GrandFatherName = request.GrandFatherName,
                        Occupation = request.Occupation,
                        Organization = request.Organization,
                        TelephoneNo = request.TelephoneNo,
                        District = request.District,
                        LocationId = request.LocationId,
                        RelationShip = request.RelationShip,
                        ReferenceTypeId = request.ReferenceTypeId,
                        //Amount = request,
                        //BankId = request.PersonId,
                        //ReceiptNumber = request.PersonId,
                        //DocumentNumber = request.PersonId,
                        //DocumentDate = request.PersonId,
                        Remark = request.Remark
                    };

                  

                    _context.Reference.Add(reference);

                    await _context.SaveChangesAsync(cancellationToken);


                    result = await _mediator.Send(new Queries.SearchPersonReferenceQuery() { Id = reference.Id });


                }
            }
            else
            {
                using (_context)
                {

                    Reference reference = await (from refe in _context.Reference
                                                 where refe.Id == request.Id
                                                 select refe).SingleOrDefaultAsync();


                    reference.PersonId = request.PersonId;
                    reference.ModifiedOn = request.ModifiedOn;
                    reference.ModifiedBy = request.ModifiedBy;
                    reference.ReferenceNo = request.ReferenceNo;
                    reference.CreatedOn = request.CreatedOn;
                    reference.CreatedBy = request.CreatedBy;
                    reference.FirstName = request.FirstName;
                    reference.LastName = request.LastName;
                    reference.FatherName = request.FatherName;
                    reference.GrandFatherName = request.GrandFatherName;
                    reference.Occupation = request.Occupation;
                    reference.Organization = request.Organization;
                    reference.TelephoneNo = request.TelephoneNo;
                    reference.District = request.District;
                    reference.LocationId = request.LocationId;
                    reference.RelationShip = request.RelationShip;
                    reference.ReferenceTypeId = request.ReferenceTypeId;
                    reference.Remark = request.Remark;
                    //reference. Amount = request;
                    //reference.BankId = request.PersonId;
                    //reference.ReceiptNumber = request.PersonId;
                    //reference. DocumentNumber = request.PersonId;
                    //reference. DocumentDate = request.PersonId;

                    await _context.SaveChangesAsync(cancellationToken);

                    result = await _mediator.Send(new Queries.SearchPersonReferenceQuery() { Id = reference.Id });
                }
            }

            return result;
        }
    }
}
