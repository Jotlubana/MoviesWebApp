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

namespace MoviesWebApp.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly MoviesWebApp.Data.MoviesWebAppContext _context;

        public EditModel(MoviesWebApp.Data.MoviesWebAppContext context)
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
           ViewData["AddressId"] = new SelectList(_context.AddressModel, "AddressId", "AddressId");
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

            _context.Attach(UsersModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersModelExists(UsersModel.UserId))
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

        private bool UsersModelExists(int id)
        {
            return _context.UsersModel.Any(e => e.UserId == id);
        }
    }
}
