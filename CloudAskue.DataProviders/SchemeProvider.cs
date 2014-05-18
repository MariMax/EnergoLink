using System;
using System.Collections.Generic;
using System.Linq;
using CloudAskue.BusinessLogic.Contracts;
using CloudAskue.DataProviders.Contracts;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace CloudAskue.DataProviders
{
    public class SchemeProvider : BaseProvider, ISchemeProvider
    {
        private const string SchemesCollection = "Schemes";
        private const string CalculationsCollection = "Calculations";
        public SchemeProvider(string connectionString)
            : base(connectionString)
        {
        }

        public IEnumerable<SchemeInList> GetSchemes(Guid companyId, DateTime startDate, DateTime endDate)
        {
            MongoDatabase db = GetDatabase();
            var collection = db.GetCollection(SchemesCollection);
            var queriesList = new List<IMongoQuery>
                {
                    Query<SchemeInStorage>.EQ(s=>s.CompanyId,companyId),
                    Query<SchemeInStorage>.GTE(s => s.StartDate, startDate),
                    Query<SchemeInStorage>.LT(s => s.EndDate, endDate)
                };
            var query = Query.And(queriesList);
            var schemeInStorages= collection.FindAs<SchemeInStorage>(query);
            if (schemeInStorages == null)
                return null;
            return schemeInStorages.Select(inStorage => new SchemeInList {CalcId = inStorage.CalcId, Name = inStorage.Name, Id = inStorage.Id}).ToList();
        }

        public Maket GetCalcResult(Guid calcId)
        {
            MongoDatabase db = GetDatabase();
            var collection = db.GetCollection(CalculationsCollection);
            var maketInStorage = (MaketInStorage)collection.FindOneByIdAs(typeof(MaketInStorage), calcId);
            return maketInStorage;
        }

        public void SaveMaket(Guid calcId, Maket maket)
        {
            MongoDatabase db = GetDatabase();
            var collection = db.GetCollection(CalculationsCollection);
            var maketInStorage = new MaketInStorage(calcId, maket);
            collection.Save(maketInStorage);
        }

        public bool Exists(Guid calcId)
        {
            MongoDatabase db = GetDatabase();
            var collection = db.GetCollection(CalculationsCollection);
            return (bool)collection.Find(Query<MaketInStorage>.Exists(s => s.CalcId == calcId)).FirstOrDefault();
        }

        public void UpdateSchemeCalcId(Guid schemeId, Guid calcId)
        {
            MongoDatabase db = GetDatabase();
            var collection = db.GetCollection(SchemesCollection);
            collection.Update(Query<SchemeInList>.EQ(s => s.Id, schemeId), Update<SchemeInList>.Set(s => s.CalcId, calcId));
        }

        public Maket GetSchemeMaket(Guid schemeId)
        {
            MongoDatabase db = GetDatabase();
            var collection = db.GetCollection(CalculationsCollection);
            var maketInStorage = (SchemeInStorage)collection.FindOneByIdAs(typeof(SchemeInStorage), schemeId);
            if (maketInStorage == null)
                return null;
            return maketInStorage.Maket;
        }

        private class MaketInStorage : Maket
        {
            [BsonId]
            public Guid CalcId { get; set; }

            public MaketInStorage(Guid calcId, Maket maket)
            {
                CalcId = calcId;
                Areas = maket.Areas;
            }
        }

        private class SchemeInStorage
        {
            [BsonId]
            public Guid Id { get; set; }
            public string Name { get; set; }
            public Guid? CalcId { get; set; }
            public Guid CompanyId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            /// <summary>
            /// путь к макету схемы
            /// </summary>
            public MaketInStorage Maket { get; set; }
        }
    }
}
