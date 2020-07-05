﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
  public  class Homework35Repository
    {
        public IList<EquationReport> GetEquationReports()
        {
            using (var context = new Homework35Context())
            {
                return context.EquationReports.ToList();
            }
        }

        public void CreateEquationReport(EquationReport report)
        {
            using (var context = new Homework35Context())
            {
                context.EquationReports.Add(report);

                context.SaveChanges();
            }
        } 
    }
}