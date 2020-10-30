using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Rola
    {
        [Key]
        public int id_roli { get; set; }
        [Required]
        public string nazwa { get; set; }

        public virtual ICollection<RolaUzytkownika> uzytkownicy { get; set; }
    }
}
