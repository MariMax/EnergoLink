using System.Collections.Generic;

namespace CloudAskue.BusinessLogic.Contracts
{
    public class MeasuringPoint
    {
        public string Code { get; set; }
        public string Desc { get; set; }
        public int Source { get; set; }
        public List<MeasuringChannel> MeasuringChannels { get; set; }

        public MeasuringPoint()
        {
            MeasuringChannels=new List<MeasuringChannel>();
        }
    }
}