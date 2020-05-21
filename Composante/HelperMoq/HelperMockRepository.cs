using Moq;
using System.Collections.Generic;

namespace HelperMoq
{
    public class HelperMockRepository
    {
        private MockBehavior _mockBehavior;
        private List<HelperMockBase> _listeMock;

        public HelperMockRepository()
        {
            _mockBehavior = MockBehavior.Strict;
            _listeMock = new List<HelperMockBase>();
        }

        public HelperMockRepository(MockBehavior mockBehavior)
        {
            _mockBehavior = mockBehavior;
            _listeMock = new List<HelperMockBase>();
        }
        public HelperMock<T> Create<T>() where T : class
        {
            var mock = new HelperMock<T>(_mockBehavior);

            _listeMock.Add(mock);

            return mock;
        }

        public void VerifyAll()
        {
            foreach (var mock in _listeMock)
            {
                mock.VerifyAll();
            }

        }

    }


}
