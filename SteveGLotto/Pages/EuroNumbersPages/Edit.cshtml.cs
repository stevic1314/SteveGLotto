using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SteveGLotto.Models;

namespace SteveGLotto.Pages.EuroNumbersPages
{
    public class EditModel : PageModel
    {
        private readonly SteveGLotto.Models.SteveGLottoContext _context;

        public EditModel(SteveGLotto.Models.SteveGLottoContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EuroNumbers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EuroNumbersExists(EuroNumbers.EuroDrawID))
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

        private bool EuroNumbersExists(int id)
        {
            return _context.tblEuroNumbers.Any(e => e.EuroDrawID == id);
        }
    }
}
