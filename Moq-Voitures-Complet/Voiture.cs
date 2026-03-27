using System;
using System.Collections.Generic;
using System.Text;

namespace Moq_Voitures_Complet
{
    public class Voiture : IVoiture
    {
        private int _noSerie;
        private  Conducteur _proprietaire;
        public int NoSerie
        {
            get { return _noSerie; }
            set { _noSerie = value; }
        }
        public Conducteur Proprietaire
        {
            get { return _proprietaire; }
            set { _proprietaire = value; }
        }


        public Voiture(IServiceExterneSaaq serviceExterneSaaq)
        {
            _noSerie = serviceExterneSaaq.ObtenirNouveauNoSerie(); //la création d'une voiture dépend d'un service externe
        }
        public void Roule()
        {
        }
        public bool PeutPrendreLaRoute(IServiceExterneSaaq serviceExterneSaaq)
        {
            return serviceExterneSaaq.ValiderSiPlaqueValide(this);
        }
    }
}
