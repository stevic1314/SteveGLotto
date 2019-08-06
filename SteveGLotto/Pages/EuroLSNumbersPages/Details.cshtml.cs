using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SteveGLotto.Models;

namespace SteveGLotto.Pages.EuroLSNumbersPages
{
    public class DetailsModel : PageModel
    {
        private readonly SteveGLotto.Models.SteveGLottoContext _context;

        public DetailsModel(SteveGLotto.Models.SteveGLottoContext context)
        {
            _context = context;
        }

        public EuroLSNumbers EuroLSNumbers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EuroLSNumbers = await _context.tblEuroLSNumbers.FirstOrDefaultAsync(m => m.EuroLSNumberID == id);

            if (EuroLSNumbers == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
