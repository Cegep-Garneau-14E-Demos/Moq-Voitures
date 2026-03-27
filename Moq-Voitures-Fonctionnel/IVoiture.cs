using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moq_Voitures_Fonctionnel
{
    public interface IVoiture
    {
        void Roule();
        bool peutPrendreLaRoute();
    }
}
