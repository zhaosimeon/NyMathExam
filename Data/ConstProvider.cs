using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NyMathExam.Data
{
    public class ConstProvider
    {        

        public ConstProvider(string gradeScoreUrl)
        {
            GradeScoreUrl = gradeScoreUrl;
        }

        public string GradeScoreUrl { get; }
    }
}
