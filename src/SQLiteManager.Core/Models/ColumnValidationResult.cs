//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Brandon Hawker" email="bhawker@gmail.com"/>
//	</file>

namespace SQLiteManager.Core
{
    /// <summary>
    /// Result of column validation.
    /// </summary>
    public class ColumnValidationResult : IValidationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnValidationResult"/> class.
        /// </summary>
        /// <param name="validationType">The validation type.</param>
        /// <param name="message">The message.</param>
        public ColumnValidationResult(ColumnValidationTypes validationType, string message)
        {
            this.ValidationType = validationType;
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the type of validation performed.
        /// </summary>
        public ColumnValidationTypes ValidationType
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// Validation checks performed on a column.
    /// </summary>
    public enum ColumnValidationTypes
    {
        NotSpecified,
        Name,
        Type
    }
}
