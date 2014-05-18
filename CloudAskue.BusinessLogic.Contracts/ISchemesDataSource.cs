using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAskue.BusinessLogic.Contracts
{
    public interface ISchemesDataSource
    {
        /// <summary>
        /// Функция отдает список схем доступных пользователю компании за определенный срок
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        IEnumerable<SchemeInList> GetSchemes(Guid companyId, DateTime startDate, DateTime endDate);
        Guid Calc(Guid schemeId, DateTime startDate, DateTime endDate);
        Maket GetCalcResult(Guid calcId);
    }
}
