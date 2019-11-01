using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TraitementFichierClient;
using TraitementFichierClient.Client;
using TraitementFichierClient.Interface;

namespace TraitementFichierClientTest
{
    [TestFixture]
    public class LecteurFichierTest
    {
        private Mock<IFournisseurContenuFichier> _mockFournisseurContenuFichier;

        private LecteurFichier _lecteurFichier;

        [SetUp]
        public void SetUp()
        {
            _mockFournisseurContenuFichier = new Mock<IFournisseurContenuFichier>();
            _lecteurFichier = new LecteurFichier(_mockFournisseurContenuFichier.Object);
        }

        public class ExecuterTest : LecteurFichierTest
        {
            private const string NOM_FICHIER_SOURCE_UN = "FichierSourceUn.txt";
            private const string NOM_FICHIER_SOURCE_DEUX = "FichierSourceDeux.txt";
            private const string NOM_FICHIER_SOURCE_TROIS = "FichierSourceTrois.txt";

            [Test]
            public void SiExecuterAvecAucuneSource_AlorsDevraitRetournerListeClientVide()
            {
                // Arranger

                _mockFournisseurContenuFichier.Setup(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_UN)).Returns(new List<string>());
                _mockFournisseurContenuFichier.Setup(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_DEUX)).Returns(new List<string>());
                _mockFournisseurContenuFichier.Setup(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_TROIS)).Returns(new List<string>());

                // Agir
                var listeClientRecu = _lecteurFichier.ObtenirListeClient();

