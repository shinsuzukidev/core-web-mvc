using mvc_app.Sample.Utils;

namespace mvc_app.Sample.Other
{
    public class Person
    {
        string _name;
        //IConfiguration _configuration;

        public string Name { get => _name; set => _name = value; }

        public Person(string name)
        {
            _name = name;

            // 設定を取得
            var defaultUserName = AppSetting.Instance.GetValue<string>("UserSettings:DefaultUser:Name");
        }
    }
}
