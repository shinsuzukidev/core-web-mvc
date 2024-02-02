namespace mvc_app.Sample.Other
{
    public class Person
    {
        string _name;
        IConfiguration _configuration;

        public string Name { get => _name; set => _name = value; }

        public Person(string name, IConfiguration configuration)
        {
            _name = name;

            _configuration = configuration;
            var defaultUserName = _configuration["UserSettings:DefaultUser:Name"];
        }
    }
}
