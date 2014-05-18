using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Builders;
using UCloud.Platform.DAL.Interfaces;
using UCloud.Platform.Model;
using UCloud.Platform.SDK.Entities;
using UCloud.Platform.SDK.Models;

namespace UCloud.Platform.DAL.MongoProviders
{
    public class PlatformEntityProvider : BaseProvider, IEntityProvider
    {
        public PlatformEntityProvider(string connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Добавить список сущностей
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public IEnumerable<PlatformEntity> AddEntities(IEnumerable<PlatformEntity> entities)
        {
            MongoDatabase db = GetDatabase();
            List<PlatformEntity> result = new List<PlatformEntity>();
            foreach (var platformEntityType in entities.Select(s => s.EntityType).Distinct())
            {
                EEntityType type = platformEntityType;
                IEnumerable<PlatformEntity> platformEntities = entities.Where(s => s.EntityType == type);
                //Получить таблицу, если таблица отсутсвует то она создается
                var collection = db.GetCollection(platformEntityType.ToString());
                collection.InsertBatch(platformEntities);
                result.AddRange(platformEntities);
            }
            return result;

        }

        /// <summary>
        /// Добавить в БД новую сущность
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="platformId"> </param>
        /// <returns></returns>
        public PlatformEntity AddEntity(PlatformEntity entity, Guid platformId)
        {
            MongoDatabase db = GetDatabase();
            //так как сущности в БД не существует происвоим сущности новый внутренний ИД
            entity.PlatformId = platformId;
            //Получить таблицу, если таблица отсутсвует то она создается
            var collection = db.GetCollection(entity.EntityType.ToString());
            collection.Insert(entity);
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PlatformEntity GetEntity(EEntityType entityType, Guid userId, Guid systemId, Guid platformId)
        {
            try
            {
                //Получить БД
                MongoDatabase db = GetDatabase();
                //Получить таблицу
                MongoCollection<PlatformEntity> collection = db.GetCollection<PlatformEntity>(entityType.ToString());
                //ид сущности из внешней системы
                QueryDocument query = new QueryDocument { { "SystemId", systemId }, { "PlatformId", platformId }, { "UserId", userId }, { "EntityType", (int)entityType } };
                return collection.FindOne(query);
            }
            catch (Exception)
            {
                //TODO:Запись в Лог
                return null;
            }

        }
        public IEnumerable<PlatformEntity> GetEntities(Guid userId, Guid systemId, EEntityType entityType, IEnumerable<string> entitiesIds)
        {
            //Получить БД
            MongoDatabase db = GetDatabase();
            //Проверим есть ли данная сущность в таблице соответсвия
            MongoCollection<BsonDocument> collection = db.GetCollection(entityType.ToString());
            //ид сущности из внешней системы
            List<IMongoQuery> queriesList = new List<IMongoQuery>
                {
                    new QueryDocument {{"SystemId", systemId}, {"UserId", userId}},
                    Query<PlatformEntity>.In(s => s.EntityId, entitiesIds)
                };
            var query = Query.And(queriesList);
            return collection.FindAs<PlatformEntity>(query);
        }

        public IEnumerable<Entity> GetEntitiesData(Guid userId, Guid systemId, EEntityType entityType, IEnumerable<string> entitiesIds)
        {
            return GetEntities(userId, systemId, entityType, entitiesIds).Select(pe => pe.Data);
        }

        public IEnumerable<PlatformEntity> GetEntities(Guid userId, Guid systemId, EEntityType entityType)
        {
            //Получить БД
            MongoDatabase db = GetDatabase();
            //Проверим есть ли данная сущность в таблице соответсвия
            MongoCollection<BsonDocument> collection = db.GetCollection(entityType.ToString());
            //ид сущности из внешней системы
            QueryDocument query = new QueryDocument { { "SystemId", systemId }, { "UserId", userId } };
            return collection.FindAs<PlatformEntity>(query).ToList();
        }

        public void DropAllEntities(EEntityType entityType)
        {
            //Получить БД
            MongoDatabase db = GetDatabase();
            //Удалить коллекции записей и коллекцию связей
            db.DropCollection(entityType.ToString());
        }

        public bool ExistsEntity(Guid userId, Guid connectorId, string entityId, EEntityType entityType)
        {
            return FindEntityByEntityId(userId, connectorId, entityId, entityType) != null;
        }

        public PlatformEntity FindEntityByEntityId(Guid userId, Guid connectorId, string entityId, EEntityType entityType)
        {
            //Получить БД
            MongoDatabase db = GetDatabase();
            string collectionName = string.Format("{0}", entityType.ToString());
            //Проверим есть ли данная сущность в таблице соответсвия
            MongoCollection<BsonDocument> corrCollection = db.GetCollection(collectionName);
            //ид сущности из внешней системы
            List<IMongoQuery> queriesList = new List<IMongoQuery>
                {
                    Query<PlatformEntity>.EQ(s => s.EntityId, entityId),
                    Query<PlatformEntity>.EQ(s => s.SystemId, connectorId),
                    Query<PlatformEntity>.EQ(s => s.UserId, userId)
                };
            var query = Query.And(queriesList);
            return corrCollection.FindOneAs<PlatformEntity>(query);
        }
        public PlatformEntity FindEntityByPlatformId(Guid userId, Guid connectorId, Guid platfromId, EEntityType entityType)
        {
            //Получить БД
            MongoDatabase db = GetDatabase();
            string collectionName = string.Format("{0}", entityType.ToString());
            //Проверим есть ли данная сущность в таблице соответсвия
            MongoCollection<BsonDocument> corrCollection = db.GetCollection(collectionName);
            //ид сущности из внешней системы
            List<IMongoQuery> queriesList = new List<IMongoQuery>
                {
                    Query<PlatformEntity>.EQ(s => s.PlatformId, platfromId),
                    Query<PlatformEntity>.EQ(s => s.SystemId, connectorId),
                    Query<PlatformEntity>.EQ(s => s.UserId, userId)
                };
            var query = Query.And(queriesList);
            return corrCollection.FindOneAs<PlatformEntity>(query);
        }

        public void DeleteEntity(Guid id, EEntityType entityType)
        {
            //Получить БД
            MongoDatabase db = GetDatabase();
            //Получить таблицу
            MongoCollection<PlatformEntity> collection = db.GetCollection<PlatformEntity>(entityType.ToString());
            List<IMongoQuery> queriesList = new List<IMongoQuery> {Query<PlatformEntity>.EQ(s => s.Id, id)};
            var query = Query.And(queriesList);
            collection.Remove(query);
        }
        public IEnumerable<PlatformEntity> GetEntities(Guid userId, Guid systemId, EEntityType entityType, IEnumerable<Guid> entitiesPlatformIds)
        {
            //Получить БД
            MongoDatabase db = GetDatabase();
            //Проверим есть ли данная сущность в таблице соответсвия
            MongoCollection<BsonDocument> collection = db.GetCollection(entityType.ToString());
            //ид сущности из внешней системы
            List<IMongoQuery> queriesList = new List<IMongoQuery>
                {
                    new QueryDocument {{"SystemId", systemId}, {"UserId", userId}},
                    Query<PlatformEntity>.In(s => s.PlatformId, entitiesPlatformIds)
                };
            var query = Query.And(queriesList);
            return collection.FindAs<PlatformEntity>(query).ToList();
        }

        public void UpdateEntity(PlatformEntity entity)
        {
            MongoDatabase db = GetDatabase();
            var collection = db.GetCollection(entity.EntityType.ToString());
            collection.Save(entity);
        }

        public IEnumerable<PlatformEntity> GetEntities(Guid userId, EEntityType entityType)
        {
            //Получить БД
            MongoDatabase db = GetDatabase();
            //Проверим есть ли данная сущность в таблице соответсвия
            MongoCollection<BsonDocument> collection = db.GetCollection(entityType.ToString());
            //ид сущности из внешней системы
            List<IMongoQuery> queriesList = new List<IMongoQuery>
                {
                    Query<PlatformEntity>.EQ(s => s.UserId, userId),
                    Query<PlatformEntity>.EQ(s => s.EntityType, entityType)
                };
            var query = Query.And(queriesList);
            return collection.FindAs<PlatformEntity>(query).ToList();
        }

        public IEnumerable<PlatformEntity> GetEntitiesForDelete(Guid userId, Guid systemId, EEntityType entityType)
        {
            //Получить БД
            MongoDatabase db = GetDatabase();
            //Проверим есть ли данная сущность в таблице соответсвия
            MongoCollection<BsonDocument> collection = db.GetCollection(entityType.ToString());
            //ид сущности из внешней системы
            List<IMongoQuery> queriesList = new List<IMongoQuery>
                {
                    Query<PlatformEntity>.EQ(s => s.UserId, userId),
                    Query<PlatformEntity>.EQ(s => s.SystemId, systemId),
                    Query<PlatformEntity>.EQ(s => s.EntityType, entityType),
                    Query<PlatformEntity>.EQ(s => s.IsDeleted, true)
                };
            var query = Query.And(queriesList);
            return collection.FindAs<PlatformEntity>(query).ToList();
        }

    }
}
