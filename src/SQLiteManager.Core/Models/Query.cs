//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace SQLiteManager.Core
{
	[Obsolete()]
	public class Query
	{
		public const char StatementSplitter = ';';
		private readonly string[] ResultSetSQLKeywords = { "select", "pragma" };

		private readonly Database database;
		private string queriesText;

		public Query(Database database)
		{
			this.database = database;
		}

		public Query(Database database, string queriesText)
			: this(database)
		{
			this.queriesText = queriesText;
		}

		public ReadOnlyCollection<Result> ExecuteQuery()
		{
			//queriesText = queriesText.Replace(Environment.NewLine, " ");
			var statements = queriesText.Split(new[] { StatementSplitter.ToString() }, StringSplitOptions.RemoveEmptyEntries).ToList();

			for (int i = 0; i < statements.Count; i++) {
				statements[i] = statements[i].Trim();
			}

			var results = new List<Result>();

			foreach (string statement in statements) {
				Result result;

				var dataTable = new DataTable();
				try {
                    using (var transaction = TransactionHelper.NewTransaction())
                    {
                        using (var connection = ConnectionFactory.GetConnection(database))
                        using (var command = new SQLiteCommand(statement, connection))
                        {
                            var selectStatement = ResultSetSQLKeywords.Any(keyWord => statement.Contains(keyWord));

                            if (selectStatement)
                            {
                                using (var dataAdapter = new SQLiteDataAdapter(command))
                                {
                                    dataAdapter.Fill(dataTable);
                                    result = new Result(dataTable);
                                }
                            }
                            else
                            {
                                var rowsAffected = command.ExecuteNonQuery();
                                result = new Result(ResultStatus.DMLSucceded, string.Format("{0} rows affected", rowsAffected));
                            }
                        }
                        transaction.Complete();
                    }
				} catch (SQLiteException sqe) {
					result = new Result(sqe.Message);
				}
				results.Add(result);
			}
			return results.AsReadOnly();
		}
	}
}
