using Dapper;
using Microsoft.Data.SqlClient;
using Super_System_Archiwizacji_Sprzetu.Classes.DB_Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Super_System_Archiwizacji_Sprzetu.Classes
{
    public class DataBaseInteraction
    {
        private string connectionString;
        public DataBaseInteraction(string cs)
        {
            connectionString = cs;
        }
        
        public List<T> GetDataSQL<T>(string sql_query) where T : class, new()
        {

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<T>(sql_query).ToList();
                return result;
            }
        }

        public T GetSingleDataSQL<T>(string sql_query) where T : class, new()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Pobiera pojedynczy rekord z bazy danych
                var result = connection.QuerySingleOrDefault<T>(sql_query);
                if (result == null)
                    throw new InvalidOperationException("Nie znaleziono danych!");
                return result;
            }
        }

        public void InsertSQL(string sql_query)
        {

        }

        public void UpdateSQL(string sql_query)
        {

        }

    }
}
