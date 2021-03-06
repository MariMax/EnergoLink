﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CloudAskue.BusinessLogic.Contracts;
using CloudAskueApi.Models;
using System.Web.Http.Cors;

namespace CloudAskueApi.Controllers
{
    public class XCalculatorController : ApiController
    {
        private readonly ISchemesDataSource _schemesDataSource;

        public XCalculatorController(ISchemesDataSource schemesDataSource)
        {
            _schemesDataSource = schemesDataSource;
        }


        //http://localhost:2226/api/XCalculator/GetSchemes?CompanyId=3DC72D1C-1DA4-425C-ACFA-99DE60C89BCB
        /// <summary>
        /// Функция отдает список схем доступных пользователю компании за определенный срок
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetSchemes(ShemeQuery query)
        {
            var schemes = _schemesDataSource.GetSchemes(query.CompanyId, query.StartDate, query.EndDate);
            return Request.CreateResponse(HttpStatusCode.OK, new { Schemes = schemes });
        }

        /// <summary>
        /// Получить результат расчета
        /// </summary>
        /// <param name="calcId"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCalcResult([FromUri]Guid calcId)
        {
            var calcResult = _schemesDataSource.GetCalcResult(calcId);
            return Request.CreateResponse(HttpStatusCode.OK, new { CalcResult = calcResult });
        }

        /// <summary>
        /// Запустить расчет
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Calc(CalcQuery query)
        {
            var calcId = _schemesDataSource.Calc(query.SchemeId, query.StartDate, query.EndDate);
            return Request.CreateResponse(HttpStatusCode.OK, new { CalcId = calcId });
        }
    }
}