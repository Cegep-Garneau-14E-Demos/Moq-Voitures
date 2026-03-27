using System;
using System.Collections.Generic;
using System.Text;

namespace Moq_Voitures_Complet
{
    public interface IConducteur
    {
        public abstract string Nom { get; set; }
    }
    public class Conducteur: IConducteur
    {
        private string _nom;

        public virtual string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
    }
}
