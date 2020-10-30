using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class KategoriaCwiczenia
    {
        [Key]
        public int id_kategorii { get; set; }
        [Required]
        public string nazwa { get; set; }


        public virtual ICollection<Cwiczenie> cwiczenia { get; set; }


        public override string ToString()
        {
            return nazwa;
        }
    }
}
