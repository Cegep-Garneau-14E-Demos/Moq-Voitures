using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moq_Voitures_Fonctionnel
{
    public class Garage
    {
        public void TesterVoiture(IVoiture voiture)
        {
            if (voiture.peutPrendreLaRoute())
            {
                voiture.Roule();
            }
        }
    }
}
