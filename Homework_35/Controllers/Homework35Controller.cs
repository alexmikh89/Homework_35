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
                c.CreateMap<EquationReportPL, EquationReportDTO>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowSolutionArchives()
        {
            var solutionsDTO = _homework35Manager.GetEquationReports();
            var solutionsPL = _mapper.Map<IList<EquationReportPL>>(solutionsDTO);

            return View(solutionsPL);
        }

        public ActionResult CreateNewEquation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetEquationSolution(EquationReportPL reportPL)

        {
            var equationReportDTO = _mapper.Map<EquationReportDTO>(reportPL);

            var equationReportDTOWithRoots = _homework35Manager.CreateEquationReport(equationReportDTO);
            var equationReportPLWithRoots = _mapper.Map<EquationReportPL>(equationReportDTOWithRoots);

            ViewBag.UserName = equationReportPLWithRoots.UserName;
            ViewBag.FirstCoefficient = equationReportPLWithRoots.FirstCoefficient;
            ViewBag.SecondCoefficient = equationReportPLWithRoots.SecondCoefficient;
            ViewBag.ThirdCoefficient = equationReportPLWithRoots.ThirdCoefficient;
            ViewBag.FirstRoot = equationReportPLWithRoots.FirstRoot;
            ViewBag.SecondRoot = equationReportPLWithRoots.SecondRoot;

            return View();
        }
    }
}