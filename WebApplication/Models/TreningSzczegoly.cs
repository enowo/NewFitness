using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class TreningSzczegoly
    {
        [Required, ForeignKey("trening")]
        public int id_treningu { get; set; }
        [Required, ForeignKey("cwiczenie")]
        public int id_cwiczenia { get; set; }
        [Required]
        public int liczba_powtorzen { get; set; }

        public virtual Trening trening { get; set; }
        public virtual Cwiczenie cwiczenie { get; set; }

    }
}
