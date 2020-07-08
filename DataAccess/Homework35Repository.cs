using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class Homework35Repository
    {
        public IList<EquationReport> GetEquationReports()
        {
            using (var context = new Homework35Context())
            {
                return context.EquationReports.ToList();
            }
        }

        public int CreateEquationReport(EquationReport report)
        {
            using (var context = new Homework35Context())
            {
                context.EquationReports.Add(report);

                context.SaveChanges();

                // Returning ID of report  (cuz I want to get ID of report).
                // While I am returning LastOrDefault's id of report in this "using" block - its, probably, 
                //not a problem for multi-thread DB using: DB is locked for this moment and I will get expected ID.
                var reportID = context.EquationReports.ToList().LastOrDefault().ID;

                return reportID;
            }
        }
    }
}
