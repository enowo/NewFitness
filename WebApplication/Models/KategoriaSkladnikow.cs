using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class KategoriaSkladnikow
    {
        [Key]
        public int id_kategorii { get; set; }
        [Required]
        public string nazwa { get; set; }

        public virtual ICollection<Skladnik> skladniki { get; set; }
    }
}
