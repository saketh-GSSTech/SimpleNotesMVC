using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotesMVC.ModelDTOs
{
    public class RegexValidationModel
    {
        public const string Email = @"^[\w\-\.]+@([\w-]+\.)+[\w-]{2,}$";
        public const string Password = @"^((?=\S*?[A-Z])(?=\S*?[a-z])(?=\S*?[0-9]).{6,})\S$";
    }
}
