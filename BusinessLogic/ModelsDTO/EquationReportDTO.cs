using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ModelsDTO
{
    public class EquationReportDTO
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public double FirstCoefficient { get; set; }
        public double SecondCoefficient { get; set; }
        public double ThirdCoefficient { get; set; }
        public double? FirstRoot { get; set; }
        public double? SecondRoot { get; set; }
    }
}
