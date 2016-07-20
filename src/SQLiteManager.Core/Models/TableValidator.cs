//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Brandon Hawker" email="bhawker@gmail.com"/>
//	</file>

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SQLiteManager.Core
{
    /// <summary>
    /// Validates a <see cref="Table"/> before altering the database.
    /// </summary>
    public class TableValidator : IValidator<Table>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableValidator"/> class.
        /// </summary>
        public TableValidator()
        {
        }

        /// <summary>
        /// Validates the target table.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="results">The results.</param>
        /// <returns>
        ///   <c>True</c> if the target table is valid; else <c>false</c>.
        /// </returns>
        public bool Validate(Table target, out ICollection<IValidationResult> results)
        {
            results = new Collection<IValidationResult>();

            if (target == null)
            {
                throw new ValidationTargetNotSpecifiedException();
            }

            if (target.Name == null || target.Name.Trim().Length == 0)
            {

                results.Add(new TableValidationResult(TableValidationTypes.Name, "The table name must be specified."));
            }

            if (target.Columns.Count == 0)
            {
                results.Add(new TableValidationResult(TableValidationTypes.HasColumns, "The table must have at least one column."));
            }
            else
            {
                // Assumes validation on individual columns in target table collection has already occurred.
            }
            
            return results.Count == 0;
        }
    }    
}
