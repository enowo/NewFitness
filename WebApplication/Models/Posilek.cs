using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Areas.Identity.Data;

namespace WebApplication.Models
{
    public class Posilek
    {
        [Key]
        public int id_posilku { get; set; }
        [Required]
        public string nazwa { get; set; }
        [Required]
        public int kalorie { get; set; }
        public string opis { get; set; }
        [Required, ForeignKey("uzytkownik")]
        public int id_uzytkownika { get; set; }

        public virtual ICollection<PosilekSzczegoly> skladniki { get; set; }
        public virtual Uzytkownik uzytkownik { get; set; }
    }
}
