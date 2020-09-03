using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;
using MoviesWebApp.Models;

namespace MoviesWebApp.Pages.Rentals
{
    public class EditModel : PageModel
    {
        private readonly MoviesWebApp.Data.MoviesWebAppContext _context;

        public EditModel(MoviesWebApp.Data.MoviesWebAppContext context)
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
           ViewData["MovieId"] = new SelectList(_context.MoviesModel, "MovieId", "MovieId");
           ViewData["UserId"] = new SelectList(_context.UsersModel, "UserId", "UserId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RentalsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalsModelExists(RentalsModel.RentalsId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RentalsModelExists(int id)
        {
            return _context.RentalsModel.Any(e => e.RentalsId == id);
        }
    }
}
