using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteveGLotto.Models
{
    public class LottoDrawNumbers
    {
        [Key]
        public int LottoNumberID { get; set; }

        [DisplayName("Number")]
        public int LottoNumber { get; set; }
    }
}
