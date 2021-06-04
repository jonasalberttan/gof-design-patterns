

using System.Configuration;
using System.Data.SQLite;

namespace Gof.Design.Patterns.Winforms.Patterns.Singleton
{
    public class Connection
    {
        private static Connection _instance = null;
        private static SQLiteConnection _initialize = null;
        protected Connection() { }

        public static Connection Instance
        {
            get
            {
                if (_instance == null) _instance = new Connection();
                return _instance;
            }
        }

        public SQLiteConnection Initialize
        {
            get
            {
                if (_initialize == null) _initialize = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
                return _initialize;
            }
        }

    }
}
