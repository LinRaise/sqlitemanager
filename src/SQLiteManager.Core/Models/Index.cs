//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Brandon Hawker" email="bhawker@gmail.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SQLiteManager.Core
{
    public class Index : IValidatable
    {
        private readonly IList<Column> columns = new List<Column>();

        public string Name { get; set; }

        public IEnumerable<Column> Columns {
            get { return columns; }
        }

        public Table Table { get; private set; }
        public string Script { get; set; }
        public bool Unique { get; set; }
        public bool IsValid { get; set; }
        public ICollection<IValidationResult> ValidationResults { get; set; }

        public void AddColumn(Column column)
        {
        	if (column == null) {
                throw new ArgumentNullException("column");
        	}
           columns.Add(column);
        }
        
        public void AddColumn(string columnName)
        {
            columns.Add(new Column(columnName, string.Empty));
        }

        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append("CREATE ");
            if (Unique) {
                sb.Append(" UNIQUE ");
            }
            sb.Append(" INDEX ");
            sb.Append(" '" + Name + "' ");
            sb.Append(" ON ");
            sb.Append(Table.Name);
            sb.Append(" ");
            sb.Append("(");
            sb.Append(Column.GetColumnsNames(Columns));
            sb.Append(")");
            return sb.ToString();
        }

        public Index(string name, Table table)
        {
            Name = name;
            Table = table;
            IsValid = true;
            ValidationResults = new Collection<IValidationResult>();
        }

        public Index() : this(string.Empty, new Table())
        {
        }
    }
}
