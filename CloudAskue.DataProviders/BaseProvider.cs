using System;
using MongoDB.Driver;

namespace CloudAskue.DataProviders
{
    public sealed class MyMongoClient
    {
        private static volatile MyMongoClient _instance;
        public MongoDatabase Database { get; private set; }
        private static readonly object SyncRoot = new Object();

        private MyMongoClient(string connectionString)
        {
            var con = new MongoUrlBuilder(connectionString);
            var client = new MongoClient(con.ToMongoUrl());
            MongoServer server = client.GetServer();
            Database = server.GetDatabase(con.DatabaseName);
        }

        public static MyMongoClient Instance(string connectionString)
        {
            if (_instance == null)
            {
                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new MyMongoClient(connectionString);
                }
            }

            return _instance;
        }
    }

    [Serializable]
    public class BaseProvider
    {
        readonly string _connectionString;

        public BaseProvider(string connectionString)
        {
            _connectionString = connectionString;
        }


        /// <summary>
        /// Получить БД
        /// </summary>
        /// <returns></returns>
        public MongoDatabase GetDatabase()
        {
           var mclient= MyMongoClient.Instance(_connectionString);
           return mclient.Database;
        }
    }
}
