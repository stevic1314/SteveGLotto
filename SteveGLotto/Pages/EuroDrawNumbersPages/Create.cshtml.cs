﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SteveGLotto.Models;

namespace SteveGLotto.Pages.EuroDrawNumbersPages
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
        public EuroDrawNumbers EuroDrawNumbers { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.tblEuroDrawNumbers.Add(EuroDrawNumbers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}