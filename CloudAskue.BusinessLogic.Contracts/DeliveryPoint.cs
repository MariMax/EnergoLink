using System.Collections.Generic;

namespace CloudAskue.BusinessLogic.Contracts
{
    public class DeliveryPoint
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<DeliveryPointChannel> DeliveryPointChannels { get; set; }
        public List<MeasuringPoint> MeasuringPoints { get; set; }
        public List<SolvePoint> SolvePoints { get; set; }

        public DeliveryPoint()
        {
            DeliveryPointChannels=new List<DeliveryPointChannel>();
            MeasuringPoints=new List<MeasuringPoint>();
            SolvePoints=new List<SolvePoint>();
        }
    }
}