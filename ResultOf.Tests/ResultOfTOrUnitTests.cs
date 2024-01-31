﻿using NUnit.Framework;

namespace ResultOf.Tests
{
    class ResultOfTOrUnitTests
    {

        private Result<int> _fail1, _fail2, _fail3,
            _success1, _success2, _success3;

        [SetUp]
        public void Setup()
        {
            _fail1 = Result<int>.Fail("Fail 1");
            _fail2 = Result<int>.Fail("Fail 2");
            _fail3 = Result<int>.Fail("Fail 3");

            _success1 = Result<int>.Success(1);
            _success2 = Result<int>.Success(2);
            _success3 = Result<int>.Success(3);
        }

        #region Or operator

        [Test]
        public void OrOperator_failAndSuccess()
        {
            var result = _fail1 | _success1;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrOperator_successAndFail()
        {
            var result = _success1 | _fail1;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrOperator_successAndSuccess()
        {
            var result = _success1 | _success2;

            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrOperator_failAndFail()
        {
            var result = _fail1 | _fail2;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(ReferenceEquals(result, _fail2));
            Assert.That(!result.Succeeded);
        }

        [Test]
        public void OrOperator_successAndFailAndFail()
        {
            var result = _success1 | _fail1 | _fail2;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(!ReferenceEquals(result, _fail2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrOperator_failAndSuccessAndFail()
        {
            var result = _fail1 | _success1 | _fail2;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(!ReferenceEquals(result, _fail2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrOperator_failAndFailAndSuccess()
        {
            var result = _fail1 | _fail2 | _success1;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(!ReferenceEquals(result, _fail2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrOperator_successAndSuccessAndFail()
        {
            var result = _success1 | _success2 | _fail1;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrOperator_successAndFailAndSuccess()
        {
            var result = _success1 | _fail1 | _success2;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrOperator_failAndSuccessAndSuccess()
        {
            var result = _fail1 | _success1 | _success2;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrOperator_successAndSuccessAndSuccess()
        {
            var result = _success1 | _success2 | _success3;

            Assert.That(!ReferenceEquals(result, _success3));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        #endregion Or operator

        #region OrElse operator

        [Test]
        public void OrElseOperator_failAndSuccess()
        {
            var result = _fail1 || _success1;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrElseOperator_successAndFail()
        {
            var result = _success1 || _fail1;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrElseOperator_successAndSuccess()
        {
            var result = _success1 || _success2;

            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrElseOperator_failAndFail()
        {
            var result = _fail1 || _fail2;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(ReferenceEquals(result, _fail2));
            Assert.That(!result.Succeeded);
        }

        [Test]
        public void OrElseOperator_successAndFailAndFail()
        {
            var result = _success1 || _fail1 || _fail2;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(!ReferenceEquals(result, _fail2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrElseOperator_failAndSuccessAndFail()
        {
            var result = _fail1 || _success1 || _fail2;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(!ReferenceEquals(result, _fail2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrElseOperator_failAndFailAndSuccess()
        {
            var result = _fail1 || _fail2 || _success1;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(!ReferenceEquals(result, _fail2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrElseOperator_successAndSuccessAndFail()
        {
            var result = _success1 || _success2 || _fail1;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrElseOperator_successAndFailAndSuccess()
        {
            var result = _success1 || _fail1 || _success2;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrElseOperator_failAndSuccessAndSuccess()
        {
            var result = _fail1 || _success1 || _success2;

            Assert.That(!ReferenceEquals(result, _fail1));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void OrElseOperator_successAndSuccessAndSuccess()
        {
            var result = _success1 || _success2 || _success3;

            Assert.That(!ReferenceEquals(result, _success3));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _success1));
            Assert.That(result.Succeeded);
        }

        #endregion OrElse operator
    }
}
