using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace NyMathExam.Data
{
    public class CsvGradeScoreMap : ClassMap<GradeScore>
    {
        public CsvGradeScoreMap()
        {
            Map(m => m.Grade).Name("Grade");
            Map(m => m.Year).Name("Year");
            Map(m => m.Category).Name("Category");
            Map(m => m.NumberTested).Name("Number Tested");
            Map(m => m.MeanScaleScore).Name("Mean Scale Score");
            Map(m => m.NumberLevel1).Name("# Level 1");
            Map(m => m.PercentLevel1).Name("% Level 1");
            Map(m => m.NumberLevel2).Name("# Level 2");
            Map(m => m.PercentLevel2).Name("% Level 2");
            Map(m => m.NumberLevel3).Name("# Level 3");
            Map(m => m.PercentLevel3).Name("% Level 3");
            Map(m => m.NumberLevel4).Name("# Level 4");
            Map(m => m.PercentLevel4).Name("% Level 4");
            Map(m => m.NumberLevel3p4).Name("# Level 3+4");
            Map(m => m.PercentLevel3p4).Name("% Level 3+4");
        }
    }

}
