using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudAskue.BusinessLogic.Contracts;
using CloudAskueApi.Models;

namespace CloudAskue.DataProviders.Contracts
{
    public interface ISchemeProvider
    {
        IEnumerable<Scheme> GetSchemes(Guid companyId, DateTime startDate, DateTime endDate);
        Maket GetCalcResult(Guid calcId);
    }
}
