using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;
using MoviesWebApp.Models;

namespace MoviesWebApp.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly MoviesWebApp.Data.MoviesWebAppContext _context;

        public DeleteModel(MoviesWebApp.Data.MoviesWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MoviesModel MoviesModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MoviesModel = await _context.MoviesModel.FirstOrDefaultAsync(m => m.MovieId == id);

            if (MoviesModel == null)
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

            MoviesModel = await _context.MoviesModel.FindAsync(id);

            if (MoviesModel != null)
            {
                _context.MoviesModel.Remove(MoviesModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
