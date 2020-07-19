using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SroDbTest.Models.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Kullanıcı Adı boş geçilemez")]
        [StringLength(maximumLength: 16, MinimumLength = 4, ErrorMessage = "Kullanıcı Adınız en az 4 en fazla 16 karakter uzunluğunda olabilir")]
        public string StrUserID { get; set; }
        [Required(ErrorMessage = "Parola boş geçilemez")]
        [StringLength(maximumLength: 16, MinimumLength = 6, ErrorMessage = "Şifreniz en az 6 en fazla 16 karakter uzunluğunda olabilir")]
        public string password { get; set; }
        [Required(ErrorMessage = "Email Adresi boş geçilemez")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir Email adresi girin")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Gizli Yanıt boş geçilemez")]
        [StringLength(maximumLength: 16, MinimumLength = 4, ErrorMessage = "Gizli Yanıtınız en az 4 en fazla 16 karakter uzunluğunda olabilir")]
        public string address { get; set; }
        public byte sec_primary { get; set; }
        public byte sec_content { get; set; }
    }
}
