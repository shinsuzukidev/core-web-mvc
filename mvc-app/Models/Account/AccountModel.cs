using System.ComponentModel.DataAnnotations;

namespace mvc_app.Models.Account
{
    public class AccountModel
    {
        [RegularExpression("^[a-z]+$", ErrorMessage = "英子文字でお願いします。")]
        [Required(ErrorMessage="必須項目です。")]
        [DataType(DataType.Text)]
        [Display(Name = "UserId")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "文字サイズエラー"!)]
        public string? UserId { get; set; }

        [Required(ErrorMessage = "必須項目です。")]
        [DataType(DataType.Password)]
        [Display(Name = "パスワード")]
        public string? Password { get; set; }   
    }
}
