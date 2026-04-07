using Moq;
using Moq_Voitures;

namespace Moq_Voitures_Tests
{
    public class GarageTests
    {
        //Concept : Verify — valider qu'une méthode mock a été appelée
        [Test]
        public void Garage_Test_Si_TesterVoiture_Appelle_Roule()
        {
            // arrange
            Mock<Voiture> voitureMock = new Mock<Voiture>();
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