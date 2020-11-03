using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Areas.Identity.Data;

namespace WebApplication.Models
{
    public class Ocena
    {
        [Required, ForeignKey("oceniajacy")]
        public int id_uzytkownika_oceniajacego { get; set; }
        [Required, ForeignKey("oceniany")]
        public int id_uzytkownika_ocenianego { get; set; }
        [Required]
        public double ocena { get; set; }
        [Required, ForeignKey("rola")]
        public int id_roli { get; set; }

        public virtual Uzytkownik oceniany { get; set; }
        public virtual Uzytkownik oceniajacy { get; set; }
        public virtual Rola rola { get; set; }
    }
}
