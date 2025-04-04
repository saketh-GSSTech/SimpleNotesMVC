﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotesMVC.Database
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email {  get; set; }
        [Required]
        public string Password { get; set; }
    }
}
