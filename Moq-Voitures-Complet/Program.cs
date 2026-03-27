using System;

namespace Moq_Voitures_Complet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var serviceExterne = new ServiceExterneSaaqSaaq();

            var garage = new Garage();
            var voiture = new Voiture(serviceExterne);

            garage.TesterVoiture(voiture);
        }
    }
}
