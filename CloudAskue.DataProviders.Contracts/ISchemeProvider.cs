using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudAskue.BusinessLogic.Contracts;

namespace CloudAskue.DataProviders.Contracts
{
    public interface IDataProvider
    {
        IEnumerable<Data> GetData(string pointCode, string channelCode, DateTime startDate, DateTime endDate, int source);
    }

    public interface ISchemeProvider
    {
        IEnumerable<Scheme> GetSchemes(Guid companyId, DateTime startDate, DateTime endDate);
        Maket GetCalcResult(Guid calcId);
        void SaveMaket(Guid calcId, Maket maket);
        bool Exists(Guid calcId);
        void UpdateSchemeCalcId(Guid schemeId, Guid calcId);
        Maket GetMaket(Guid schemeId);
    }
}
