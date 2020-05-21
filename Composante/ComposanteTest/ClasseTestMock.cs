using Composante;
using FluentAssertions;
using Moq;
using System;
using System.Drawing;
using Xunit;

namespace ComposanteTest
{
    public class ClasseTestMock
    {
        private readonly Mock<ICollaborateur> _mockCollaborateur;

        private readonly Classe _classe;

        public ClasseTestMock()
        {
            _mockCollaborateur = new Mock<ICollaborateur>(MockBehavior.Strict);
            _classe = new Classe(_mockCollaborateur.Object);
        }

        [Fact]
        public void Methode_1FoisAvecMock_DevraitAppelerMethode1Fois()
        {
            // Arrange
            var valeur = "test";
            var repetition = 1;
            // Act

            _mockCollaborateur.Setup(x => x.Methode(valeur));

            _classe.Methode(valeur, repetition);
            // Asert
            _mockCollaborateur.Verify(x => x.Methode(valeur), Times.Exactly(repetition));
        }

        [Fact]
        public void Methode_2FoisAvecMock_DevraitAppelerMethode2Fois()
        {
            // Arrange
            var valeur = "test";
            var repetition = 2;
            // Act

            _mockCollaborateur.Setup(x => x.Methode(valeur));

            _classe.Methode(valeur, repetition);
            // Asert
            _mockCollaborateur.Verify(x => x.Methode(valeur), Times.Exactly(2));
        }

        [Fact]
        public void Methode_LanceExceptionAvecMock_DevraitLancerException()
        {
            // Arrange
            var valeur = "test";
            var repetition = 1;
            // Act

            _mockCollaborateur.Setup(x => x.Methode(valeur)).Throws(new Exception());

            Action action = () => _classe.Methode(valeur, repetition);

            // Asert
            action.Should().Throw<Exception>();
            _mockCollaborateur.Verify(x => x.Methode(valeur), Times.Exactly(repetition));
        }


        [Fact]
        public void Methode2_1FoisAvecMock_DevraitAppelerMethode1Fois()
        {
            // Arrange
            var valeur = "test";
            var repetition = 1;
            var retourMethode2 = 2;
            var retourAttendu = 2;
            // Act

            _mockCollaborateur.Setup(x => x.Methode2(valeur)).Returns(retourMethode2);

            var retour = _classe.Methode2(valeur, repetition);
            // Asert
            _mockCollaborateur.Verify(x => x.Methode2(valeur), Times.Exactly(repetition));

            retour.Should().Be(retourAttendu);
        }

        [Fact]
        public void Methode2_2FoisAvecMock_DevraitAppelerMethode2Fois()
        {
            // Arrange
            var valeur = "test";
            var repetition = 2;
            var retourMethode2 = 2;
            var retourAttendu = 4;
            // Act

            _mockCollaborateur.Setup(x => x.Methode2(valeur)).Returns(retourMethode2);

            var retour = _classe.Methode2(valeur, repetition);
            // Asert
            
            _mockCollaborateur.Verify(x => x.Methode2(valeur), Times.Exactly(2));
            retour.Should().Be(retourAttendu);
        }

        [Fact]
        public void Methode2_LanceExceptionAvecMock_DevraitLancerException()
        {
            // Arrange
            var valeur = "test";
            var repetition = 1;
            // Act

            _mockCollaborateur.Setup(x => x.Methode2(valeur)).Throws(new Exception());

            Action action = () => _classe.Methode2(valeur, repetition);

            // Asert
            action.Should().Throw<Exception>();
            _mockCollaborateur.Verify(x => x.Methode2(valeur), Times.Exactly(repetition));
        }
    }
}
