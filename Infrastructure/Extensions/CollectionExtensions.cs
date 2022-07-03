using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CsvHelper.Configuration.Attributes;

namespace Infrastructure.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<List<T>> Partition<T>(this IList<T> source, int size)
        {
            for (var i = 0; i < Math.Ceiling(source.Count / (double)size); i++)
                yield return new List<T>(source.Skip(size * i).Take(size));
        }

        public static DataTable ToDataTable<T>(this IList<T> source)
        {
            var dt = new DataTable();
            var props = typeof(T).GetProperties();
            
            foreach (var prop in props)
            {
                var attrs = prop.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    if (!(attr is NameAttribute authAttr)) continue;
                    var propName = prop.Name;
                    dt.Columns.Add(propName, prop.PropertyType);
                }
            }
            
            foreach (var item in source)
            {
                var row = dt.NewRow();
                foreach (var prop in props)
                {
                    var attrs = prop.GetCustomAttributes(true);
                    foreach (var attr in attrs)
                    {
                        if (!(attr is NameAttribute authAttr)) continue;
                        var propName = prop.Name;
                        row[propName] = prop.GetValue(item, null);
                    }
                }
                dt.Rows.Add(row);
            }
            
            return dt;
        }
    }
}