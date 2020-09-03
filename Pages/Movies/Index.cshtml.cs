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
    public class IndexModel : PageModel
    {
        private readonly MoviesWebApp.Data.MoviesWebAppContext _context;

        public IndexModel(MoviesWebApp.Data.MoviesWebAppContext context)
        {
            _context = context;
        }

        public IList<MoviesModel> MoviesModel { get;set; }

        public async Task OnGetAsync()
        {
            MoviesModel = await _context.MoviesModel.ToListAsync();
        }
    }
}
