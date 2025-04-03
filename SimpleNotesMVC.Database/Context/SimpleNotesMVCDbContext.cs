using Microsoft.EntityFrameworkCore;
using SimpleNotesMVC.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotesMVC.Database.Context
{
    public class SimpleNotesMVCDbContext:DbContext
    {
        public SimpleNotesMVCDbContext(DbContextOptions<SimpleNotesMVCDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<NotesModel> Notes { get; set; }
    }
}
