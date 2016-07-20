//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Brandon Hawker" email="bhawker@gmail.com"/>
//	</file>

namespace SQLiteManager.Core
{
    /// <summary>
    /// Result of table validation.
    /// </summary>
    public class TableValidationResult : IValidationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableValidationResult"/> class.
        /// </summary>
        /// <param name="validationType">The validation type.</param>
        /// <param name="message">The message.</param>
        public TableValidationResult(TableValidationTypes validationType, string message)
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
        /// <value>
        /// The type of the validation.
        /// </value>
        public TableValidationTypes ValidationType
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// Validation checks performed on a table.
    /// </summary>
    public enum TableValidationTypes
    {
        NotSpecified,
        Name,
        HasColumns
    }
}
