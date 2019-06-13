using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteveGLotto.Models
{
    public class LottoNumbers
    {
        [Key]
        public int LottoDrawID { get; set; }

        [DisplayName("1st")]
        public int LottoNumOne { get; set; }

        [DisplayName("2nd")]
        public int LottoNumTwo { get; set; }

        [DisplayName("3rd")]
        public int LottoNumThree { get; set; }

        [DisplayName("4th")]
        public int LottoNumFour { get; set; }

        [DisplayName("5th")]
        public int LottoNumFive { get; set; }

        [DisplayName("6th")]
        public int LottoNumSix { get; set; }
    }
}
