using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudAskue.BusinessLogic.Contracts
{
    public class DeliveryPoint
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<DeliveryPointChannel> DeliveryPointChannels { get; set; }
        public List<MeasuringPoint> MeasuringPoints { get; set; }
        public List<SolvePoint> SolvePoints { get; set; }

        public List<string> GetSolveKeys()
        {
            List<string> result = new List<string>();
            foreach (var solvePoint in SolvePoints)
            {
                foreach (var channel in solvePoint.SolveChannels)
                {
                    string key = string.Format("[{0}].[code{1}]", solvePoint.Code, channel.Code);
                    result.Add(key);
                }
            }
            return result;
        }
        public double GetSolveValueByKey(string key, DateTime date)
        {
            foreach (var solvePoint in SolvePoints)
            {
                foreach (var channel in solvePoint.SolveChannels)
                {
                    string ckey = string.Format("[{0}].[code{1}]", solvePoint.Code, channel.Code);
                    if (ckey == key)
                    {
                        var data = channel.Datas.FirstOrDefault(s => s.Date == date);
                        return data == null ? 0 : data.Value;
                    }
                }
            }
            return 0;
        }

        public List<string> GetMeasuringKeys()
        {
            List<string> result = new List<string>();
            foreach (var measuringPoint in MeasuringPoints)
            {
                foreach (var channel in measuringPoint.MeasuringChannels)
                {
                    string key = string.Format("[{0}].[code{1}]", measuringPoint.Code, channel.Code);
                    result.Add(key);
                }
            }
            return result;
        }

        public double GetMeasuringValueByKey(string key, DateTime date)
        {
            foreach (var measuringPoint in MeasuringPoints)
            {
                foreach (var channel in measuringPoint.MeasuringChannels)
                {
                    string ckey = string.Format("[{0}].[code{1}]", measuringPoint.Code, channel.Code);
                    if (ckey == key)
                    {
                        var data=channel.Datas.FirstOrDefault(s => s.Date == date);
                        return data == null ? 0 : data.Value;
                    }
                }
            }
            return 0;
        }

        public DeliveryPoint()
        {
            DeliveryPointChannels = new List<DeliveryPointChannel>();
            MeasuringPoints = new List<MeasuringPoint>();
            SolvePoints = new List<SolvePoint>();
        }
    }
}