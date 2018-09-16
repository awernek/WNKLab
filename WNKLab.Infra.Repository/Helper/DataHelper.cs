using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace WNKLab.Infra.Repository.Helper
{
    public static class DataHelper
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["WNKLab"].ConnectionString;

        public static T GetFirstOrDefault<T>(SqlConnection conn, string sql)
        {
            return (T)conn.Query<T>(sql).FirstOrDefault();
        }

        public static T GetFirstOrDefault<T>(SqlConnection conn, string sql, Type[] types, Func<object[], T> values, string split)
        {
            return (T)conn.Query<T>(sql, types, values, splitOn: split).FirstOrDefault();
        }

        public static List<T> GetList<T>(SqlConnection conn, string sql)
        {
            return (List<T>)conn.Query<T>(sql).ToList();
        }

        public static List<T> GetList<T>(SqlConnection conn, string sql, Type[] types, Func<object[], T> values, string split)
        {
            return (List<T>)conn.Query<T>(sql, types, values, splitOn: split).ToList();
        }

        public static void Execute(SqlConnection conn, string sql)
        {
            //var parameters = (object)Mapping(item);
            conn.Open();
            conn.Execute(sql); //Insert<Guid>(_tableName, parameters);
        }
    }
}
