using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SteveGLotto.Models;

namespace SteveGLotto.Pages.LottoNumbersPages
{
    public class CreateModel : PageModel
    {
        private readonly SteveGLotto.Models.SteveGLottoContext _context;

        public CreateModel(SteveGLotto.Models.SteveGLottoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LottoNumbers LottoNumbers { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.tblLottoNumbers.Add(LottoNumbers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}