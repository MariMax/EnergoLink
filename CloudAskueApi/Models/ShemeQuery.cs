using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudAskueApi.Models
{
    public class ShemeQuery
    {
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        /// <summary>
        /// Дата начала интересующего периода
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Дата окончания интересующего периода
        /// </summary>
        public DateTime EndDate { get; set; }
    }
    public class CalcQuery
    {
        public Guid SchemeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}