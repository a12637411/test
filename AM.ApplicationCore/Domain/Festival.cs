using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Festival
    {
        public int FestivalId { get; set; }
        public string Label { get; set; }
        public string Ville { get; set; }
        public int Capacite { get; set; }
        public virtual ICollection<Concert> Concerts { get; set; }


    }
}
