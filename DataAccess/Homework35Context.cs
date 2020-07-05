using DataAccess.Models;
using System.Data.Entity;

namespace DataAccess
{
    public class Homework35Context : DbContext
    {
        public Homework35Context()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new CustomInitializer());
        }

        public DbSet<EquationReport> EquationReports { get; set; }
    }
}
