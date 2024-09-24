using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDatabaseUpdater.Sql
{
    internal static class SqlFunctions
    {
        private  static readonly string _connectionoath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\E621db.sqlite";
    

        public static  async Task update(string tag)
        {
            SqliteConnection connection = new($"Data Source={_connectionoath}");

            await connection.OpenAsync();

            string command = $"Insert Into tags (tag) Values ('{tag}');";

            SqliteCommand sqliteCommand = new(command,connection);

            await sqliteCommand.ExecuteNonQueryAsync();
            await connection.CloseAsync();
            await connection.DisposeAsync();

            

            

        }
    
    
    }
}
