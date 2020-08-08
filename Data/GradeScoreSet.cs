using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NyMathExam.Data
{
    public class GradeScoreSet : IGradeRepository
    {
        private readonly string _gradeScoreUrl;
        private readonly CsvConfiguration _csvConfiguration;
        private readonly IHttpClientFactory _clientFactory;
        public GradeScoreSet(ConstProvider constProvider, CsvConfiguration csvConfiguration, IHttpClientFactory clientFactory)
        {
            _gradeScoreUrl = constProvider.GradeScoreUrl;
            _csvConfiguration = csvConfiguration;
            _clientFactory = clientFactory;
            RegisterCsvMap();
        }

        private void RegisterCsvMap()
        {
            _csvConfiguration.RegisterClassMap<CsvGradeScoreMap>();
        }
        public async Task<IEnumerable<GradeScore>> GetAllScores()
        {
            var client = _clientFactory.CreateClient();
            using (HttpResponseMessage response = await client.GetAsync(_gradeScoreUrl))
            using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
            using (var sr = new StreamReader(streamToReadFrom))
            {
                var csv = new CsvReader(sr, _csvConfiguration);
                var allRecords = csv.GetRecords<GradeScore>();                
                return allRecords.ToList();
            }
        }
    }
}
