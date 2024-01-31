using System;

namespace ResultOf
{
    /// <summary>
    /// Provides a way to return a success indicator 
    /// and (in case of an error) error description from a method.
    /// The <see cref="Result"/> class overloads the &amp; |, true and false operators to make it easy to use in validatios.
    /// The &amp; operator returns the first failed operand (or the last operand tested),
    /// and the | operator returns the first succeesfull operand (or the last operand tested).
    /// The &amp;&amp; operator and || operators will do the same, but in a short-circuit way.
    /// </summary>
    public class Result
    {
        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class to indicate a success.
        /// </summary>
        /// <returns>An instance of the <see cref="Result"/> class indicating success.</returns>
        public static Result Success() 
            => new Result();

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class to indicate a failure.
        /// </summary>
        /// <param name="errorDescription">Description of the error.</param>
        /// <returns>An instance of the <see cref="Result"/> class indicating failure.</returns>
        public static Result Fail(string errorDescription) 
            => new Result(errorDescription);

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class to indicate a success.
        /// </summary>
        protected Result() 
            => Succeeded = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class to indicate a failure.
        /// </summary>
        /// <param name="errorDescription">Description of the error.</param>
        protected Result(string errorDescription)
        {
            Succeeded = false;
            ErrorDescription = errorDescription;
        }

        #endregion ctor

        #region properties

        /// <summary>
        /// Gets a boolean value indicating success or failure of the method.
        /// </summary>
        public bool Succeeded { get; }

        /// <summary>
        /// Gets the description of the error.
        /// </summary>
        public string ErrorDescription { get; }

        #endregion properties

        #region operators

        /// <summary>
        /// Combines two results using the logical AND operation.
        /// Returns the first operand if it's <see cref="Succeeded"/> property is false,
        /// otherwise the second operand.
        /// This can be used to determine the first result that failed in a sequence of results.
        /// </summary>
        /// <example>
        /// The following code demonstrate how to ensure multiple results have succeeded
        /// <code>
        /// if(result1 &amp;&amp; result2 &amp;&amp; result3)
        /// { 
        ///     // All results succeeded.
        /// }
        /// </code>
        /// </example>
        /// <param name="self">An instance of the <see cref="Result"/> class.</param>
        /// <param name="other">An instance of the <see cref="Result"/> class.</param>
        /// <returns><paramref name="self"/> if not succeeded, <paramref name="other"/> otherwise.</returns>
        /// <exception cref="ArgumentNullException">if any of the operands is null.</exception>
        public static Result operator &(Result self, Result other)
        {
            if (self is null) throw new ArgumentNullException(nameof(self));
            if (other is null) throw new ArgumentNullException(nameof(other));

            return self.Succeeded ? other : self;
        }

        /// <summary>
        /// Combines two results using the logical OR operation.
        /// Returns the first operand if it's <see cref="Succeeded"/> property is false,
        /// otherwise the second operand.
        /// This can be used to determine the first result that failed in a sequence of results.
        /// </summary>
        /// <example>
        /// The following code demonstrate how to ensure at least one result have succeeded
        /// <code>
        /// if(result1 || result2 || result3)
        /// { 
        ///     // At least one result have succeeded.
        /// }
        /// </code>
        /// </example>
        /// <param name="self">An instance of the <see cref="Result"/> class.</param>
        /// <param name="other">An instance of the <see cref="Result"/> class.</param>
        /// <returns><paramref name="self"/> if succeeded, <paramref name="other"/> otherwise.</returns>
        /// <exception cref="ArgumentNullException">if any of the operands is null.</exception>
        public static Result operator |(Result self, Result other)
        {
            if (self is null) throw new ArgumentNullException(nameof(self));
            if (other is null) throw new ArgumentNullException(nameof(other));
            return self.Succeeded ? self : other;
        }

        /// <summary>
        /// Returns true when succeeded.
        /// <para>
        /// This operator is needed to allow the usage of the || operator.
        /// </para>
        /// </summary>
        /// <param name="self">The instance of the <see cref="Result"/> class to test.</param>
        /// <returns>True when succeeded, false otherwise.</returns>
        public static bool operator true(Result self) 
            => self.Succeeded;

        /// <summary>
        /// Returns false when succeeded. (the opposite of the true operator.)
        /// <para>
        /// This operator is needed to allow the usage of the &amp;&amp; operator.
        /// </para>
        /// </summary>
        /// <param name="self">The instance of the <see cref="Result"/> class to test.</param>
        /// <returns>False when succeeded, true otherwise.</returns>
        public static bool operator false(Result self) 
            => !self.Succeeded;

        #endregion operators
    }
}
