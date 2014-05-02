using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudAskueApi.Models;

namespace CloudAskue.BusinessLogic.Contracts
{
    public interface ISchemesDataSource
    {
        IEnumerable<Scheme> GetSchemes(Guid companyId, DateTime startDate, DateTime endDate);
        Guid Calc(Guid schemeId, DateTime startDate, DateTime endDate);
        Maket GetCalcResult(Guid calcId);
    }
}
