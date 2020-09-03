using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;
using MoviesWebApp.Models;

namespace MoviesWebApp.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly MoviesWebApp.Data.MoviesWebAppContext _context;

        public DeleteModel(MoviesWebApp.Data.MoviesWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UsersModel UsersModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UsersModel = await _context.UsersModel
                .Include(u => u.Address).FirstOrDefaultAsync(m => m.UserId == id);

            if (UsersModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UsersModel = await _context.UsersModel.FindAsync(id);

            if (UsersModel != null)
            {
                _context.UsersModel.Remove(UsersModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
