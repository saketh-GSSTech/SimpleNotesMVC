using SimpleNotesMVC.Database;
using SimpleNotesMVC.Database.Context;
using SimpleNotesMVC.ModelDTOs;
using SimpleNotesMVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotesMVC.Services
{
    public class AccountManager:IAccountInterface
    {
        private readonly SimpleNotesMVCDbContext _context;
        public AccountManager(SimpleNotesMVCDbContext context)
        {
            _context = context;
        }

        public UserModel LoginUser(LoginModelDTO login)
        {
            var user = _context.Users.FirstOrDefault(x=>x.Email==login.Email);
            if(user == null)
            {
                return null;
            }
            bool isPasswordCheck=BCrypt.Net.BCrypt.Verify(login.Password, user.Password);
            if (!isPasswordCheck)
            {
                return null;
            }
            return user;
        }

        public bool RegisterUser(RegisterModelDTO register)
        {
            bool user=_context.Users.Any(x=>x.Email == register.Email);
            if (user)
            {
                return false;
            }

            var newUser = new UserModel
            {
                Email = register.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(register.Password)
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return true;

        }
    }
}
