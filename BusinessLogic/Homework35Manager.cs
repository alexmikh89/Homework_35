using AutoMapper;
using BusinessLogic.ModelsDTO;
using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Homework35Manager
    {
        private readonly Homework35Repository _homework35Repository;
        private readonly Mapper _mapper;

        public Homework35Manager()
        {
            _homework35Repository = new Homework35Repository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<EquationReportDTO, EquationReport>();
                c.CreateMap<EquationReport, EquationReportDTO>();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public IList<EquationReportDTO> GetEquationReports()
        {
            var equationReports = _homework35Repository.GetEquationReports();
            return _mapper.Map<IList<EquationReportDTO>>(equationReports);
        }

        public EquationReportDTO CreateEquationReport(EquationReportDTO reportDTO)
        {
            var discriminant = Math.Pow(reportDTO.SecondCoefficient, 2) - 4 * reportDTO.FirstCoefficient * reportDTO.ThirdCoefficient;

            if (discriminant == 0)
            {
                reportDTO.FirstRoot = (-1 * reportDTO.SecondCoefficient) / (2 * reportDTO.FirstCoefficient);
            }

            if (discriminant > 0)
            {
                reportDTO.FirstRoot = (-1 * reportDTO.SecondCoefficient + Math.Sqrt(discriminant)) / (2 * reportDTO.FirstCoefficient);
                reportDTO.SecondRoot = (-1 * reportDTO.SecondCoefficient - Math.Sqrt(discriminant)) / (2 * reportDTO.FirstCoefficient);
            }

            _homework35Repository.CreateEquationReport(_mapper.Map<EquationReport>(reportDTO));

            return reportDTO;
        }
    }
}
