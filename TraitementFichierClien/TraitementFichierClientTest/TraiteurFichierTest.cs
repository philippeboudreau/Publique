using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TraitementFichierClient;
using TraitementFichierClient.Client;
using TraitementFichierClient.Interface;
using FluentAssertions;

namespace Tests
{
    [TestFixture]
    public class TraiteurFichierTest
    {
        private TraiteurFichier _traiteurFichier;
        private Mock<ILecteurFichier> _mockLecteurFichier;
        private Mock<IBaseDonnee> _mockBaseDonnee;

        [SetUp]
        public void Setup()
        {
            _mockLecteurFichier = new Mock<ILecteurFichier>();
            _mockBaseDonnee = new Mock<IBaseDonnee>();

            _traiteurFichier = new TraiteurFichier(_mockLecteurFichier.Object, _mockBaseDonnee.Object);
        }

        [Test]
        public void SiTraitementFichierEffectueeSansErreur_AlorsNeDevraitPasLancerException()
        {
            // Arranger
            var clientSournceUn = new ClientSourceUn("Nom;Prenom");

            var listeClient = new List<ClientBase>()
            {
                clientSournceUn
            };

            _mockLecteurFichier.Setup(s => s.ObtenirListeClient()).Returns(listeClient);

            // Agir
            _traiteurFichier.Executer();

            // Assurer

            _mockLecteurFichier.Verify(s => s.ObtenirListeClient());
            _mockBaseDonnee.Verify(s => s.AjouterClient(It.Is<ClientBase>(client => client.Equals(clientSournceUn))));
        }

        [Test]
        public void SiLecteurFichierLanceException_AlorsDevraitLancerException()
        {
            // Arranger

            _mockLecteurFichier.Setup(s => s.ObtenirListeClient()).Throws(new Exception());

            // Agir
            Action action = () => _traiteurFichier.Executer();

            // Assurer
            action.Should().Throw<Exception>();
            _mockLecteurFichier.Verify(s => s.ObtenirListeClient());
            _mockBaseDonnee.Verify(s => s.AjouterClient(It.IsAny<ClientBase>()), Times.Never);
        }

        [Test]
        public void SiBaseDonneeLanceException_AlorsDevraitLancerException()
        {
            // Arranger

            var clientSournceUn = new ClientSourceUn("Nom;Prenom");

            var listeClient = new List<ClientBase>()
            {
                clientSournceUn
            };

            _mockLecteurFichier.Setup(s => s.ObtenirListeClient()).Returns(listeClient);

            _mockBaseDonnee.Setup(s => s.AjouterClient(It.IsAny<ClientBase>())).Throws(new Exception());

            // Agir
            Action action = () => _traiteurFichier.Executer();

            // Assurer
            action.Should().Throw<Exception>();
            _mockLecteurFichier.Verify(s => s.ObtenirListeClient());
            _mockBaseDonnee.Verify(s => s.AjouterClient(It.IsAny<ClientBase>()));
        }
    }
}