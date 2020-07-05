using BusinessLogic;
using BusinessLogic.ModelsDTO;
using System.Linq;
using System.Web.Mvc;

namespace Homework_35.Controllers
{
    public class Homework35Controller : Controller
    {
        private readonly Homework35Manager _homework35Manager;

        public Homework35Controller()
        {
            _homework35Manager = new Homework35Manager();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SolutionArchives()
        {

            var solutions = _homework35Manager.GetEquationReports();

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
            _homework35Manager.CreateEquationReport(reportDTO);

            return RedirectToAction("EquationSolution");
        }

        public ActionResult EquationSolution()
        {
            var reportDTO = _homework35Manager.GetEquationReports().Last();
            return View(reportDTO);
        }
    }
}