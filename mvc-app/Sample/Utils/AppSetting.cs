
namespace mvc_app.Sample.Utils
{
    public class AppSetting 
    {
        private static IConfigurationRoot? _configurationRoot;

        public static IConfigurationRoot? Instance {
            get
            {
                if (_configurationRoot != null)
                {
                    return _configurationRoot;
                } 
                else
                {
                    throw new Exception("MyConig Error!");
                }
            }

            set
            {
                _configurationRoot = value;
            }
        }
    }
}
