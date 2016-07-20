//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Brandon Hawker" email="bhawker@gmail.com"/>
//	</file>

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SQLiteManager.Core
{
    /// <summary>
    /// Validates a <see cref="Column"/> before altering the database.
    /// </summary>
    public class ColumnValidator : IValidator<Column>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnValidator"/> class.
        /// </summary>
        public ColumnValidator()
        {
        }

        /// <summary>
        /// Validates the target column.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="results">The results.</param>
        /// <returns>
        ///   <c>True</c> if the target column is valid; else <c>false</c>.
        /// </returns>
        public bool Validate(Column target, out ICollection<IValidationResult> results)
        {
            results = new Collection<IValidationResult>();

            if (target == null) 
            {
                throw new ValidationTargetNotSpecifiedException();
            }

            target.IsValid = true;
            target.ValidationResults = new Collection<IValidationResult>();

            if (target.Name == null || target.Name.Trim().Length == 0)
            {
                var result = new ColumnValidationResult(ColumnValidationTypes.Name, "The column name must be specified.");
                results.Add(result);
                target.ValidationResults.Add(result);
            }

            if (target.Type == null || target.Type.Trim().Length == 0)
            {
                var result = new ColumnValidationResult(ColumnValidationTypes.Type, "The column type must be specified.");
                results.Add(result);
                target.ValidationResults.Add(result);
            }

            return target.IsValid = results.Count == 0;
        }
    }    
}
