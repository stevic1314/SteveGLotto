using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteveGLotto.Models
{
    public class EuroLSNumbers
    {
        [Key]
        public int EuroLSNumberID { get; set; }

        [DisplayName("number")]
        public int EuroLSNumber { get; set; }
    }
}
