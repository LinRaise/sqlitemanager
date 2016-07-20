//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.IO;

namespace SQLiteManager.Core.Models
{
	public class Query2
	{
		public string FileName { get; set; }
		public string Content { get; set; }
		
		public string AbsoluteFileName {
			get { return Path.GetFileName(FileName); }
		}
		
		public Query2()
		{
		}
		
		public Query2(string file, string content)
		{
			this.FileName = file;
			this.Content = content;
		}
		
		public static Query2 Load(string file)
		{
			return new Query2(file, new StreamReader(file).ReadToEnd());
		}
	}
}
