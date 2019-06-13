using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SteveGLotto.Models;

namespace SteveGLotto.Pages.LottoNumbersPages
{
    public class EditModel : PageModel
    {
        private readonly SteveGLotto.Models.SteveGLottoContext _context;

        public EditModel(SteveGLotto.Models.SteveGLottoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LottoNumbers LottoNumbers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LottoNumbers = await _context.tblLottoNumbers.FirstOrDefaultAsync(m => m.LottoDrawID == id);

            if (LottoNumbers == null)
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

            _context.Attach(LottoNumbers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LottoNumbersExists(LottoNumbers.LottoDrawID))
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

        private bool LottoNumbersExists(int id)
        {
            return _context.tblLottoNumbers.Any(e => e.LottoDrawID == id);
        }
    }
}
