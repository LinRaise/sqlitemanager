//	<file>
//		<license>lgpl-3.0.txt</license>
//	</file>

using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Forms;

using SQLiteManager.Core;

namespace SQLiteManager.Gui
{
	public class ResultsTabControl : TabControl
	{
        ReadOnlyCollection<Result> results;
		
		public ReadOnlyCollection<Result> Results {
			get {
			    return new ReadOnlyCollection<Result>(results);
			}
        	
			set {
				results = value;
				var logStringBuilder = new StringBuilder();
				TabPages.Clear();
				foreach	(var result in results) {
					logStringBuilder.AppendLine();
					
					if (result.Status == ResultStatus.QuerySucceded) {
						TabPages.Add(new ResultTabPage(result, string.Format("Result Set {0}", results.IndexOf(result) + 1)));
						logStringBuilder.AppendLine(string.Format("{0} rows found", result.DataTable.Rows.Count));
					} else if (result.Status == ResultStatus.DMLSucceded) {
						logStringBuilder.AppendLine(result.Message);
					} else if (result.Status == ResultStatus.Failed) {
						logStringBuilder.AppendLine(result.Message);
					}
				}
				TabPages.Add(new MessageTabPage(logStringBuilder.ToString()));
			}
		}
		
		public ResultsTabControl()
		{
		}

        public ResultsTabControl(ReadOnlyCollection<Result> results)
		{
			Results = results;
		}
	}
}
