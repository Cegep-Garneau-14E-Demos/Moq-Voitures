using Moq;
using Moq_Voitures_Fonctionnel;

namespace Moq_Voitures_Fonctionnel_Tests
{
    public class GarageTests
    {
        //Concept : Verify — valider qu'une méthode mock a été appelée
        [Test]
        public void Garage_Test_Si_TesterVoiture_Appelle_Roule()
        {
            // arrange
            // la vraie voiture dépend d'une interface, on la remplace par un mock
            var voitureMock = new Mock<IVoiture>();
            // Setup : force le retour de True pour peutPrendreLaRoute()
            voitureMock.Setup(x => x.peutPrendreLaRoute()).Returns(true);
            Garage garage = new Garage();

            // act
            garage.TesterVoiture(voitureMock.Object);

            // assert — Verify valide que Roule() a été appelé
            voitureMock.Verify(x => x.Roule());
        }
    }
}