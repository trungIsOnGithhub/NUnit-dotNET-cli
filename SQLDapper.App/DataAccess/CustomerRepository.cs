using System;
using System.IO;
using Dapper;
using System.Data.SQLite;

using SQLDapper.Model;

namespace SQLDapper.DataAccess
{
    public interface ICustomerRepository
    {
        Customer getOne(long Id);
        void saveOne(Customer newCustomer);
    }

    public class CustomerRepository : SqlBaseRepository, ICustomerRepository
    {
        public void saveOne(Customer newCustomer)
        {
            if (!File.Exists(DbFile))
            {
                CreateDatabase();
            }

            CreateTableCustomerIfNotExists();

            using (var conn = GetSimpleDbConnection())
            {
                conn.Open();
                conn.Query<long>(@"INSERT INTO Customer 
                    ( FirstName, LastName, BirthYear )
                    VALUES ( @FirstName, @LastName, @BirthYear );
                    SELECT last_insert_rowid()", newCustomer
                ).Single();
            }
        }

        public Customer getOne(long Id)
        {
            throw new NotImplementedException();
        }

        public void CreateTableCustomerIfNotExists()
        {
            using (var conn = GetSimpleDbConnection())
            {
                conn.Open();
                conn.Execute(@"CREATE TABLE IF NOT EXISTS Customer(
                    Id integer primary key AUTOINCREMENT,
                    FirstName varchar(100) not null,
                    LastName varchar(100) not null,
                    BirthYear integer not null
                )");
            }
        }
    }
}