using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_app.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [DisplayName("タイトル")]
        [Required(ErrorMessage = "入力必須です。")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "3文字以上、60文字以内で入力してください。")]
        public string? Title { get; set; }

        [DisplayName("リリース日")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "入力必須です。")]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("価格")]
        [Required(ErrorMessage = "入力必須です。")]
        [Range(1, 100, ErrorMessage = "1～100を入力してください。")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [DisplayName("ジャンル")]
        [Required(ErrorMessage = "入力必須です。")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "文字列を入力してください。")]
        public string? Genre { get; set; }

        [DisplayName("レーティング")]
        [StringLength(5, ErrorMessage ="5文字以内で入力してください。")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "文字列を入力してください。")]
        [Required(ErrorMessage = "入力必須です。")]
        public string? Rating { get; set; }
    }
}
