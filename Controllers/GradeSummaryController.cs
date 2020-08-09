using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NyMathExam.Data;
using NyMathExam.Model;

namespace NyMathExam.Controllers
{
    public class GradeSummaryController : Controller
    {
        private IGradeRepository _gradeRepository { get; }

        public GradeSummaryController(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        // GET: GradeSummaryController
        public async Task<ActionResult> Index()
        {
            var summary = await GetSummary();
            return View(summary);
        }

        private async Task<IEnumerable<GradeSummary>> GetSummary()
        {
            var gradescores = await _gradeRepository.GetAllScores();
            var groupqry = from score in gradescores
                           where !"All Grades".Equals(score.Grade)
                           group score by new { score.Category, score.Year } into scoreGroup
                           select new GradeSummary
                           {
                               Category = scoreGroup.Key.Category,
                               Year = scoreGroup.Key.Year,
                               NumberLevel2Avg = Math.Round(scoreGroup.Average(s => s.NumberLevel2), 3)
                           };
            var avgqry = from avgNum in groupqry
                         orderby avgNum.NumberLevel2Avg descending
                         select avgNum;
            return avgqry.ToList();
        }

    }
}
