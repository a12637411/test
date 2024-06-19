using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceChanson : Service<Chanson>, IServiceChanson
    {
        public ServiceChanson(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    

        public void GetMusicalStyle(StyleMusical st)
        {
           var req= GetMany(c => c.StyleMusical == st).Select(c => c.Artiste).SelectMany(a => a.Concerts);
            foreach(var item in req)
                Console.WriteLine("Date: "+item.DateConcert+"Ville: "+item.Festival.Ville);
        }

        public IEnumerable<string> GetSongsTitles(Artiste a)
        {
            return GetMany(c => (DateTime.Now - c.DateSortie).TotalDays < 730 && c.Artiste == a)
                .OrderBy(c => c.VuesYoutube).Take(5).Select(c => c.Titre);     }
    }
}
