using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMagazin.Models
{
    public class Comanda
    {
        [Key]
        public int IdComanda { get; set; }
        public int IdProdus { get; set; }
        public int CantitateComanda { get; set; }
        public DateOnly DataComenzii { get; set; }
        public string? NumeClient { get; set; }
    }
}
