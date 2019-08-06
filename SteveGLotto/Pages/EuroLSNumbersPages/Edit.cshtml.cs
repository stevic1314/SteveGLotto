using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SteveGLotto.Models;

namespace SteveGLotto.Pages.EuroLSNumbersPages
{
    public class EditModel : PageModel
    {
        private readonly SteveGLotto.Models.SteveGLottoContext _context;

        public EditModel(SteveGLotto.Models.SteveGLottoContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EuroLSNumbers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EuroLSNumbersExists(EuroLSNumbers.EuroLSNumberID))
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

        private bool EuroLSNumbersExists(int id)
        {
            return _context.tblEuroLSNumbers.Any(e => e.EuroLSNumberID == id);
        }
    }
}
