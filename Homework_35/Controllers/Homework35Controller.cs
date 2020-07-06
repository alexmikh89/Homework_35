using AutoMapper;
using BusinessLogic;
using BusinessLogic.ModelsDTO;
using Homework_35.Models;
using System.Collections.Generic;
using System.Linq;
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

            var mapperConfig = new MapperConfiguration(c=> {
                c.CreateMap<EquationReportDTO, EquationReportPL>();
                c.CreateMap<EquationReportPL, EquationReportDTO>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SolutionArchives()
        {
            var solutionsDTO = _homework35Manager.GetEquationReports();
            var solutions = _mapper.Map<IList<EquationReportPL>>(solutionsDTO);

            return View(solutions);
        }

        [HttpGet]
        public ActionResult NewEquation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewEquation(EquationReportDTO reportDTO)
        {
            return View();
        }

        public ActionResult EquationSolution(EquationReportDTO reportDTO)
        {
            var solvedEquation = _homework35Manager.CreateEquationReport(reportDTO);

            ViewBag.UserName = solvedEquation.UserName;
            ViewBag.FirstCoefficient = solvedEquation.FirstCoefficient;
            ViewBag.SecondCoefficient = solvedEquation.SecondCoefficient;
            ViewBag.ThirdCoefficient = solvedEquation.ThirdCoefficient;
            ViewBag.FirstRoot = solvedEquation.FirstRoot;
            ViewBag.SecondRoot = solvedEquation.SecondRoot;
            return View();
        }
    }
}