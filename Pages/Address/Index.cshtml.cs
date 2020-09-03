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
    public class IndexModel : PageModel
    {
        private readonly MoviesWebApp.Data.MoviesWebAppContext _context;

        public IndexModel(MoviesWebApp.Data.MoviesWebAppContext context)
        {
            _context = context;
        }

        public IList<AddressModel> AddressModel { get;set; }

        public async Task OnGetAsync()
        {
            AddressModel = await _context.AddressModel.ToListAsync();
        }
    }
}
