using System;
using System.Collections.Generic;
using System.Text;

namespace Moq_Voitures_Complet
{
     public interface IServiceExterneSaaq
    {
        int ObtenirNouveauNoSerie();
        bool ValiderSiPlaqueValide(IVoiture voiture);
    }

    public class ServiceExterneSaaqSaaq : IServiceExterneSaaq
    {
        public int ObtenirNouveauNoSerie()
        {
            Random r = new Random();
            return r.Next();
        }

        public bool ValiderSiPlaqueValide(IVoiture voiture)
        {
            return true;
        }
    }
}
