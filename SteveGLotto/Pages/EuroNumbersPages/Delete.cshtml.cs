using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SteveGLotto.Models;

namespace SteveGLotto.Pages.EuroNumbersPages
{
    public class DeleteModel : PageModel
    {
        private readonly SteveGLotto.Models.SteveGLottoContext _context;

        public DeleteModel(SteveGLotto.Models.SteveGLottoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EuroNumbers EuroNumbers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EuroNumbers = await _context.tblEuroNumbers.FirstOrDefaultAsync(m => m.EuroDrawID == id);

            if (EuroNumbers == null)
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

            EuroNumbers = await _context.tblEuroNumbers.FindAsync(id);

            if (EuroNumbers != null)
            {
                _context.tblEuroNumbers.Remove(EuroNumbers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
