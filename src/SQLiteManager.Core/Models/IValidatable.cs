//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Brandon Hawker" email="bhawker@gmail.com"/>
//	</file>

using System.Collections.Generic;

namespace SQLiteManager.Core
{
    /// <summary>
    /// Defines a class that may be validated.
    /// </summary>
    public interface IValidatable
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        bool IsValid
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the results returned by validation of the instance.
        /// </summary>
        /// <value>
        /// The validation results.
        /// </value>
        ICollection<IValidationResult> ValidationResults
        {
            get;
            set;
        }
    }
}
