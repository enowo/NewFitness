using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class PosilekSzczegoly
    {
        [Required, ForeignKey("posilek")]
        public int id_posilku { get; set; }
        [Required, ForeignKey("skladnik")]
        public int id_skladnika { get; set; }
        [Required]
        public int porcja { get; set; }

        
        public virtual Posilek posilek { get; set; }
        public virtual Skladnik skladnik { get; set; }
    }
}
