using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NyMathExam.Data;
using NyMathExam.Model;

namespace NyMathExam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NyGradeController : ControllerBase
    {
        private IGradeRepository _gradeRepository { get; }

        public NyGradeController(IGradeRepository gradeRepository)
        {

            _gradeRepository = gradeRepository;
        }

        [HttpGet("Summary")]
        public async Task<IEnumerable<GradeSummary>> GetSummary()
        {
            var gradescores = await _gradeRepository.GetAllScores();
            var groupqry = from score in gradescores
                      where !"All Grades".Equals(score.Grade)
                      group score by new { score.Category, score.Year } into scoreGroup
                      select new GradeSummary
                      {
                          Category = scoreGroup.Key.Category,
                          Year = scoreGroup.Key.Year,
                          NumberTestedAvg = scoreGroup.Average(s => s.NumberTested)
                      };
            var avgqry = from avgNum in groupqry
                         orderby avgNum.NumberTestedAvg descending
                         select avgNum;
            return avgqry.ToList();
        }

        [HttpGet]
        public async Task<IEnumerable<GradeScore>> Get()
        {
            return await _gradeRepository.GetAllScores();
        }
    }
}
