using Moq_Voitures_Fonctionnel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moq_Voitures_Fonctionnel
{
    public class Voiture : IVoiture
    {
        public void Roule()
        {

        }

        public bool peutPrendreLaRoute()
        {
            return false;
        }
    }
}
