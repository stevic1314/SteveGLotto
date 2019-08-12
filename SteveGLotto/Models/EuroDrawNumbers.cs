using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteveGLotto.Models
{
    public class EuroDrawNumbers
    {
        [Key]
        public int EuroNumberID { get; set; }

        [DisplayName("number")]
        public int EuroNumber { get; set; }
    }
}
