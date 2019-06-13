using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteveGLotto.Models
{
    public class EuroNumbers
    {
        [Key]
        public int EuroDrawID { get; set; }

        [DisplayName("1st")]
        public int EuroNumOne { get; set; }

        [DisplayName("2nd")]
        public int EuroNumTwo { get; set; }

        [DisplayName("3rd")]
        public int EuroNumThree { get; set; }

        [DisplayName("4th")]
        public int EuroNumFour { get; set; }

        [DisplayName("5th")]
        public int EuroNumFive { get; set; }

        [DisplayName("LS 1")]
        public int EuroNumLSOne { get; set; }

        [DisplayName("LS 2")]
        public int EuroNumLSTwo { get; set; }
    }
}
