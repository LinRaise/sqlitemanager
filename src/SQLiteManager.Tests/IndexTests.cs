using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SQLiteManager.Core;

namespace SQLiteManager.Tests
{
    /// <summary>
    /// Class for testing index functionality.
    /// </summary>
    [TestFixture]
    public class IndexTests
    {
        /// <summary>
        /// Determines if the validator considers an index with an empty name to be invalid.
        /// </summary>
        [Test]
        public void IndexWithEmptyNameIsInvalid()
        {
            Table tbl = new Table("Table");
            Index i = new Index("  ", tbl);

            IndexValidator idxValidator = new IndexValidator();

            ICollection<IValidationResult> results;
            Assert.IsFalse(idxValidator.Validate(i, out results));
            Assert.IsTrue(results.Cast<IndexValidationResult>().Any(r => r.ValidationType == IndexValidationTypes.Name));
        }

        /// <summary>
        /// Determines if the validator considers an index with a null name to be invalid.
        /// </summary>
        [Test]
        public void IndexWithNullNameIsInvalid()
        {
            Table tbl = new Table("Table");
            Index i = new Index(null, tbl);

            IndexValidator idxValidator = new IndexValidator();

            ICollection<IValidationResult> results;
            Assert.IsFalse(idxValidator.Validate(i, out results));
            Assert.IsTrue(results.Cast<IndexValidationResult>().Any(r => r.ValidationType == IndexValidationTypes.Name));
        }

        /// <summary>
        /// Determines if the validator considers an index with no table to be invalid.
        /// </summary>
        [Test]
        public void IndexWithNoTableSpecifiedIsInvalid()
        {
            Index i = new Index("IDX", null);

            IndexValidator idxValidator = new IndexValidator();

            ICollection<IValidationResult> results;
            Assert.IsFalse(idxValidator.Validate(i, out results));
            Assert.IsTrue(results.Cast<IndexValidationResult>().Any(r => r.ValidationType == IndexValidationTypes.HasTableSpecified));
        }

        /// <summary>
        /// Determines if the validator considers an index with no column to be invalid.
        /// </summary>
        [Test]
        public void IndexWithNoColumnSpecifiedIsInvalid()
        {
            Index i = new Index("IDX", null);

            IndexValidator idxValidator = new IndexValidator();

            ICollection<IValidationResult> results;
            Assert.IsFalse(idxValidator.Validate(i, out results));
            Assert.IsTrue(results.Cast<IndexValidationResult>().Any(r => r.ValidationType == IndexValidationTypes.HasColumn));
        }

        /// <summary>
        /// Determines if the validator considers an index with valid data to be valid.
        /// </summary>
        [Test]
        public void IndexWithValidDataIsValid()
        {
            Table tbl = new Table("Table");
            Index i = new Index("IDX", tbl);
            i.AddColumn("Col");

            IndexValidator idxValidator = new IndexValidator();

            ICollection<IValidationResult> results;
            Assert.IsTrue(idxValidator.Validate(i, out results));
        }
    }
}
