using System.IO;

using Wisdombud.Mongo;
using Wisdombud.MongoDb;
using System.Linq;
using System.Collections.Generic;
using System;
using Wims.Common.Entity;
using Wisdombud.BLL;


namespace ChinaTtlWifi.NewBll
{
    public class BackupDataBll<T> where T : BaseEntity
    {

        public static void ExportData(string folder)
        {
            var list = new BaseBllImpl<T>().SelectAll();
            if (list != null && list.Count > 0)
            {
                FormatterSerializerBll<T>.ExportData(Path.Combine(folder, typeof(T).Name + ".wdb"), list);
            }
        }

        public static void ExportSingleData(string folder, List<T> list)
        {
            if (list != null && list.Count > 0)
            {
                FormatterSerializerBll<T>.ExportData(Path.Combine(folder, typeof(T).Name + DateTime.Now.ToString("yyyyMMddhhmmss") + ".wdb"), list);
            }
        }

        public static void BackuData(string folder, string name)
        {
            var list = new BaseBllImpl<T>().SelectAll();
            if (list != null && list.Count > 0)
            {
                FormatterSerializerBll<T>.ExportData(Path.Combine(folder, name + ".wdb"), list);
            }
        }
        //还原数据
        public static void ImportData(string fullName)
        {
            var imps = FormatterSerializerBll<T>.ImportData(fullName);
            var dataBll = new BaseBllImpl<T>();
            dataBll.DeleteAll();
            foreach (var imp in imps)
            {
                dataBll.Add(imp);
            }
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="fullName"></param>
        public static void InsertData(string fullName)
        {
            var imps = FormatterSerializerBll<T>.ImportData(fullName);
            var dataBll = new BaseBllImpl<T>();
            foreach (var imp in imps)
            {
                dataBll.Delete(p => p.Id == imp.Id);
                dataBll.Add(imp);
            }
        }

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="fullName"></param>
        public static void DaoRuData(string fullName)
        {
            var imps = FormatterSerializerBll<T>.ImportData(fullName);
            var dataBll = new BaseBllImpl<T>();
            foreach (var imp in imps)
            {
                imp.Id = "";
                dataBll.Add(imp);
            }
        }
    }

}
