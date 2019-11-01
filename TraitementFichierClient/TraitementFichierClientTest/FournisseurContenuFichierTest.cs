using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using TraitementFichierClient;

namespace TraitementFichierClientTest
{
    [TestFixture]
    public class FournisseurContenuFichierTest
    {
        private readonly string NOM_FICHIER_TEST = "FichierTest.txt";
        private FournisseurContenuFichier _fournisseurContenuFichier;

        [SetUp]
        public void SetUp()
        {
            _fournisseurContenuFichier = new FournisseurContenuFichier();
        }

        [Test]
        public void SiFichierExiste_DevraitRetournerContenu()
        {
            // Arranger

            var contenuAttendu = new List<string>()
            {
                "Test"
            };

            // Agir

            var contenuRecu = _fournisseurContenuFichier.LireContenuFichier(NOM_FICHIER_TEST);

            // Assurer

            contenuRecu.Should().BeEquivalentTo(contenuAttendu);
        }

        [Test]
        public void SiFichierAbsent_DevraitRetournerNull()
        {
            // Agir

            var contenuRecu = _fournisseurContenuFichier.LireContenuFichier("NomFichierAbsent.txt");

            // Assurer

            contenuRecu.Should().BeEmpty();
        }
    }
}
