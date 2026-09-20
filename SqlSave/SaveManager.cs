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
            Connection = new SqliteConnection(userData + "/saves/Save.sav");
            Connection.Open();

            using var command = Connection.CreateCommand();
            command.CommandText = """
            CREATE TABLE IF NOT EXISTS saves(
            id INTEGER AUTOINCREMENT PRIMARY KEY
            )
            """;
            using var reader = command.ExecuteReader();

            GD.Print("Trying to read..");
            if (reader.Read())
            {
                var spell = reader.GetValue("spell");
                return (string)spell;
            }
            return null;

        }

        private void Init()
        {

        }
    }
}
