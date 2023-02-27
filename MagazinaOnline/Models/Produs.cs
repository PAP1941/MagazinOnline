using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMagazin.Models
{
    public class Produs
    {

        [Key]
        public int IdProdus { get; set; }
        public string? Denumire { get; set; }
        public int Cantitate { get; set; }
        public double Pret { get; set; }
        public DateOnly DataAdaugare { get; set; }
    }
}
