namespace mvc_app.Sample.Config
{
    public class AppWebSettings 
    {
        public string? Name { get; set; }

        public DatabaseSettings? DatabaseSettings { get; set; }
    }

    public class DatabaseSettings
    {
        public string? Host { get; set; }
        public int Port { get; set; }
    }
}
