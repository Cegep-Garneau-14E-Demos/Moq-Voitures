using System;
using System.Collections.Generic;
using System.Text;

namespace Moq_Voitures_Complet
{
    public interface IVoiture
    {
        abstract Conducteur Proprietaire { get; set; }
        void Roule();
        bool PeutPrendreLaRoute(IServiceExterneSaaq serviceExterneSaaq);
    }
}
