using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceArtiste:IService<Artiste>
    {
        double PlusHautCachet(Festival f);
        int NbNationnalite(Festival f, string nationnalite);

    }
}
