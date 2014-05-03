using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudAskue.BusinessLogic.Contracts;
using CloudAskue.DataProviders.Contracts;
using CloudAskueApi.Models;

namespace CloudAskue.BusinessLogic
{
    public class SchemesDataSource : ISchemesDataSource
    {
        private readonly ISchemeProvider _schemeProvider;
        private readonly ICalcGuidGenerator _calcGuidGenerator;

        public SchemesDataSource(ISchemeProvider schemeProvider, ICalcGuidGenerator calcGuidGenerator)
        {
            _schemeProvider = schemeProvider;
            _calcGuidGenerator = calcGuidGenerator;
        }

        public IEnumerable<Scheme> GetSchemes(Guid companyId, DateTime startDate, DateTime endDate)
        {
            return _schemeProvider.GetSchemes(companyId, startDate, endDate);
        }

        public Guid Calc(Guid schemeId, DateTime startDate, DateTime endDate)
        {
            return _calcGuidGenerator.Generate(schemeId, startDate, endDate);
        }

        public Maket GetCalcResult(Guid calcId)
        {
            return _schemeProvider.GetCalcResult(calcId);
        }
    }
}
