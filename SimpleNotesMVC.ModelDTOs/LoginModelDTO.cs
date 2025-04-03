using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotesMVC.ModelDTOs
{
    public class LoginModelDTO
    {
        public int Id { get; set; }
        public string Email {  get; set; }
        public string Password { get; set; }
    }
}
