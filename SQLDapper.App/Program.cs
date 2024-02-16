using SQLDapper.Model;
using SQLDapper.DataAccess;

namespace SQLDapper.App
{
    public class Program
    {
        /// https://stackoverflow.com/questions/6651554/random-number-in-long-range-is-this-the-way
        /// <summary>
        /// Generates a random alphanumeric string.
        /// </summary>
        /// <param name="length">The desired length of the string</param>
        /// <returns>The string which has been generated</returns>
        public static string GenerateRandomAlphanumericString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        
            var random       = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }
        public static void Main(string[] args)
        {
            var newCustomer = new Customer {
                FirstName = GenerateRandomAlphanumericString(4),
                LastName = GenerateRandomAlphanumericString(6),
                BirthYear = (new Random()).Next(1990, 2004)
            };

            var repository = new CustomerRepository();

            repository.CreateTableCustomerIfNotExists();

            repository.SaveOne(newCustomer);

            int numberOfCustomer = repository.GetNumberOfCustomer();

            for (int id = 1; id <= numberOfCustomer; ++id)
            {
                Console.WriteLine(repository.GetOne(id));
            }
        }
    }
}