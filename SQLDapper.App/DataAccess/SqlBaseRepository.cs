using System;
using System.IO;
using Dapper;
using System.Data.SQLite;

namespace SQLDapper.DataAccess
{
    public class SqlBaseRepository
    {
        private SQLiteConnection? DbConnCache;

        protected static string DbFolder = "Database";
        protected static string DbFileName = "test.sqlite";
        protected static string DbFile = Environment.CurrentDirectory + Path.DirectorySeparatorChar + DbFolder + Path.DirectorySeparatorChar + DbFileName;

        public static SQLiteConnection GetSimpleDbConnection()
        {
            // if (DbConnCache is null)
            // {
                return new SQLiteConnection("Data Source=" + DbFile);
            // }
            // return DbConnCache;
        }

        public void CreateDatabase()
        {
            // create database with dummy table
            using (var conn = GetSimpleDbConnection())
            {
                conn.Open();
                conn.Execute("CREATE TABLE IF NOT EXISTS dummy(dummycol BOOLEAN)");
                Console.WriteLine("hihi");
            }
        }
    }
}