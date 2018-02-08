using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace wardensky.zUI
{
    public sealed class GenricReflectToolkit
    {
        public static int GetElementsNumber<T>(T t, List<string> ignoreFields)
        {
            return GenReflectElements(t, ignoreFields).Count;
        }

        public static List<RowEntity> GenReflectElements<T>(T entity, List<string> ignoreFields)
        {
            List<RowEntity> list = new List<RowEntity>();
            if (entity == null)
            {
                entity = System.Activator.CreateInstance<T>();
            }
            int index = 1;
            Type type = typeof(T);
            foreach (PropertyInfo pi in type.GetProperties())
            {
                if (ignoreFields.Contains(pi.Name))
                {
                    continue;
                }
                RowEntity row = new RowEntity();
                list.Add(row);
                object[] objs = pi.GetCustomAttributes(typeof(DescriptionAttribute), true);
                string descName = objs.Length > 0 ? ((DescriptionAttribute)objs[0]).Description : pi.Name;
                row.Key = pi.Name;
                row.Name = descName;
                row.Value = pi.GetValue(entity, null) ?? string.Empty;
                row.Index = index++;
                row.Type = ControlType.TEXT_BOX;
                if (pi.PropertyType == typeof(DateTime))
                {
                    row.Type = ControlType.DATE_TIME;
                }
                row.DataType = pi.PropertyType;
            }
            return list;
        }
    }
}
