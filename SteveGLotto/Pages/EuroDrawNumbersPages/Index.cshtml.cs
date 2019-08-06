using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SteveGLotto.Models;

namespace SteveGLotto.Pages.EuroDrawNumbersPages
{
    public class IndexModel : PageModel
    {
        private readonly SteveGLotto.Models.SteveGLottoContext _context;

        public IndexModel(SteveGLotto.Models.SteveGLottoContext context)
        {
            _context = context;
        }

        public IList<EuroDrawNumbers> EuroDrawNumbers { get;set; }

        public async Task OnGetAsync()
        {
            EuroDrawNumbers = await _context.tblEuroDrawNumbers.ToListAsync();
        }
    }
}
