using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using SimpleNotesMVC.Database.Context;
using SimpleNotesMVC.Database.Models;
using SimpleNotesMVC.Models;

namespace SimpleNotesMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SimpleNotesMVCDbContext _context;

        public HomeController(ILogger<HomeController> logger, SimpleNotesMVCDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult SimpleNotesPage()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                Console.WriteLine("UserId is NOT found in session");
                return RedirectToAction("Login", "Account"); 
            }
            Console.WriteLine("UserId from session: " + userId);
            return View();
        }

        [HttpPost]
        public IActionResult SaveNote(string title, string description)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var note = new NotesModel
            {
                Title = title,
                Description = description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserID = userId.Value
            };
            _context.Notes.Add(note);
            _context.SaveChanges();
            return Json(new { success = true });
        }
    }
}
