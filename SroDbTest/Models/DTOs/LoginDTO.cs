using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SroDbTest.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Kullanıcı Adı boş geçilemez")]
        [StringLength(maximumLength: 16, MinimumLength = 4, ErrorMessage = "Kullanıcı Adınız en az 4 en fazla 16 karakter uzunluğunda olabilir")]
        public string StrUserID { get; set; }
        [Required(ErrorMessage = "Parola boş geçilemez")]
        [StringLength(maximumLength: 16, MinimumLength = 6, ErrorMessage = "Şifreniz en az 6 en fazla 16 karakter uzunluğunda olabilir")]
        public string password { get; set; }


    }
}
