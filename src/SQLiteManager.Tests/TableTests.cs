/*
 * Created by SharpDevelop.
 * User: ie185004
 * Date: 2/1/2011
 * Time: 9:49 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using NUnit.Framework;
using SQLiteManager.Core;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace SQLiteManager.Tests
{
	[TestFixture]
	public class TableTests
	{
		[Test]
		public void TestMethod()
		{
			var t = new Table("test3");
			t.AddColumn(new Column("id", "integer"));
//			t.AddColumn(new Column("name", "varchar(45)"));
			Console.WriteLine(t.ToString());
		}

        [Test]
        public void FindTables()
        {
            //arrange
        }

        /// <summary>
        /// Determines if the validator considers a table with an empty name to be invalid.
        /// </summary>
        [Test]
        public void TableWithEmptyNameIsInvalid()
        {
            Table t = new Table("  ");

            TableValidator tblValidator = new TableValidator();

            ICollection<IValidationResult> results;
            Assert.IsFalse(tblValidator.Validate(t, out results));
            Assert.IsTrue(results.Cast<TableValidationResult>().Any(r => r.ValidationType == TableValidationTypes.Name));
        }

        /// <summary>
        /// Determines if the validator considers a table with a null name to be invalid.
        /// </summary>
        [Test]
        public void TableWithNullNameIsInvalid()
        {
            Table t = new Table(null);

            TableValidator tblValidator = new TableValidator();
            
            ICollection<IValidationResult> results;
            Assert.IsFalse(tblValidator.Validate(t, out results));
            Assert.IsTrue(results.Cast<TableValidationResult>().Any(r => r.ValidationType == TableValidationTypes.Name));
        }

        /// <summary>
        /// Determines if the validator considers a table with no columns to be invalid.
        /// </summary>
        [Test]
        public void TableWithNoColumnsIsInvalid()
        {
            Table t = new Table("TableName");
            t.Columns = new List<Column>(); 

            TableValidator tblValidator = new TableValidator();

            ICollection<IValidationResult> results;
            Assert.IsFalse(tblValidator.Validate(t, out results));
            Assert.IsTrue(results.Cast<TableValidationResult>().Any(r => r.ValidationType == TableValidationTypes.HasColumns));
        }

        /// <summary>
        /// Determines if the validator considers a table with valid data to be valid.
        /// </summary>
        [Test]
        public void TableWithValidDataIsValid()
        {
            Table t = new Table("TableName");
            t.Columns.Add(new Column("Col1", "INTEGER"));
            t.Columns.Add(new Column("Col2", "TEXT"));
            
            TableValidator tblValidator = new TableValidator();
            
            ICollection<IValidationResult> results;
            Assert.IsTrue(tblValidator.Validate(t, out results));
        }
	}
}
