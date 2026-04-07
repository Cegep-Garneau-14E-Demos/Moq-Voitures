using Moq_Voitures_Complet;
using Moq;

namespace Moq_Voitures_Complet_Tests
{
    [TestFixture]
    public class GarageTests
    {
        //IMPORTANT : ON NE TESTE PAS LA CLASSE QU'ON MOCK.
        //Un mock est un substitut — tester le mock lui-même ne valide rien.

        //Concept : Verify — valider qu'une méthode mock a été appelée
        [Test]
        public void TesterVoiture_Appelle_Roule()
        {
            //arrange
            //la vraie voiture dépend d'un service externe, on la remplace par un mock
            Mock<IVoiture> voitureMock = new Mock<IVoiture>();
            Garage garage = new Garage();

            //act
            garage.TesterVoiture(voitureMock.Object);

            //assert — Verify confirme que Roule() a été appelé
            voitureMock.Verify(x => x.Roule());
        }

        //Concept : Setup/Returns — forcer une valeur de retour
        [Test]
        public void VendreVoiture_Fail_Si_Plaque_Invalide()
        {
            //arrange
            //note : en pratique, initialisez les mocks en membres de classe plutôt que dans chaque test
            Garage garage = new Garage();
            Mock<IVoiture> voitureMock = new Mock<IVoiture>();
            Mock<IServiceExterneSaaq> saaqMock = new Mock<IServiceExterneSaaq>();
            //Setup : It.IsAny accepte n'importe quel argument, Returns fixe la valeur retournée
            voitureMock.Setup(x => x.PeutPrendreLaRoute(It.IsAny<IServiceExterneSaaq>())).Returns(false);

            //act + assert — Assert.Throws valide qu'une exception est lancée lors de la vente
            Assert.Throws<InvalidDataException>(() => garage.VendreVoiture(voitureMock.Object, saaqMock.Object));
        }

        //Concept : Setup/Returns sur plusieurs méthodes
        [Test]
        public void VendreVoiture_RetourneLaVoiture_Si_Plaque_Valide()
        {
            //arrange
            Garage garage = new Garage();
            Mock<IServiceExterneSaaq> saaqMock = new Mock<IServiceExterneSaaq>();
            int fauxNoSerie = 12345;
            saaqMock.Setup(x => x.ObtenirNouveauNoSerie()).Returns(fauxNoSerie);
            saaqMock.Setup(x => x.ValiderSiPlaqueValide(It.IsAny<IVoiture>())).Returns(true);
            //voiture réelle créée avec un mock de la SAAQ : aura le no de série 12345
            Voiture voiture = new Voiture(saaqMock.Object);

            //act
            Voiture voitureVendu = (Voiture)garage.VendreVoiture(voiture, saaqMock.Object);

            //assert
            Assert.That(voitureVendu.NoSerie, Is.EqualTo(fauxNoSerie));
        }

        //Concept : Setup d'une propriété (la propriété doit être virtuelle pour être mockable)
        [Test]
        public void Vendre_Voiture_Fail_Si_Propriétaire_NonNull()
        {
            //arrange
            Mock<IVoiture> voitureMock = new Mock<IVoiture>();
            Mock<IServiceExterneSaaq> saaqMock = new Mock<IServiceExterneSaaq>();
            Garage garage = new Garage();
            //Setup d'une propriété : simule une voiture ayant déjà un propriétaire
            voitureMock.Setup(x => x.Proprietaire.Nom).Returns("Christo");
            saaqMock.Setup(x => x.ValiderSiPlaqueValide(It.IsAny<IVoiture>())).Returns(true);

            //act + assert — un propriétaire existant doit bloquer la vente
            Assert.Throws<InvalidDataException>(() => garage.VendreVoiture(voitureMock.Object, saaqMock.Object));
        }

        //Concept : Callback — exécuter du code lors d'un appel de mock
        [Test]
        public void Vendre_Voiture_Ajoute_Voiture_A_HistoriqueDeVente_Si_Vendue()
        {
            //arrange
            Garage garage = new Garage();
            Mock<IServiceExterneSaaq> saaqMock = new Mock<IServiceExterneSaaq>();
            int fauxNoSerie = 12345;
            int nombreDeValidationsDePlaques = 0;
            saaqMock.Setup(x => x.ObtenirNouveauNoSerie()).Returns(fauxNoSerie);
            //Callback : incrémente un compteur chaque fois que ValiderSiPlaqueValide est appelé
            saaqMock.Setup(x => x.ValiderSiPlaqueValide(It.IsAny<IVoiture>()))
                .Callback(() => nombreDeValidationsDePlaques++)
                .Returns(true);
            Voiture voiture = new Voiture(saaqMock.Object);

            //act
            Voiture voitureVendu = (Voiture)garage.VendreVoiture(voiture, saaqMock.Object);

            //assert
            Assert.That(nombreDeValidationsDePlaques, Is.EqualTo(1));
        }

        //Pour davantage d'exemples Moq :
        //https://github.com/Moq/moq4/wiki/Quickstart
        //https://github.com/morales-franco/xUnit-Moq-Demo-2

    }
}