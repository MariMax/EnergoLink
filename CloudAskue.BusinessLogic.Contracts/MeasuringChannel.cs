using System.Collections.Generic;

namespace CloudAskue.BusinessLogic.Contracts
{
    public class MeasuringChannel
    {
        public string Code { get; set; }
        public string Desc { get; set; }
        public List<Data> Datas { get; set; }

        public MeasuringChannel()
        {
            Datas = new List<Data>();
        }
    }
}