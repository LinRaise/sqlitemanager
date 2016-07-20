//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Brandon Hawker" email="bhawker@gmail.com"/>
//	</file>

namespace SQLiteManager.Core
{
    /// <summary>
    /// Result of index validation.
    /// </summary>
    public class IndexValidationResult : IValidationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexValidationResult"/> class.
        /// </summary>
        /// <param name="validationType">The validation type.</param>
        /// <param name="message">The message.</param>
        public IndexValidationResult(IndexValidationTypes validationType, string message)
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
        public IndexValidationTypes ValidationType
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// Validation checks performed on an index.
    /// </summary>
    public enum IndexValidationTypes
    {
        NotSpecified,
        Name,
        HasColumn,
        HasTableSpecified
    }
}
