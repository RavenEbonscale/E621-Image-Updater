

using Microsoft.Data.Sqlite;

namespace E621ImageDownloader.Database
{
    internal class SqlFunctions
    {

        private readonly string _connectionoath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\E621db.sqlite";

      
     
        /// <summary>
        /// Creates The Database and Fills it out with Data~
        /// </summary>
        public void CreateDatabase()
        {
            if (File.Exists(_connectionoath) == false)
            {

                File.Create(_connectionoath);
                SqliteConnection connection = new($"Data Source={_connectionoath}");


                connection.Open();
                var x = connection.State;

                string sql = "Create Table tags (tag varchar(200));";

                SqliteCommand cmd = new SqliteCommand(sql, connection);


                cmd.ExecuteNonQuery();

                sql = "Create Table ids (tag varchar(200) ,id int);";

                connection.Open();
                cmd = new SqliteCommand(sql, connection);
                cmd.ExecuteNonQuery();

                connection.Close();

                connection.Dispose();
            }


        }


        /// <summary>
        /// Read The Sql Database
        /// </summary>
        /// <returns>A list of all tags added to the database</returns>
        public async Task<List<string>> Read()
        {
            List<string> list = new List<string>();
            SqliteConnection connection = new($"Data Source={_connectionoath}");

            await connection.OpenAsync();

            string sql = "Select tag  From tags";

            SqliteCommand cmd = new SqliteCommand(sql,connection);



            using (var reader = await cmd.ExecuteReaderAsync()) {
                while (reader.Read()) {


                    string name = reader.GetString(0);

                    
                    
                
                }
            }

           
            return list;


          

        }



    }
    
}
