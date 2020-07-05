using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomInitializer 
        : DropCreateDatabaseAlways<Homework35Context>
    {
        protected override void Seed(Homework35Context context)
        {
            var report1 = new EquationReport()
            {
                UserName = "First test user",
                FirstCoefficient = 11,
                SecondCoefficient = 21,
                ThirdCoefficient = 31,
                FirstRoot = 41,
                SecondRoot = 51
            };
            context.EquationReports.Add(report1);

            
            var report2 = new EquationReport()
            {
                UserName = "Second test user",
                FirstCoefficient = 12,
                SecondCoefficient = 22,
                ThirdCoefficient = 32,
                FirstRoot = null,
                SecondRoot = 52
            };
            context.EquationReports.Add(report2);

            context.SaveChanges();
        }
    }
}
