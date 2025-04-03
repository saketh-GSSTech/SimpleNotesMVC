using Microsoft.AspNetCore.Mvc;
using SimpleNotesMVC.Database.Context;
using SimpleNotesMVC.Database.Models;
using System.Security.Claims;

namespace SimpleNotesMVC.Controllers
{
    public class NotesController : Controller
    {
        private readonly SimpleNotesMVCDbContext _context;
        public NotesController(SimpleNotesMVCDbContext context)
        {
            _context = context;
        }

       
    }
}
