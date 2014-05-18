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
        private const string MaketsCollection = "Makets";
        public SchemeProvider(string connectionString)
            : base(connectionString)
        {
        }

        public IEnumerable<Scheme> GetSchemes(Guid companyId, DateTime startDate, DateTime endDate)
        {
            MongoDatabase db = GetDatabase();
            var collection = db.GetCollection(SchemesCollection);
            List<IMongoQuery> queriesList = new List<IMongoQuery>
                {
                    Query<Scheme>.EQ(s=>s.CompanyId,companyId),
                    Query<Scheme>.GTE(s => s.StartDate, startDate),
                    Query<Scheme>.LT(s => s.EndDate, endDate)
                };
            var query = Query.And(queriesList);
            return collection.FindAs<Scheme>(query);
        }

        public Maket GetCalcResult(Guid calcId)
        {
            MongoDatabase db = GetDatabase();
            var collection = db.GetCollection(MaketsCollection);
            var maketInStorage = (MaketInStorage)collection.FindOneByIdAs(typeof(MaketInStorage), calcId);
            return maketInStorage;
        }

        public void SaveMaket(Guid calcId, Maket maket)
        {
            MongoDatabase db = GetDatabase();
            var collection = db.GetCollection(MaketsCollection);
            var maketInStorage = new MaketInStorage(calcId, maket);
            collection.Save(maketInStorage);
        }

        public bool Exists(Guid calcId)
        {
            MongoDatabase db = GetDatabase();
            var collection = db.GetCollection(MaketsCollection);
            return (bool)collection.Find(Query<MaketInStorage>.Exists(s => s.CalcId == calcId)).FirstOrDefault();
        }

        public void UpdateSchemeCalcId(Guid schemeId, Guid calcId)
        {
            MongoDatabase db = GetDatabase();
            var collection = db.GetCollection(SchemesCollection);
            collection.Update(Query<Scheme>.EQ(s => s.Id, schemeId), Update<Scheme>.Set(s => s.CalcId, calcId));
        }

        public Maket GetMaket(Guid schemeId)
        {
            throw new NotImplementedException();
        }

        private class MaketInStorage : Maket
        {
            [BsonId]
            public Guid CalcId { get; set; }

            public MaketInStorage(Guid calcId, Maket maket)
            {
                CalcId = calcId;
                this.Areas = maket.Areas;
            }
        }
    }
}
