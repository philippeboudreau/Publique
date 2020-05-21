using Composante;
using FluentAssertions;
using HelperMoq;
using Moq;
using System;
using System.Drawing;
using Xunit;

namespace ComposanteTest
{
    public class ClasseTestHelperMoq
    {
        private readonly HelperMockRepository _HelperMockRepository;
        private readonly HelperMock<ICollaborateur> _helperMockCollaborateur;

        private readonly Classe _classe;

        public ClasseTestHelperMoq()
        {
            _HelperMockRepository = new HelperMockRepository();
            _helperMockCollaborateur = _HelperMockRepository.Create<ICollaborateur>();

            _classe = new Classe(_helperMockCollaborateur.Object);
        }

        [Fact]
        public void Methode_1FoisAvecHelperMock_DevraitAppelerMethode1Fois()
        {
            // Arrange
            var valeur = "test";
            var repetition = 1;
            // Act

            _helperMockCollaborateur.Setup(x => x.Methode(valeur));

            _classe.Methode(valeur, repetition);
            // Asert
            _HelperMockRepository.VerifyAll();
        }

        [Fact]
        public void Methode_2FoisAvecHelperMock_DevraitAppelerMethode2Fois()
        {
            // Arrange
            var valeur = "test";
            var repetition = 2;
            // Act

            _helperMockCollaborateur.Setup(x => x.Methode(valeur), Times.Exactly(2));

            _classe.Methode(valeur, repetition);
            // Asert
            _helperMockCollaborateur.VerifyAll();
        }


        [Fact]
        public void Methode_LanceExceptionAvecHelperMock_DevraitLancerException()
        {
            // Arrange
            var valeur = "test";
            var repetition = 1;
            // Act

            _helperMockCollaborateur.Setup(x => x.Methode(valeur)).Throws(new Exception());

            Action action = () => _classe.Methode(valeur, repetition);

            // Asert
            action.Should().Throw<Exception>();
            _HelperMockRepository.VerifyAll();
        }


        [Fact]
        public void Methode2_1FoisAvecMockReposiroty_DevraitAppelerMethode1Fois()
        {
            // Arrange
            var valeur = "test";
            var repetition = 1;
            var retourMethode2 = 2;
            var retourAttendu = 2;
            // Act

            _helperMockCollaborateur.Setup(x => x.Methode2(valeur)).Returns(retourMethode2);

            var retour = _classe.Methode2(valeur, repetition);
            // Asert
            _HelperMockRepository.VerifyAll();

            retour.Should().Be(retourAttendu);
        }

        [Fact]
        public void Methode2_2FoisAvecMockReposiroty_DevraitAppelerMethode2Fois()
        {
            // Arrange
            var valeur = "test";
            var repetition = 2;
            var retourMethode2 = 2;
            var retourAttendu = 4;
            // Act
            _helperMockCollaborateur.Setup(x => x.Methode2(valeur), Times.Exactly(2)).Returns(retourMethode2);

            var retour = _classe.Methode2(valeur, repetition);
            // Asert
            _HelperMockRepository.VerifyAll();
            retour.Should().Be(retourAttendu);
        }

        [Fact]
        public void Methode2_LanceExceptionAvecMockReposiroty_DevraitLancerException()
        {
            // Arrange
            var valeur = "test";
            var repetition = 1;
            // Act

            _helperMockCollaborateur.Setup(x => x.Methode2(valeur)).Throws(new Exception());

            Action action = () => _classe.Methode2(valeur, repetition);

            // Asert
            action.Should().Throw<Exception>();
            _HelperMockRepository.VerifyAll();
        }
    }
}
