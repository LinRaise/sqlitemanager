//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Brandon Hawker" email="bhawker@gmail.com"/>
//	</file>

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SQLiteManager.Core
{
    /// <summary>
    /// Validates an <see cref="Index"/> before altering the database.
    /// </summary>
    public class IndexValidator : IValidator<Index>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexValidator"/> class.
        /// </summary>
        public IndexValidator()
        {
        }

        /// <summary>
        /// Validates the target index.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="results">The results.</param>
        /// <returns>
        ///   <c>True</c> if the target index is valid; else <c>false</c>.
        /// </returns>
        public bool Validate(Index target, out ICollection<IValidationResult> results)
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
                var result = new IndexValidationResult(IndexValidationTypes.Name, "The index name must be specified.");
                results.Add(result);
                target.ValidationResults.Add(result);
            }

            if (target.Table == null)
            {
                var result = new IndexValidationResult(IndexValidationTypes.HasTableSpecified, "The table must be specified.");
                results.Add(result);
                target.ValidationResults.Add(result);
            }
            else
            {
                // Assumes validation on table has already occurred.
            }

            if (target.Columns.Count() == 0)
            {
                var result = new IndexValidationResult(IndexValidationTypes.HasColumn, "At least one column must be selected.");
                results.Add(result);
                target.ValidationResults.Add(result);
            }

            return target.IsValid = results.Count == 0;
        }
    }    
}
