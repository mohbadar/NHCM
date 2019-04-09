using MediatR;
using NHCM.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NHCM.Application.Auditer.Commands
{
  public  class CreateAuditCommand  : IRequest<string>
    {
        public long Id { get; set; }
        public string DbContextObject { get; set; }
        public string DbOjbectName { get; set; }
        public long? ReocordId { get; set; }
        public int? OperationTypeId { get; set; }
        public int UserId { get; set; }
        public DateTime? OperationDate { get; set; }
    }

    public class CreateAuditCommandHandler : IRequestHandler<CreateAuditCommand>
    {
        private readonly HCMContext _context;
        public CreateAuditCommandHandler(HCMContext context)
        {
            _context = context;
        }
        public Task<Unit> Handle(CreateAuditCommand request, CancellationToken cancellationToken)
        {

            using (_context)
            {
                try
                {

                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}
