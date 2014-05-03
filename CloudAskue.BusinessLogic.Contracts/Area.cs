using System.Collections.Generic;

namespace CloudAskue.BusinessLogic.Contracts
{
    public class Area
    {
        public string Name { get; set; }
        public List<DeliveryPoint> DeliveryPoints { get; set; }

        public Area()
        {
            DeliveryPoints=new List<DeliveryPoint>();
        }
    }
}