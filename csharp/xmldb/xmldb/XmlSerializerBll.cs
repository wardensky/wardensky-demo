using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
namespace wardensky.xmldb
{
    public class XmlSerializerBll<T>
    {
        private static XmlSerializerBll<T> instance;
        private string dbFile;
        public string Dbfile
        {
            get { return dbFile; }
            set
            {
                if (!string.IsNullOrEmpty(value) && !value.Equals(dbFile))
                {
                    this.entityList.Clear();
                }
                dbFile = value;
                this.ReadDb();
            }
        }
        private List<T> entityList = new List<T>();
        private XmlSerializerBll()
        {
            this.SetDbFile();
            this.ReadDb();
        }
        private void SetDbFile()
        {
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            try
            {
                if (Directory.Exists(folder) == false)
                {
                    Directory.CreateDirectory(folder);
                }
                Type type = typeof(T);
                if (string.IsNullOrEmpty(this.Dbfile))
                { this.Dbfile = Path.Combine(folder, type.Name + ".xml"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static XmlSerializerBll<T> GetInstance()
        {
            if (instance == null)
            {
                instance = new XmlSerializerBll<T>();
            }
            return instance;
        }
        public void Insert(T entity)
        {
            this.entityList.Add(entity);
            this.WriteDb();
        }
        public void InsertRange(IList<T> list)
        {
            this.entityList.AddRange(list);
            this.WriteDb();
        }
        public System.Collections.Generic.List<T> SelectBy(string name, Object value)
        {
            System.Collections.Generic.List<T> list = new List<T>();
            if (value == null)
            {
                return list;
            }
            Type t = typeof(T);
            foreach (var inst in this.entityList)
            {
                foreach (PropertyInfo pro in t.GetProperties())
                {
                    if (pro.Name.ToLower() == name.ToLower())
                    {
                        if (value.ToString() == (pro.GetValue(inst, null) ?? string.Empty).ToString())
                        {
                            list.Add(inst);
                        }
                    }
                }
            }
            return list;
        }
        public T SelectById(string id)
        {
            Type t = typeof(T);
            foreach (var inst in this.entityList)
            {
                foreach (PropertyInfo pro in t.GetProperties())
                {
                    if (pro.Name.ToLower() == "id")
                    {
                        if (id == (pro.GetValue(inst, null) ?? string.Empty).ToString())
                        {
                            return inst;
                        }
                    }
                }
            }
            return default(T);
        }
        public void UpdateById(T entity)
        {
            Type t = typeof(T);
            string id = string.Empty;
            foreach (PropertyInfo pro in t.GetProperties())
            {
                if (pro.Name.ToLower() == "id")
                {
                    id = (pro.GetValue(entity, null) ?? string.Empty).ToString();
                    break;
                }
            }
            this.DeleteById(id);
            this.Insert(entity);
        }
        public void DeleteById(string id)
        {
            Type t = typeof(T);
            T entity = default(T);
            foreach (var inst in this.entityList)
            {
                foreach (PropertyInfo pro in t.GetProperties())
                {
                    if (pro.Name.ToLower() == "id")
                    {
                        if ((pro.GetValue(inst, null) ?? string.Empty).ToString() == id)
                        {
                            entity = inst;
                            goto FinishLoop;
                        }
                    }
                }
            }
        FinishLoop:
            this.entityList.Remove(entity);
            this.WriteDb();
        }
        public List<T> SelectAll()
        {
            this.ReadDb();
            return this.entityList;
        }
        public void DeleteAll()
        {
            this.entityList.Clear();
            this.WriteDb();
        }
        private void WriteDb()
        {
            XmlSerializer ks = new XmlSerializer(typeof(List<T>));
            FileInfo fi = new FileInfo(this.Dbfile);
            var dir = fi.Directory;
            if (!dir.Exists)
            {
                dir.Create();
            }
            using (Stream writer = new FileStream(this.Dbfile, FileMode.Create, FileAccess.ReadWrite))
            {
                ks.Serialize(writer, this.entityList);
            }
        }
        private void ReadDb()
        {
            if (File.Exists(this.Dbfile))
            {
                XmlSerializer ks = new XmlSerializer(typeof(List<T>));
                Stream reader = new FileStream(this.Dbfile, FileMode.Open, FileAccess.ReadWrite);
                this.entityList = ks.Deserialize(reader) as List<T>;
                reader.Close();
            }
            else
            {
                this.entityList = new List<T>();
            }
        }
    }
}