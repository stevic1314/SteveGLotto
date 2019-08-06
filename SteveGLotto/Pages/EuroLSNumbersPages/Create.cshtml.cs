using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SteveGLotto.Models;

namespace SteveGLotto.Pages.EuroLSNumbersPages
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
        public EuroLSNumbers EuroLSNumbers { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.tblEuroLSNumbers.Add(EuroLSNumbers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}