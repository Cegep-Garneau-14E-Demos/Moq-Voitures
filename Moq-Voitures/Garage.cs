using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moq_Voitures
{
    public class Garage
    {
        public void TesterVoiture(Voiture voiture)
        {
            if (voiture.peutPrendreLaRoute())
            {
                voiture.Roule();
            }
        }
    }
}
