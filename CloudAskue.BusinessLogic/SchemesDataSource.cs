using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CloudAskue.BusinessLogic.Contracts;
using CloudAskue.DataProviders.Contracts;

namespace CloudAskue.BusinessLogic
{
    public class SchemesDataSource : ISchemesDataSource
    {
        private readonly ISchemeProvider _schemeProvider;
        private readonly ICalcGuidGenerator _calcGuidGenerator;
        private readonly IDataProvider _dataProvider;

        public SchemesDataSource(ISchemeProvider schemeProvider, ICalcGuidGenerator calcGuidGenerator, IDataProvider dataProvider)
        {
            _schemeProvider = schemeProvider;
            _calcGuidGenerator = calcGuidGenerator;
            _dataProvider = dataProvider;
        }

        public IEnumerable<SchemeInList> GetSchemes(Guid companyId, DateTime startDate, DateTime endDate)
        {
            var schemes = _schemeProvider.GetSchemes(companyId, startDate, endDate).ToList();
            return schemes;
        }

        public Guid Calc(Guid schemeId, DateTime startDate, DateTime endDate)
        {
            Guid calcId = _calcGuidGenerator.Generate(schemeId, startDate, endDate);
            Maket maket = CalculateScheme(schemeId, startDate, endDate);
            _schemeProvider.SaveMaket(calcId, maket);
            _schemeProvider.UpdateSchemeCalcId(schemeId, calcId);
            return calcId;
        }

        double CalcExpression(string formula)
        {
            double value = 0;
            const string pattern = @"(\[\w+\]\.\[\w+\])";
            var regex = new Regex(pattern);
            MatchCollection matchCollection = regex.Matches(formula);
            if (matchCollection.Count == 0)
            {
                try
                {
                    value = Double.Parse(Complex.Interpreter.CalcExpression(formula).ToString());
                }
                catch
                {
                    //Запись в лог
                    value = 0;
                }
            }
            return value;
        }

        private Maket CalculateScheme(Guid schemeId, DateTime startDate, DateTime endDate)
        {
            Maket maket = GetSchemeMaket(schemeId);
            foreach (var area in maket.Areas)
            {
                foreach (var deliveryPoint in area.DeliveryPoints)
                {
                    foreach (var measuringPoint in deliveryPoint.MeasuringPoints)
                    {
                        foreach (var measuringChannel in measuringPoint.MeasuringChannels)
                        {
                            measuringChannel.Datas.AddRange(_dataProvider.GetData(measuringPoint.Code, measuringChannel.Code, startDate, endDate,
                                                   measuringPoint.Source));
                        }
                    }
                    foreach (var solvePoint in deliveryPoint.SolvePoints)
                    {
                        foreach (var solveChannel in solvePoint.SolveChannels)
                        {
                            if (!string.IsNullOrEmpty(solveChannel.Formula))
                            {
                                var measuringKeys = deliveryPoint.GetMeasuringKeys();
                                foreach (var data in solveChannel.Datas)
                                {
                                    string formula = solveChannel.Formula;
                                    foreach (var measuringKey in measuringKeys)
                                    {
                                        if (formula.Contains(measuringKey))
                                            formula = formula.Replace(measuringKey, deliveryPoint.GetMeasuringValueByKey(measuringKey, data.Date).ToString());
                                    }
                                    data.Value = CalcExpression(formula);
                                }
                            }
                        }
                    }
                    foreach (var deliveryPointChannel in deliveryPoint.DeliveryPointChannels)
                    {
                        if (!string.IsNullOrEmpty(deliveryPointChannel.Formula))
                        {
                            var measuringKeys = deliveryPoint.GetMeasuringKeys();
                            var solveKeys = deliveryPoint.GetSolveKeys();
                            foreach (var data in deliveryPointChannel.Datas)
                            {
                                string formula = deliveryPointChannel.Formula;
                                foreach (var measuringKey in measuringKeys)
                                {
                                    if (formula.Contains(measuringKey))
                                        formula = formula.Replace(measuringKey, deliveryPoint.GetMeasuringValueByKey(measuringKey, data.Date).ToString());
                                }
                                foreach (var solveKey in solveKeys)
                                {
                                    if (formula.Contains(solveKey))
                                        formula = formula.Replace(solveKey, deliveryPoint.GetSolveValueByKey(solveKey, data.Date).ToString());
                                }
                                data.Value = CalcExpression(formula);
                            }
                        }
                    }
                }
            }
            return maket;
        }

        private Maket GetSchemeMaket(Guid schemeId)
        {
            return _schemeProvider.GetSchemeMaket(schemeId);
        }

        public Maket GetCalcResult(Guid calcId)
        {
            return _schemeProvider.GetCalcResult(calcId);
        }
    }
}
