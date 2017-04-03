using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GoodnaTemple.Web.ViewModel
{
    public class Ali_RegisterViewModel
    {
        [Required]
        [property: MaxLength(20, ErrorMessage = "Maximum length is 20"), MinLength(5, ErrorMessage = "Minimum length is 5")]
        public string UserName { get; set; }

        [Required]
        [property: MaxLength(20, ErrorMessage = "Maximum length is 20"), MinLength(5, ErrorMessage = "Minimum length is 5")]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}