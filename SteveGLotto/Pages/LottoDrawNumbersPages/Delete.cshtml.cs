using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SteveGLotto.Models;

namespace SteveGLotto.Pages.LottoDrawNumbersPages
{
    public class DeleteModel : PageModel
    {
        private readonly SteveGLotto.Models.SteveGLottoContext _context;

        public DeleteModel(SteveGLotto.Models.SteveGLottoContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LottoDrawNumbers = await _context.tblLottoDrawNumbers.FindAsync(id);

            if (LottoDrawNumbers != null)
            {
                _context.tblLottoDrawNumbers.Remove(LottoDrawNumbers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
