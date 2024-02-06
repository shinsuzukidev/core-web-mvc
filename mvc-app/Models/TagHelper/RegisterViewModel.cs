﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mvc_app.Models.TagHelper
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="入力必須です。")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "文字サイズエラー"!)]
        [DataType(DataType.Text)]
        [Display(Name = "名前")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "入力必須です。")]
        [EmailAddress]
        [Display(Name = "メールアドレス")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "入力必須です。")]
        [DataType(DataType.Password)]
        [Display (Name = "パスワード")]
        public string? Password { get; set; }

        [Required]
        [DisplayName("チェックボックス（テスト）")]
        public bool IsChecked { get; set; }

        [Required(ErrorMessage = "入力必須です。")]
        [DisplayName("メモ")]
        [StringLength(maximumLength: 1024, ErrorMessage = "文字サイズエラー"!)]
        public string? Memo { get; set; }

        [Required(ErrorMessage = "必須項目です")]
        [DisplayName("国")]
        public string? Country { get; set; } // = "CA";
        //public IEnumerable<string> Country { get; set; } = new string[]{ "CA", "US" };    // こちらだと複数選択可能
        public List<SelectListItem> Countries { get; }  = new List<SelectListItem>() 
        {
            new SelectListItem { Value = "", Text = "NO-Select" },
            new SelectListItem { Value = "MX", Text = "Mexico" },
            new SelectListItem { Value = "CA", Text = "Canada" },
            new SelectListItem { Value = "US", Text = "USA"  },
        };


        [HiddenInput]
        public string? ExeType { get; set; }

    }
}

