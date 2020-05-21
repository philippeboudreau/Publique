using Moq;
using Moq.Language;
using Moq.Language.Flow;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HelperMoq
{
    public class HelperMock<T> : HelperMockBase where T : class
    {
        private readonly Mock<T> _mock;
        private readonly MockBehavior _mockBehavior;
        private List<Action> _listeAction;

        public HelperMock(MockBehavior mockBehavior)
        {
            _listeAction = new List<Action>();
            _mock = new Mock<T>(_mockBehavior);
            _mockBehavior = mockBehavior;
        }

        public virtual T Object => _mock.Object;

        #region Setup

        public ISetup<T> Setup(Expression<Action<T>> expression) => Setup(expression, Times.Once());

        public ISetup<T> Setup(Expression<Action<T>> expression, Times times)
        {

            _listeAction.Add(() => _mock.Verify(expression, times));

            return _mock.Setup(expression);
        }

        public ISetup<T, TResult> Setup<TResult>(Expression<Func<T, TResult>> expression) => Setup(expression, Times.Once());

        public ISetup<T, TResult> Setup<TResult>(Expression<Func<T, TResult>> expression, Times times)
        {
            _listeAction.Add(() => _mock.Verify(expression, times));

            return _mock.Setup(expression);
        }

        public ISetup<T> SetupAdd(Action<T> addExpression) => SetupAdd(addExpression, Times.Once());

        public ISetup<T> SetupAdd(Action<T> addExpression, Times times)
        {
            _listeAction.Add(() => _mock.VerifyAdd(addExpression, times));

            return _mock.SetupAdd(addExpression);
        }

        public Mock<T> SetupAllProperties() => _mock.SetupAllProperties();

        public ISetupGetter<T, TProperty> SetupGet<TProperty>(Expression<Func<T, TProperty>> expression) => SetupGet(expression, Times.Once());

        public ISetupGetter<T, TProperty> SetupGet<TProperty>(Expression<Func<T, TProperty>> expression, Times times)
        {
            _listeAction.Add(() => _mock.VerifyGet(expression, times));

            return _mock.SetupGet(expression);
        }

        public Mock<T> SetupProperty<TProperty>(Expression<Func<T, TProperty>> property, TProperty initialValue) => _mock.SetupProperty(property, initialValue);

        public Mock<T> SetupProperty<TProperty>(Expression<Func<T, TProperty>> property) => _mock.SetupProperty(property);

        public ISetup<T> SetupRemove(Action<T> removeExpression) => SetupRemove(removeExpression, Times.Once());

        public ISetup<T> SetupRemove(Action<T> removeExpression, Times times)
        {
            _listeAction.Add(() => _mock.VerifyRemove(removeExpression, times));

            return _mock.SetupRemove(removeExpression);
        }

        public ISetupSequentialResult<TResult> SetupSequence<TResult>(Expression<Func<T, TResult>> expression) => _mock.SetupSequence(expression);

        public ISetup<T> SetupSet(Action<T> setterExpression) => SetupSet(setterExpression, Times.Once());

        public ISetup<T> SetupSet(Action<T> setterExpression, Times times)
        {
            _listeAction.Add(() => _mock.VerifySet(setterExpression, times));

            return _mock.SetupSet(setterExpression);
        }

        public ISetupSetter<T, TProperty> SetupSet<TProperty>(Action<T> setterExpression) => SetupSet<TProperty>(setterExpression, Times.Once());

        public ISetupSetter<T, TProperty> SetupSet<TProperty>(Action<T> setterExpression, Times times)
        {
            _listeAction.Add(() => _mock.VerifySet(setterExpression, times));

            return _mock.SetupSet<TProperty>(setterExpression);
        }

        #endregion

        #region Verify

        public void Verify(Expression<Action<T>> expression) => Verify(expression, Times.Once());

        public void Verify(Expression<Action<T>> expression, Times times)
        {
            _mock.Verify(expression, times);
        }

        public void Verify<TResult>(Expression<Func<T, TResult>> expression) => Verify(expression, Times.Once());

        public void Verify<TResult>(Expression<Func<T, TResult>> expression, Times times)
        {
            _mock.Verify(expression, times);
        }

        public void VerifyAdd(Action<T> addExpression) => VerifyAdd(addExpression, Times.Once());

        public void VerifyAdd(Action<T> addExpression, Times times)
        {
            _mock.VerifyAdd(addExpression, times);
        }

        public void VerifyGet<TProperty>(Expression<Func<T, TProperty>> expression) => VerifyGet(expression, Times.Once());

        public void VerifyGet<TProperty>(Expression<Func<T, TProperty>> expression, Times times)
        {
            _mock.VerifyGet(expression, times);
        }

        public void VerifyRemove(Action<T> removeExpression) => VerifyRemove(removeExpression, Times.Once());

        public void VerifyRemove(Action<T> removeExpression, Times times)
        {
            _mock.VerifyRemove(removeExpression, times);
        }

        public void VerifySet(Action<T> setterExpression) => VerifySet(setterExpression, Times.Once());

        public void VerifySet(Action<T> setterExpression, Times times)
        {
            _mock.VerifySet(setterExpression, times);
        }

        public override void VerifyAll()
        {           
            foreach(var action in _listeAction)
            {
                action.Invoke();
            }

            _mock.VerifyAll();            
        }

        public override void Verify()
        {
            foreach (var action in _listeAction)
            {
                action.Invoke();
            }

            _mock.Verify();
        }

        #endregion
    }
}
