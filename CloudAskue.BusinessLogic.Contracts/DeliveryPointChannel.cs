using System.Collections.Generic;

namespace CloudAskue.BusinessLogic.Contracts
{
    public class DeliveryPointChannel
    {
        public string Code { get; set; }
        public string Desc { get; set; }
        public string Formula { get; set; }
        public List<Data> Datas { get; set; }

        public DeliveryPointChannel()
        {
            Datas=new List<Data>();
        }
    }
}