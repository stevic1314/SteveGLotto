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
    public class DeleteModel : PageModel
    {
        private readonly SteveGLotto.Models.SteveGLottoContext _context;

        public DeleteModel(SteveGLotto.Models.SteveGLottoContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EuroLSNumbers = await _context.tblEuroLSNumbers.FindAsync(id);

            if (EuroLSNumbers != null)
            {
                _context.tblEuroLSNumbers.Remove(EuroLSNumbers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
