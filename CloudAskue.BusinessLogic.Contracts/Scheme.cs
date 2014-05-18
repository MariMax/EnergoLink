using System;

namespace CloudAskue.BusinessLogic.Contracts
{
    public class Scheme
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid? CalcId { get; set; }
        public Guid CompanyId { get; set; }
    }
}