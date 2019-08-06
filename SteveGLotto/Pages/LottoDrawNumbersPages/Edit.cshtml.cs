using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SteveGLotto.Models;

namespace SteveGLotto.Pages.LottoDrawNumbersPages
{
    public class EditModel : PageModel
    {
        private readonly SteveGLotto.Models.SteveGLottoContext _context;

        public EditModel(SteveGLotto.Models.SteveGLottoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LottoDrawNumbers LottoDrawNumbers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LottoDrawNumbers = await _context.tblLottoDrawNumbers.FirstOrDefaultAsync(m => m.LottoNumberID == id);

            if (LottoDrawNumbers == null)
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

            _context.Attach(LottoDrawNumbers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LottoDrawNumbersExists(LottoDrawNumbers.LottoNumberID))
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

        private bool LottoDrawNumbersExists(int id)
        {
            return _context.tblLottoDrawNumbers.Any(e => e.LottoNumberID == id);
        }
    }
}
