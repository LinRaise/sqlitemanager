using System;
using System.IO;
using System.Linq;

using NUnit.Framework;
using SQLiteManager.Core;

namespace SQLiteManager.Tests
{
    [TestFixture]
    class DatabaseTests
    {
        const string DatabaseName = "test.sqlite";
        bool eventRaised;
        string databasePath = "test.sqlite";

        [TestFixtureSetUp]
        public void Init()
        {
           File.Copy(string.Format("..\\..\\{0}", DatabaseName), Path.Combine(Directory.GetCurrentDirectory(), DatabaseName), true);
           databasePath = Path.Combine(Directory.GetCurrentDirectory(), DatabaseName);
        }

        [Test]
        public void OpenDatabase()
        {
            //arrange
            DatabaseManager.Instance.DatabaseOpened += InstanceDatabaseOpened;
            //act
            DatabaseManager.Instance.AddDatabase(databasePath);
            //asserts
            Assert.IsTrue(DatabaseManager.Instance.Databases.Any());
            Assert.AreEqual(DatabaseManager.Instance.Databases[0].Name, Path.GetFileNameWithoutExtension(databasePath));
            Assert.IsTrue(DatabaseManager.Instance.Databases[0].Tables.Any());
            Assert.IsTrue(DatabaseManager.Instance.Databases[0].Indexes.Any());
            Assert.IsTrue(eventRaised);
        }

        [Test]
        public void FindTable()
        {
            //arrange
            string tableName = "accounts";
            DatabaseManager.Instance.AddDatabase(databasePath);
            //act
            var table = DatabaseManager.Instance.FindTable(DatabaseManager.Instance.Databases.First().Id, tableName);
            //asserts
            Assert.IsNotNull(table);
            Assert.AreEqual(table.Name, tableName);
        }

        [Test]
        public void DropTable()
        {
            //arrange
            string tableName = "bills";
            DatabaseManager.Instance.AddDatabase(databasePath);
            var tablesCount = DatabaseManager.Instance.Databases[0].Tables.Count();
            //act
            DatabaseManager.Instance.DropTable(DatabaseManager.Instance.Databases[0].Id, tableName);
            //asserts
            Assert.AreEqual(tablesCount - 1, DatabaseManager.Instance.Databases[0].Tables.Count());
            Assert.IsFalse(DatabaseManager.Instance.Databases[0].Tables.Where(n => n.Name.Equals(tableName)).Any());
        }

        [Test]
        public void AlterTable()
        {
            //arrange
            string oldTableName = "config";
            string newTableName = "config_new";
            DatabaseManager.Instance.AddDatabase(databasePath);
            var tablesCount = DatabaseManager.Instance.Databases[0].Tables.Count();
            var table = DatabaseManager.Instance.FindTable(DatabaseManager.Instance.Databases[0].Id, oldTableName);
            var newTable = table.Clone() as Table;
            Assert.IsNotNull(newTable);
            newTable.Name = newTableName;
            //act
            DatabaseManager.Instance.AlterTable(table, newTable);
            //asserts
            Assert.IsFalse(DatabaseManager.Instance.Databases[0].Tables.Where(n => n.Name.Equals(oldTableName)).Any());
            Assert.IsTrue(DatabaseManager.Instance.Databases[0].Tables.Where(n => n.Name.Equals(newTableName)).Any());
            Assert.AreEqual(newTable.ToString(), DatabaseManager.Instance.Databases[0].Tables.Where(n => n.Name.Equals(newTableName)).First().ToString());
            Assert.AreEqual(tablesCount, DatabaseManager.Instance.Databases[0].Tables.Count());
        }

        [Test]
        public void CreateTable()
        {
            //arrange
            string tableName = "newTable";
            DatabaseManager.Instance.AddDatabase(databasePath);
            var tablesCount = DatabaseManager.Instance.Databases[0].Tables.Count();
            var table = new Table(tableName);
            table.AddColumn(new Column("id", ""));
            //act
            DatabaseManager.Instance.CreateTable(DatabaseManager.Instance.Databases[0].Id, table);
            //asserts
            Assert.AreEqual(tablesCount + 1, DatabaseManager.Instance.Databases[0].Tables.Count());
            Assert.IsTrue(DatabaseManager.Instance.Databases[0].Tables.Where(n => n.Name.Equals(tableName)).Any());
        }

        [Test]
        public void CreateIndex()
        {
            //arrange
            var indexName = Guid.NewGuid().ToString();
            DatabaseManager.Instance.AddDatabase(databasePath);
            var indexesCount = DatabaseManager.Instance.Databases[0].Indexes.Count();
            var index = new Index(indexName, DatabaseManager.Instance.Databases[0].Tables.First());
            index.AddColumn(DatabaseManager.Instance.Databases[0].Tables.First().Columns[0]);
            //act
            DatabaseManager.Instance.CreateIndex(DatabaseManager.Instance.Databases[0].Id, index);
            //asserts
            Assert.AreEqual(indexesCount + 1, DatabaseManager.Instance.Databases[0].Indexes.Count());
            Assert.IsTrue(DatabaseManager.Instance.Databases[0].Indexes.Where(n => n.Name.Equals(indexName)).Any());
        }

        [Test]
        public void DropIndex()
        {
            //arrange
            string indexName = "testindex";
            DatabaseManager.Instance.AddDatabase(databasePath);
            var indexesCount = DatabaseManager.Instance.Databases[0].Indexes.Count();
            //act
            DatabaseManager.Instance.DropIndex(DatabaseManager.Instance.Databases[0].Id, indexName);
            //asserts
            Assert.AreEqual(indexesCount - 1, DatabaseManager.Instance.Databases[0].Indexes.Count());
            Assert.IsFalse(DatabaseManager.Instance.Databases[0].Indexes.Where(n => n.Name.Equals(indexName)).Any());
        }

        [TestFixtureTearDown]
        public void Clear()
        {
            File.Delete(databasePath);
        }

        void InstanceDatabaseOpened(object sender, DatabaseEventArgs e)
        {
            eventRaised = true;
            Assert.IsNotNull(e.Database);
        }
    }
}
