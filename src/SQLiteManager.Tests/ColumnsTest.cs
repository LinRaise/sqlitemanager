using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SQLiteManager.Core;

namespace SQLiteManager.Tests
{
	[TestFixture]
	class ColumnsTest
	{
		[Test]
		public void GetColumnsNameInOneString()
		{
			//arrange
			var columns = new List<Column> {
				new Column("1", string.Empty),
				new Column("2", string.Empty),
				new Column("3", string.Empty),
				new Column("4", string.Empty),
				new Column("5", string.Empty),
				new Column("6", string.Empty)
			};
			string rightString = "1, 2, 3, 4, 5, 6";
			//act
			var result = Column.GetColumnsNames(columns);
			//asserts
			Assert.AreEqual(result, rightString);
		}

		[Test]
		public void GetEmptyStringIfColumnsIsNullOrEmpty() {
			//arrange
			var columns = new List<Column>();
			//act
			var result = Column.GetColumnsNames(columns);
			var result1 = Column.GetColumnsNames(null);
			//asserts
			Assert.AreEqual(result, string.Empty);
			Assert.AreEqual(result1, string.Empty);
		}

        /// <summary>
        /// Determines if the validator considers a column with an empty name to be invalid.
        /// </summary>
        [Test]
        public void ColumnWithEmptyNameIsInvalid()
        {
            Column c = new Column("  ", "TEXT");

            ColumnValidator colValidator = new ColumnValidator();

            ICollection<IValidationResult> results;
            Assert.IsFalse(colValidator.Validate(c, out results));
            Assert.IsTrue(results.Cast<ColumnValidationResult>().Any(r => r.ValidationType == ColumnValidationTypes.Name));
        }

        /// <summary>
        /// Determines if the validator considers a column with a null name to be invalid.
        /// </summary>
        [Test]
        public void ColumnWithNullNameIsInvalid()
        {
            Column c = new Column(null, "TEXT");

            ColumnValidator colValidator = new ColumnValidator();

            ICollection<IValidationResult> results;
            Assert.IsFalse(colValidator.Validate(c, out results));
            Assert.IsTrue(results.Cast<ColumnValidationResult>().Any(r => r.ValidationType == ColumnValidationTypes.Name));
        }

        /// <summary>
        /// Determines if the validator considers a table with an empty type to be invalid.
        /// </summary>
        [Test]
        public void ColumnWithEmptyTypeIsInvalid()
        {
            Column c = new Column("Desc", "  ");

            ColumnValidator colValidator = new ColumnValidator();

            ICollection<IValidationResult> results;
            Assert.IsFalse(colValidator.Validate(c, out results));
            Assert.IsTrue(results.Cast<ColumnValidationResult>().Any(r => r.ValidationType == ColumnValidationTypes.Type));
        }

        /// <summary>
        /// Determines if the validator considers a table with a null type to be invalid.
        /// </summary>
        [Test]
        public void ColumnWithNullTypeIsInvalid()
        {
            Column c = new Column("Desc", null);

            ColumnValidator colValidator = new ColumnValidator();

            ICollection<IValidationResult> results;
            Assert.IsFalse(colValidator.Validate(c, out results));
            Assert.IsTrue(results.Cast<ColumnValidationResult>().Any(r => r.ValidationType == ColumnValidationTypes.Type));
        }

        /// <summary>
        /// Determines if the validator considers a column with valid data to be valid.
        /// </summary>
        [Test]
        public void ColumnWithValidDataIsValid()
        {
            Column c = new Column("Desc", "TEXT");

            ColumnValidator colValidator = new ColumnValidator();

            ICollection<IValidationResult> results;
            Assert.IsTrue(colValidator.Validate(c, out results));
        }
	}
}
