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
    public class IndexModel : PageModel
    {
        private readonly SteveGLotto.Models.SteveGLottoContext _context;

        public IndexModel(SteveGLotto.Models.SteveGLottoContext context)
        {
            _context = context;
        }

        public IList<LottoDrawNumbers> LottoDrawNumbers { get;set; }

        public async Task OnGetAsync()
        {
            LottoDrawNumbers = await _context.tblLottoDrawNumbers.ToListAsync();
        }
    }
}
