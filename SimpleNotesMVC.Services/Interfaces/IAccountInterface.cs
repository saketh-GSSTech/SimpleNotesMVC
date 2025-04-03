using SimpleNotesMVC.Database;
using SimpleNotesMVC.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotesMVC.Services.Interfaces
{
    public interface IAccountInterface
    {
        bool RegisterUser(RegisterModelDTO register);
        UserModel LoginUser(LoginModelDTO login);

    }
}
