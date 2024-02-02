namespace mvc_app.Sample.Utils
{
    public class SystemDateTime : IDateTime
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
