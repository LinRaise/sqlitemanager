//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Brandon Hawker" email="bhawker@gmail.com"/>
//	</file>

using System;
using System.Collections.Generic;

namespace SQLiteManager.Core
{
    /// <summary>
    /// Validator for an instance of type <c>T</c>, which must implement <see cref="IValidatable"/>.
    /// </summary>
    public interface IValidator<T> where T : IValidatable
    {
        /// <summary>
        /// Validates the target instance.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="results">The results of the validation.</param>
        /// <returns>
        ///   <c>True</c> if the instance is valid; else <c>false</c>.
        /// </returns>
        bool Validate(T target, out ICollection<IValidationResult> results);
    }

    /// <summary>
    /// Result of a particular validation.
    /// </summary>
    public interface IValidationResult
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        string Message
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Exception thrown when the target is not specified for an <see cref="IValidator"/>.
    /// </summary>
    public class ValidationTargetNotSpecifiedException : Exception
    {
    }
}
