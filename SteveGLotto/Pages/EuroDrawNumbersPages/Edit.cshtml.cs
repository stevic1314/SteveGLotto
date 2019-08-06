using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SteveGLotto.Models;

namespace SteveGLotto.Pages.EuroDrawNumbersPages
{
    public class EditModel : PageModel
    {
        private readonly SteveGLotto.Models.SteveGLottoContext _context;

        public EditModel(SteveGLotto.Models.SteveGLottoContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EuroDrawNumbers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EuroDrawNumbersExists(EuroDrawNumbers.EuroNumberID))
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

        private bool EuroDrawNumbersExists(int id)
        {
            return _context.tblEuroDrawNumbers.Any(e => e.EuroNumberID == id);
        }
    }
}
