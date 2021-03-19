namespace DisposableEmailValidation.Models
{
    public class AppSettings
    {
        public string Title { get; set; }
        public string Environment { get; set; }
        public bool Debug { get; set; }
        public Database Database { get; set; }
    }

    public class Database
    {
        public int DBCommandTimeout { get; set; }
        public Connectionstrings ConnectionStrings { get; set; }
    }

    public class Connectionstrings
    {
        public string Utils { get; set; }
        public string Users { get; set; }
    }
}