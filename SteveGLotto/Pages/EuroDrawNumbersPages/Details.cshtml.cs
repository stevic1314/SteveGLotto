using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SteveGLotto.Models;

namespace SteveGLotto.Pages.EuroDrawNumbersPages
{
    public class DetailsModel : PageModel
    {
        private readonly SteveGLotto.Models.SteveGLottoContext _context;

        public DetailsModel(SteveGLotto.Models.SteveGLottoContext context)
        {
            _context = context;
        }

        public EuroDrawNumbers EuroDrawNumbers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EuroDrawNumbers = await _context.tblEuroDrawNumbers.FirstOrDefaultAsync(m => m.EuroNumberID == id);

            if (EuroDrawNumbers == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
