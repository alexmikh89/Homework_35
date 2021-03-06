﻿namespace DataAccess.Models
{
    public class EquationReport
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
