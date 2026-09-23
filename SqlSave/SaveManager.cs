using Microsoft.Data.Sqlite;
using Godot;

namespace SqlSave
{
    public class SaveManager
    {
        public static SqliteConnection? Connection { get; set; }


        public SaveManager()
        {
            string userData = OS.GetUserDataDir();
            Connection = new SqliteConnection($"Data Source={userData}/saves/Save.sav");
            Connection.Open();

            using var command = Connection.CreateCommand();
            command.CommandText = """
            CREATE TABLE IF NOT EXISTS save(
            id INTEGER AUTOINCREMENT PRIMARY KEY
            );        
            CREATE TABLE IF NOT EXISTS saves(
            save_id INTEGER,
            FOREIGN KEY (save) REFERENCES save(id)
            );
            """;
            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                GD.Print("hello!");
            }

        }

        private void Init()
        {

        }
    }
}
