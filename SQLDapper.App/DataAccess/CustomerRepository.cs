using System;
using System.IO;
using Dapper;
using System.Data.SQLite;

using SQLDapper.Model;

namespace SQLDapper.DataAccess
{
    public interface ICustomerRepository
    {
        Customer GetOne(long Id);
        void SaveOne(Customer newCustomer);
    }

    public class CustomerRepository : SqlBaseRepository, ICustomerRepository
    {
        public void SaveOne(Customer newCustomer)
        {
            if (!File.Exists(DbFile))
            {
                throw new NullReferenceException();
            }

            using (var conn = GetSimpleDbConnection())
            {
                conn.Open();
                conn.Query<long>(@"INSERT INTO Customer 
                    ( FirstName, LastName, BirthYear )
                    VALUES ( @FirstName, @LastName, @BirthYear );
                    SELECT last_insert_rowid()", newCustomer
                ).First();
            }
        }

        public Customer GetOne(long id)
        {
            if (!File.Exists(DbFile))
            {
                throw new NullReferenceException();
            }

            Customer customer;

            using (var conn = GetSimpleDbConnection())
            {
                conn.Open();
                customer = conn.Query<Customer>(@"SELECT
                    Id, FirstName, LastName, BirthYear
                    FROM Customer
                    WHERE Id = @id", new { id }
                ).FirstOrDefault();
            }

            return customer;
        }

        public int GetNumberOfCustomer()
        {
            int numberOfCustomer;

            using (var conn = GetSimpleDbConnection())
            {
                conn.Open();
                numberOfCustomer = conn.Query<int>("SELECT COUNT(*) FROM Customer").First();
            }

            return numberOfCustomer;
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