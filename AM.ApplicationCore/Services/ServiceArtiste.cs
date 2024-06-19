using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceArtiste : Service<Artiste>, IServiceArtiste
    {
        public ServiceArtiste(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public int NbNationnalite(Festival f, string nationnalite)
        {
            return f.Concerts.Select(c=>c.Artiste).Where(a=>a.Nationalite==nationnalite).Count();
        }

        public double PlusHautCachet(Festival f)
        {
            return f.Concerts.Where(c => c.DateConcert.Year == DateTime.Now.Year).Max(c => c.Cachet);

        }
    }
}
