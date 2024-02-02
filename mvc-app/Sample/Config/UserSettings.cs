namespace mvc_app.Sample.Config
{

    //public class Rootobject
    //{
    //    public Usersettings? UserSettings { get; set; }
    //}

    public class UserSettings
    {
        public Defaultuser? DefaultUser { get; set; }
    }

    public class Defaultuser
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }




}