                // Assurer
                _mockFournisseurContenuFichier.Verify(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_UN));
                _mockFournisseurContenuFichier.Verify(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_DEUX));
                _mockFournisseurContenuFichier.Verify(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_TROIS));

                listeClientRecu.Should().BeEmpty();

            }

            [Test]
            public void SiExecuterAvecSourceUnSeulement_AlorsDevraitRetournerClientSourceUnSeulement()
            {
                // Arranger
                var nom = "Nom";
                var prenom = "Prenom";

                var ligneFichierSourceUn = $"{nom};{prenom}";

                var contenuFichierSourceUn = new List<string>()
                {
                    ligneFichierSourceUn
                };

                var listeClientAttendu = new List<ClientBase>()
                {
                    new ClientSourceUn(ligneFichierSourceUn)
                };

                _mockFournisseurContenuFichier.Setup(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_UN)).Returns(contenuFichierSourceUn);
                _mockFournisseurContenuFichier.Setup(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_DEUX)).Returns(new List<string>());
                _mockFournisseurContenuFichier.Setup(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_TROIS)).Returns(new List<string>());

                // Agir
                var listeClientRecu = _lecteurFichier.ObtenirListeClient();

                // Assurer
                _mockFournisseurContenuFichier.Verify(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_UN));
                _mockFournisseurContenuFichier.Verify(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_DEUX));
                _mockFournisseurContenuFichier.Verify(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_TROIS));

                listeClientRecu.Should().BeEquivalentTo(listeClientAttendu);

            }

            [Test]
            public void SiExecuterAvecSourceDeuxSeulement_AlorsDevraitRetournerClientSourceDeuxSeulement()
            {
                // Arranger
                var nom = "Nom";
                var prenom = "Prenom";

                var ligneFichierSourceDeux = $"NULL|NULL|{nom}|{prenom}";

                var contenuFichierSourceDeux = new List<string>()
                {
                    ligneFichierSourceDeux
                };

                var listeClientAttendu = new List<ClientBase>()
                {
                    new ClientSourceDeux(ligneFichierSourceDeux)
                };

                _mockFournisseurContenuFichier.Setup(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_UN)).Returns(new List<string>());
                _mockFournisseurContenuFichier.Setup(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_DEUX)).Returns(contenuFichierSourceDeux);
                _mockFournisseurContenuFichier.Setup(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_TROIS)).Returns(new List<string>());

                // Agir
                var listeClientRecu = _lecteurFichier.ObtenirListeClient();

                // Assurer
                _mockFournisseurContenuFichier.Verify(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_UN));
                _mockFournisseurContenuFichier.Verify(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_DEUX));
                _mockFournisseurContenuFichier.Verify(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_TROIS));

                listeClientRecu.Should().BeEquivalentTo(listeClientAttendu);
            }

            [Test]
            public void SiExecuterAvecSourceTroisSeulement_AlorsDevraitRetournerClientSourceTroisSeulement()
            {
                // Arranger
                var nom = "Nom";
                var prenom = "Prenom";

                var ligneFichierSourceTrois = $"NULL&NULL&NULL&NULL&NULL&{nom}&{prenom}";

                var contenuFichierSourceTrois = new List<string>()
                {
                    ligneFichierSourceTrois
                };

                var listeClientAttendu = new List<ClientBase>()
                {
                    new ClientSourceTrois(ligneFichierSourceTrois)
                };

                _mockFournisseurContenuFichier.Setup(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_UN)).Returns(new List<string>());
                _mockFournisseurContenuFichier.Setup(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_DEUX)).Returns(new List<string>());
                _mockFournisseurContenuFichier.Setup(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_TROIS)).Returns(contenuFichierSourceTrois);

                // Agir
                var listeClientRecu = _lecteurFichier.ObtenirListeClient();

                // Assurer
                _mockFournisseurContenuFichier.Verify(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_UN));
                _mockFournisseurContenuFichier.Verify(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_DEUX));
                _mockFournisseurContenuFichier.Verify(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_TROIS));

                listeClientRecu.Should().BeEquivalentTo(listeClientAttendu);
            }

            [Test]
            public void SiExecuterAvecPlusieursSource_AlorsDevraitRetournerClientPlusieursSource()
            {
                // Arranger
                var nomSoruceUn = "NomUn";
                var prenomSourceUn = "PrenomUn";
                var nomSoruceDeux = "NomDeux";
                var prenomSourceDeux = "PrenomDeux";
                var nomSoruceTrois = "NomTrois";
                var prenomSourceTrois = "PrenomTrois";

                var ligneFichierSourceUn = $"{nomSoruceUn};{prenomSourceUn}";
                var ligneFichierSourceDeux = $"NULL|NULL|{nomSoruceDeux}|{prenomSourceDeux}";
                var ligneFichierSourceTrois = $"NULL&NULL&NULL&NULL&NULL&{nomSoruceTrois}&{prenomSourceTrois}";

                var contenuFichierSourceUn = new List<string>()
                {
                    ligneFichierSourceUn
                };

                var contenuFichierSourceDeux = new List<string>()
                {
                    ligneFichierSourceDeux,
                };

                var contenuFichierSourceTrois = new List<string>()
                {
                    ligneFichierSourceTrois
                };

                var listeClientAttendu = new List<ClientBase>()
                {
                    new ClientSourceUn(ligneFichierSourceUn),
                    new ClientSourceDeux(ligneFichierSourceDeux),
                    new ClientSourceTrois(ligneFichierSourceTrois)
                };

                _mockFournisseurContenuFichier.Setup(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_UN)).Returns(contenuFichierSourceUn);
                _mockFournisseurContenuFichier.Setup(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_DEUX)).Returns(contenuFichierSourceDeux);
                _mockFournisseurContenuFichier.Setup(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_TROIS)).Returns(contenuFichierSourceTrois);

                // Agir
                var listeClientRecu = _lecteurFichier.ObtenirListeClient();

                // Assurer
                _mockFournisseurContenuFichier.Verify(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_UN));
                _mockFournisseurContenuFichier.Verify(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_DEUX));
                _mockFournisseurContenuFichier.Verify(f => f.LireContenuFichier(NOM_FICHIER_SOURCE_TROIS));

                listeClientRecu.Should().BeEquivalentTo(listeClientAttendu);
            }
        }
    }
}
