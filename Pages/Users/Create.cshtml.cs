using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Data;
using MoviesWebApp.Models;

namespace MoviesWebApp.Pages.Users
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
        ViewData["AddressId"] = new SelectList(_context.AddressModel, "AddressId", "AddressId");
            return Page();
        }

        [BindProperty]
        public UsersModel UsersModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UsersModel.Add(UsersModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
