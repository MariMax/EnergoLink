using System;
using System.Security.Cryptography;
using System.Text;
using CloudAskue.BusinessLogic.Contracts;

namespace CloudAskue.BusinessLogic
{
    public class CalcGuidGenerator : ICalcGuidGenerator
    {
        public Guid Generate(Guid schemeId, DateTime startDate, DateTime endDate)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                string value = schemeId.ToString() + startDate.ToString() + endDate.ToString();
                byte[] hash = sha1.ComputeHash(Encoding.Default.GetBytes(value));
                return Guid.NewGuid();
            }
        }
    }
}