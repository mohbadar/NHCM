using MediatR;
using Microsoft.EntityFrameworkCore;
using NHCM.Domain.ViewsEntities;
using NHCM.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NHCM.Application.Reports.Queries
{
    public class SearchAttendanceReportQuery : IRequest<List<AttendanceReport>>
    {
        public int userid { get; set; }
        public string bast { get; set; }

        public string startdate { get; set; }
        public string enddate { get; set; }
    }


    public class SearchAttendanceReportQueryHandler : IRequestHandler<SearchAttendanceReportQuery, List<AttendanceReport>>
    {
        private HCMContext _context;
        public SearchAttendanceReportQueryHandler(HCMContext context)
        {
            _context = context;
        } 

        public async Task<List<AttendanceReport>> Handle(SearchAttendanceReportQuery request, CancellationToken cancellationToken)
        {

            List<AttendanceReport> result = new List<AttendanceReport>();


            result = await _context.AttendanceReports.FromSql("select * from att.vattendancereport").ToListAsync();

            //foreach (AttendanceReport P in result)
            //{
            //    AttendanceReport Record = new AttendanceReport();

            //    if (result.Any(r => r.s))
            //    {

            //    }
            //}


            return result;
        }
    }
}
