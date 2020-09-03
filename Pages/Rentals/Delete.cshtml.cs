using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;
using MoviesWebApp.Models;

namespace MoviesWebApp.Pages.Rentals
{
    public class DeleteModel : PageModel
    {
        private readonly MoviesWebApp.Data.MoviesWebAppContext _context;

        public DeleteModel(MoviesWebApp.Data.MoviesWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RentalsModel RentalsModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RentalsModel = await _context.RentalsModel
                .Include(r => r.Movie)
                .Include(r => r.User).FirstOrDefaultAsync(m => m.RentalsId == id);

            if (RentalsModel == null)
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

            RentalsModel = await _context.RentalsModel.FindAsync(id);

            if (RentalsModel != null)
            {
                _context.RentalsModel.Remove(RentalsModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
