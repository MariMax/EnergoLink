using System;

namespace CloudAskue.BusinessLogic.Contracts
{
    public interface ICalcGuidGenerator
    {
        Guid Generate(Guid schemeId, DateTime startDate, DateTime endDate);
    }
}