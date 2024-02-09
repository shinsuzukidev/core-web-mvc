using System.ComponentModel.DataAnnotations;

namespace mvc_app.Models
{
    public class EnumDefines 
    {
        public enum CountryEnum
        {
            [Display(Name = "United Mexican States")]
            Mexico = 0,
            [Display(Name = "United States of America")]
            USA,
            [Display(Name = "Canada...")]
            Canada,
            [Display(Name = "France...")]
            France,
        }
    }

}
