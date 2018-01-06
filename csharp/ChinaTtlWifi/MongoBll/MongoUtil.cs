
using ChinaTtlWifi.NewEntity;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace MongoBll
{
    public class MongoUtil<T> where T : BaseEntity
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void DeleteAll()
        {
            this.Dao.DeleteAll();
        }

        public MongoDbBaseDao<T> Dao { get; set; }
        public MongoUtil(string MONGO_URL)
        {
            this.Dao = new MongoDbBaseDao<T>(MONGO_URL);
        }


        public T Select(string id)
        {
            return this.Dao.GetByCondition(a => a.Id == id);
        }
        public T SelectFirstBy(string name, object value)
        {
            Type elementType = typeof(T);
            if (elementType.GetProperties().Count(p => p.Name == name) < 1)
            {
                return null;
            }

            BsonValue bValue = BsonValue.Create(value);
            return this.Dao.SelectFirstBy(name, bValue);

        }
        public T SelectById(object value)
        {
            BsonValue bValue = BsonValue.Create(value);
            return this.Dao.SelectById(bValue);
        }
        public List<T> SelectBy(string name, object value)
        {
            Type elementType = typeof(T);
            if (elementType.GetProperties().Count(p => p.Name == name) < 1)
            {
                return new List<T>();
            }

            BsonValue bValue = BsonValue.Create(value);
            return this.Dao.SelectBy(name, bValue).ToList();
        }

        public List<T> SelectGT(string name, object value)
        {
            Type elementType = typeof(T);
            if (elementType.GetProperties().Count(p => p.Name == name) < 1)
            {
                return new List<T>();
            }

            BsonValue bValue = BsonValue.Create(value);
            return this.Dao.SelectGT(name, bValue).ToList();
        }

        public void InsertAutoInc(string pk, T entity)
        {
            this.Dao.Save(entity);
        }

        public void Insert(T entity)
        {
            this.Dao.Save(entity);
        }
        public void InsertEntity(T entity)
        {
            this.Insert(entity);
        }
        public void Insert(List<T> list)
        {
            foreach (var inst in list)
            {
                this.Dao.Save(inst);
            }
        }
        public void Delete(string id)
        {
            this.Dao.Delete(s => s.Id == id);
        }
        public void DeleteBy(string pk, T entity)
        {
            Type elementType = typeof(T);
            Object o = null;
            foreach (PropertyInfo propInfo in elementType.GetProperties())
            {
                if (propInfo.Name.Equals(pk))
                {
                    o = propInfo.GetValue(entity, null);
                    break;
                }
            }
            this.Dao.DeleteBy(pk, o.ToString());
            //var dbEntity = this.SelectFirstBy(pk, o);
            //if (dbEntity != null)
            //{
            //    this.Dao.Delete(dbEntity);
            //}
        }
        public void UpdateBy(string pk, T entity)
        {
            Type elementType = typeof(T);
            Object o = null;
            foreach (PropertyInfo propInfo in elementType.GetProperties())
            {
                if (propInfo.Name.Equals(pk))
                {
                    o = propInfo.GetValue(entity, null);
                    break;
                }
            }
            var old = this.SelectFirstBy(pk, o);
            if (old != null)
            {
                string tmpId = old.Id;
                old = entity;
                old.Id = tmpId;
                this.Dao.Save(old);
            }
        }
        public void UpdateById(T entity)
        {

            var old = this.SelectById(entity.Id);
            if (old != null)
            {
                string tmpId = old.Id;
                old = entity;
                old.Id = tmpId;
                this.Dao.Save(old);
            }
        }
        public void Update(string oldId, T entity)
        {
            var old = this.SelectFirstBy("_id", oldId);
            if (old != null)
            {
                string tmpId = old.Id;
                old = entity;
                old.Id = tmpId;
                this.Dao.Save(old);
            }
        }
       

        public List<T> SelectAll()
        {
            return this.Dao.GetAll().ToList();
        }

        public string UpLoadByGridFS(T entity)
        {
            string fileNameId = Guid.NewGuid().ToString();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, entity);
                memoryStream.Seek(0, SeekOrigin.Begin);
                this.Dao.UpLoadByGridFS(memoryStream, fileNameId);
            }
            return fileNameId;
        }
        public string UpLoadByGridFS(T entity, string fileNameId)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, entity);
                memoryStream.Seek(0, SeekOrigin.Begin);
                this.Dao.UpLoadByGridFS(memoryStream, fileNameId);
            }
            return fileNameId;
        }
        public T DownLoadByGridFS(string fileName)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(this.Dao.DownLoadByGridFS(fileName)))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (T)formatter.Deserialize(ms);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("GridFS 下载文件错误！" + fileName, ex);
                return null;
            }
        }

        public void DeleteByGridFS(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                this.Dao.DeleteByGridFS(fileName);
            }
        }
    }
}