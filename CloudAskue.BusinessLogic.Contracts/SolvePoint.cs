using System.Collections.Generic;

namespace CloudAskue.BusinessLogic.Contracts
{
    public class SolvePoint
    {
        public string Code { get; set; }
        public string Desc { get; set; }
        public List<SolveChannel> SolveChannels { get; set; }

        public SolvePoint()
        {
            SolveChannels=new List<SolveChannel>();
        }
    }
}