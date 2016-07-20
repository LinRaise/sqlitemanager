//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System.Data;

namespace SQLiteManager.Core
{
	public class Result
	{
		private readonly ResultStatus status = ResultStatus.Unknown;
		private readonly DataTable dataTable;
		private readonly string message = string.Empty;
		
		public ResultStatus Status {
			get { return status; }
		}
		public DataTable DataTable {
			get { return dataTable; }
		}
		public string Message {
			get { return message; }
		}
		
		public Result(DataTable dataTable)
		{
			status = dataTable != null ? ResultStatus.QuerySucceded : ResultStatus.Failed;
			this.dataTable = dataTable;
		}
		public Result(string errorMessage)
		{
			status = ResultStatus.Failed;
			message = errorMessage;
		}
		public Result(ResultStatus resultStatus, string message)
		{
			status = resultStatus;
			this.message = message;
		}
	}
	
	public enum ResultStatus
	{
		Unknown = 0,
		QuerySucceded = 1,
		DMLSucceded = 2,
		Failed = 3
	}
}
