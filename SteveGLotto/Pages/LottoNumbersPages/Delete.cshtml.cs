using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SteveGLotto.Models;

namespace SteveGLotto.Pages.LottoNumbersPages
{
    public class DeleteModel : PageModel
    {
        private readonly SteveGLotto.Models.SteveGLottoContext _context;

        public DeleteModel(SteveGLotto.Models.SteveGLottoContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LottoNumbers = await _context.tblLottoNumbers.FindAsync(id);

            if (LottoNumbers != null)
            {
                _context.tblLottoNumbers.Remove(LottoNumbers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
