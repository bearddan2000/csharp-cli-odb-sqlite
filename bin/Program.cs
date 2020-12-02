using System;
using System.Data;
using Mono.Data.Sqlite;

namespace CSharpConsol
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string connectionString = "URI=file:person.db";
            IDbConnection dbcon = new SqliteConnection(connectionString);
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                const string sql = "SELECT name, age FROM person";
                dbcmd.CommandText = sql;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        int age = reader.GetInt32(1);
                        Console.WriteLine("Name: {0}, Age: {1}", name, age);
                    }
                }
            }
            dbcon.Close();
        }
    }
}
