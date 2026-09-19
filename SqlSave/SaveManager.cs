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
            Connection = new SqliteConnection(userData + "/save/Save.sav");

        }
    }
}
