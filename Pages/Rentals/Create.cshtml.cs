using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Data;
using MoviesWebApp.Models;

namespace MoviesWebApp.Pages.Rentals
{
    public class CreateModel : PageModel
    {
        private readonly MoviesWebApp.Data.MoviesWebAppContext _context;

        public CreateModel(MoviesWebApp.Data.MoviesWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MovieId"] = new SelectList(_context.MoviesModel, "MovieId", "MovieId");
        ViewData["UserId"] = new SelectList(_context.UsersModel, "UserId", "UserId");
            return Page();
        }

        [BindProperty]
        public RentalsModel RentalsModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RentalsModel.Add(RentalsModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
