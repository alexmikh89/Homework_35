using AutoMapper;
using BusinessLogic;
using BusinessLogic.ModelsDTO;
using Homework_35.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Homework_35.Controllers
{
    public class Homework35Controller : Controller
    {
        private readonly Homework35Manager _homework35Manager;
        private readonly Mapper _mapper;

        public Homework35Controller()
        {
            _homework35Manager = new Homework35Manager();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<EquationReportDTO, EquationReportPL>();
                c.CreateMap<EquationConditionsPL, EquationReportDTO>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowSolutionArchives()
        {
            var equationReportsDTO = _homework35Manager.GetEquationReports();
            var equationReportsPL = _mapper.Map<IList<EquationReportPL>>(equationReportsDTO);

            return View(equationReportsPL);
        }

        public ActionResult CreateNewEquation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetEquationSolution(EquationConditionsPL equationConditionsPL)
        {
            var equationReportDTO = _mapper.Map<EquationReportDTO>(equationConditionsPL);

            // Throwing equation conditions into manager and getting roots and id for equation from manager.
            var equationReportDTOWithRoots = _homework35Manager.CreateEquationReport(equationReportDTO);

            var equationReportPL = _mapper.Map<EquationReportPL>(equationReportDTOWithRoots);

            return View(equationReportPL);
        }
    }
}