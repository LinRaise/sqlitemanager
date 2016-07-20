//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//      <author name="Brandon Hawker" email="bhawker@gmail.com"/>
//	</file>

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SQLiteManager.Core
{
	public class Column : IValidatable
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public Table Table { get; set; }
		public bool NotNull { get; set; }
		public bool PrimaryKey { get; set; }
		public object Default { get; set; }
        public bool IsValid { get; set; }
        public ICollection<IValidationResult> ValidationResults { get; set; }
		
		public Column()
		{
            IsValid = true;
            ValidationResults = new Collection<IValidationResult>();
		}
		
		public Column(string name, string type) : this()
		{
			Name = name;
			Type = type;
		}

		public static string GetColumnsNames(IEnumerable<Column> columns)
		{
			if (columns == null || !columns.Any()) {
				return string.Empty;
			}
			var columnsNames = new StringBuilder();
			var addComma = false;
			foreach (var column in columns) {
				if (addComma) {
					columnsNames.Append(", ");
				}
				columnsNames.Append(column.Name);
				addComma = true;
			}
			return columnsNames.ToString();
		}
	}
}
