using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotesMVC.ModelDTOs
{
    public class RegisterModelDTO
    {
        [Required]
        [EmailAddress]
        [RegularExpression(RegexValidationModel.Email, ErrorMessage = "Invalid Email format")]
        [DefaultValue("Email")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(RegexValidationModel.Password, ErrorMessage = "Invalid password format")]
        [DefaultValue("Password")]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not mactching with confirm password")]
        [DefaultValue("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
