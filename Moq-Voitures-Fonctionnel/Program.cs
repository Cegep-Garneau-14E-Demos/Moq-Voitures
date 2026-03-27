using Moq_Voitures_Fonctionnel;
using System;

namespace Moq_Voitures_Fonctionnel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var garage = new Garage();
            var voiture = new Voiture();

            garage.TesterVoiture(voiture);
        }
    }
}
