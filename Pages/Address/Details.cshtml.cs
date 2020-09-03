using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;
using MoviesWebApp.Models;

namespace MoviesWebApp.Pages.Address
{
    public class DetailsModel : PageModel
    {
        private readonly MoviesWebApp.Data.MoviesWebAppContext _context;

        public DetailsModel(MoviesWebApp.Data.MoviesWebAppContext context)
        {
            _context = context;
        }

        public AddressModel AddressModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AddressModel = await _context.AddressModel.FirstOrDefaultAsync(m => m.AddressId == id);

            if (AddressModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
