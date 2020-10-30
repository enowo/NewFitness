using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Areas.Identity.Data;

namespace WebApplication.Models
{
    public class Trening
    {
        [Key]
        public int id_treningu { get; set; }
        [Required]
        public string nazwa { get; set; }
        [Required, ForeignKey("kategoria")]
        public int id_kategorii { get; set; }
        [Required, ForeignKey("uzytkownik")]
        public int id_uzytkownika { get; set; }

        public virtual KategoriaTreningu kategoria { get; set; }
        public virtual ICollection<TreningSzczegoly> cwiczenia { get; set; }
        public virtual Uzytkownik uzytkownik { get; set; }

    }
}
