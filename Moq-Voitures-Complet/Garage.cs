using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Moq_Voitures_Complet
{
    public class Garage
    {

        public void TesterVoiture(IVoiture voitureATester)
        {
            voitureATester.Roule();

        }
        public IVoiture VendreVoiture(IVoiture voitureAVendre, IServiceExterneSaaq serviceExterneSaaq)
        {

            if (voitureAVendre.PeutPrendreLaRoute(serviceExterneSaaq) && voitureAVendre.Proprietaire == null)
            {
                return voitureAVendre;
            }
            else
            {
                throw new InvalidDataException();
            }
            
        }

    }
}
