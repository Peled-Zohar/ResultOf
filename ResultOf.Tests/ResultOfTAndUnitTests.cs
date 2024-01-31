﻿using NUnit.Framework;

namespace ResultOf.Tests
{
    class ResultOfTAndUnitTests
    {
        private Result _fail1, _fail2, _fail3,
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

        #region & operator

        [Test]
        public void AndOperator_failAndSuccess()
        {
            var result = _fail1 & _success1;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);
        }

        [Test]
        public void AndOperator_successAndFail()
        {
            var result = _success1 & _fail1;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);
        }

        [Test]
        public void AndOperator_successAndSuccess()
        {
            var result = _success1 & _success2;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(ReferenceEquals(result, _success2));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void AndOperator_failAndFail()
        {
            var result = _fail1 & _fail2;
            Assert.That(!ReferenceEquals(result, _fail2));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);
        }

        [Test]
        public void AndOperator_successAndFailAndFail()
        {
            var result = _success1 & _fail1 & _fail2;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(!ReferenceEquals(result, _fail2));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);
        }

        [Test]
        public void AndOperator_failAndSuccessAndFail()
        {
            var result = _fail1 & _success1 & _fail2;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(!ReferenceEquals(result, _fail2));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);
        }

        [Test]
        public void AndOperator_failAndFailAndSuccess()
        {
            var result = _fail1 & _fail2 & _success1;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(!ReferenceEquals(result, _fail2));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);
        }

        [Test]
        public void AndOperator_successAndSuccessAndFail()
        {
            var result = _success1 & _success2 & _fail1;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);

        }

        [Test]
        public void AndOperator_successAndFailAndSuccess()
        {
            var result = _success1 & _fail1 & _success2;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);

        }

        [Test]
        public void AndOperator_failAndSuccessAndSuccess()
        {
            var result = _fail1 & _success1 & _success2;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);

        }

        [Test]
        public void AndOperator_successAndSuccessAndSuccess()
        {
            var result = _success1 & _success2 & _success3;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _success3));
            Assert.That(result.Succeeded);
        }

        #endregion & operator

        #region && operator

        [Test]
        public void AndAlsoOperator_failAndSuccess()
        {
            var result = _fail1 && _success1;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);
        }


        [Test]
        public void AndAlsoOperator_successAndFail()
        {
            var result = _success1 && _fail1;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);
        }

        [Test]
        public void AndAlsoOperator_successAndSuccess()
        {
            var result = _success1 && _success2;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(ReferenceEquals(result, _success2));
            Assert.That(result.Succeeded);
        }

        [Test]
        public void AndAlsoOperator_failAndFail()
        {
            var result = _fail1 && _fail2;
            Assert.That(!ReferenceEquals(result, _fail2));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);
        }

        [Test]
        public void AndAlsoOperator_successAndFailAndFail()
        {
            var result = _success1 && _fail1 && _fail2;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(!ReferenceEquals(result, _fail2));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);
        }

        [Test]
        public void AndAlsoOperator_failAndSuccessAndFail()
        {
            var result = _fail1 && _success1 && _fail2;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(!ReferenceEquals(result, _fail2));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);
        }

        [Test]
        public void AndAlsoOperator_failAndFailAndSuccess()
        {
            var result = _fail1 && _fail2 && _success1;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(!ReferenceEquals(result, _fail2));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);
        }

        [Test]
        public void AndAlsoOperator_successAndSuccessAndFail()
        {
            var result = _success1 && _success2 && _fail1;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);

        }

        [Test]
        public void AndAlsoOperator_successAndFailAndSuccess()
        {
            var result = _success1 && _fail1 && _success2;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);

        }

        [Test]
        public void AndAlsoOperator_failAndSuccessAndSuccess()
        {
            var result = GetResult(_fail1) && GetResult(_success1) && GetResult(_success2);

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _fail1));
            Assert.That(!result.Succeeded);

            Result GetResult(Result input)
            {
                return input;
            }
        }

        [Test]
        public void AndAlsoOperator_successAndSuccessAndSuccess()
        {
            var result = _success1 && _success2 && _success3;

            Assert.That(!ReferenceEquals(result, _success1));
            Assert.That(!ReferenceEquals(result, _success2));
            Assert.That(ReferenceEquals(result, _success3));
            Assert.That(result.Succeeded);
        }


        #endregion && operator
    }
}
