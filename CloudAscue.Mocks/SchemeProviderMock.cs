using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudAskue.BusinessLogic.Contracts;
using CloudAskue.DataProviders.Contracts;

namespace CloudAscue.Mocks
{
    public class SchemeProviderMock : ISchemeProvider
    {
        public IEnumerable<SchemeInList> GetSchemes(Guid companyId, DateTime startDate, DateTime endDate)
        {
            return new List<SchemeInList>
                       {
                           new SchemeInList{
                           Id = Guid.Parse("15DFD5F7-D61C-495F-9574-5E62CAF39B52"),
                           Name = "ОАО \"Челябэнергосбыт\"",
                           },
                           new SchemeInList{
                           Id = Guid.Parse("F3518B55-F4C4-4836-8063-43F2591C4761"),
                           Name = "\"ЭСКБ\"",
                           CalcId = Guid.NewGuid()
                           },
                       };
        }

        private List<Data> GetDatas()
        {
            List<Data> datas = new List<Data>();
            DateTime dateTime = new DateTime(2014, 4, 1);
            for (int i = 0; i < 1439; i++)
            {
                datas.Add(new Data { Date = dateTime, Value = i });
                dateTime = dateTime.AddMinutes(30);
            }
            return datas;
        }

        private MeasuringChannel GetChannel(string name, string code)
        {
            MeasuringChannel measuringChannel = new MeasuringChannel();
            measuringChannel.Code = code;
            measuringChannel.Desc = name;
            measuringChannel.Datas.AddRange(GetDatas());
            return measuringChannel;
        }

        private SolveChannel GetSolveChannel(string name, string code)
        {
            SolveChannel solveChannel = new SolveChannel();
            solveChannel.Code = code;
            solveChannel.Desc = name;
            solveChannel.Datas.AddRange(GetDatas());
            return solveChannel;
        }

        private DeliveryPointChannel GetDeliveryPointChannel(string name, string code)
        {
            DeliveryPointChannel pointChannel = new DeliveryPointChannel();
            pointChannel.Code = code;
            pointChannel.Desc = name;
            pointChannel.Datas.AddRange(GetDatas());
            return pointChannel;
        }

        public Maket GetCalcResult(Guid calcId)
        {
            Maket maket = new Maket();
            Area area = new Area();
            area.Name = "ОАО \"Челябэнергосбыт\"";
            DeliveryPoint deliveryPoint = new DeliveryPoint();
            deliveryPoint.Code = "dp1";
            deliveryPoint.Name = "ВЛ-110 кВ Узельга Межозерная и Узельга ПС 60";
            MeasuringPoint measuringPoint1 = new MeasuringPoint();
            measuringPoint1.Code = "mp1";
            measuringPoint1.Desc = "ПС Узельга 6 кВ Т1 №1";
            measuringPoint1.MeasuringChannels.Add(GetChannel("Активная энергия(Прием)", "mc1"));
            measuringPoint1.MeasuringChannels.Add(GetChannel("Активная энергия(Отдача)", "mc2"));
            measuringPoint1.MeasuringChannels.Add(GetChannel("Реактивная энергия(Прием)", "mc3"));
            measuringPoint1.MeasuringChannels.Add(GetChannel("Реактивная энергия(Отдача)", "mc4"));
            deliveryPoint.MeasuringPoints.Add(measuringPoint1);
            SolvePoint solvePoint = new SolvePoint();
            solvePoint.Desc = "Потери на вводе 6 кВ Т1 №1";
            solvePoint.SolveChannels.Add(GetSolveChannel("Активная энергия(Прием)", "mc1"));
            solvePoint.SolveChannels.Add(GetSolveChannel("Активная энергия(Отдача)", "mc1"));
            solvePoint.SolveChannels.Add(GetSolveChannel("Реактивная энергия(Прием)", "mc1"));
            solvePoint.SolveChannels.Add(GetSolveChannel("Реактивная энергия(Отдача)", "mc1"));
            deliveryPoint.SolvePoints.Add(solvePoint);

            deliveryPoint.DeliveryPointChannels.Add(GetDeliveryPointChannel("Активная энергия(Прием)", "mc1"));
            deliveryPoint.DeliveryPointChannels.Add(GetDeliveryPointChannel("Активная энергия(Отдача)", "mc1"));
            deliveryPoint.DeliveryPointChannels.Add(GetDeliveryPointChannel("Реактивная энергия(Прием)", "mc1"));
            deliveryPoint.DeliveryPointChannels.Add(GetDeliveryPointChannel("Реактивная энергия(Отдача)", "mc1"));

            area.DeliveryPoints.Add(deliveryPoint);
            maket.Areas.Add(area);
            return maket;
        }

        public void UpdateSchemeCalcId(Guid schemeId, Guid calcId)
        {
            throw new NotImplementedException();
        }

        public Maket GetSchemeMaket(Guid schemeId)
        {
            throw new NotImplementedException();
        }

        public void SaveMaket(Guid calcId, Maket maket)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Guid calcId)
        {
            throw new NotImplementedException();
        }
    }
}
