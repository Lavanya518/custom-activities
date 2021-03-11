using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.IO;
using System;

namespace Ayehu.Sdk.ActivityCreation
{
	public class CustomActivity : IActivity
	{
		public string table1;
		public string table2;

		public ICustomActivityResult Execute()
		{
			System.IO.StringReader sr1 = new System.IO.StringReader(table1);
			DataSet ds1 = new DataSet();
			ds1.ReadXml(sr1);
			DataTable dt1 = new DataTable();
			dt1 = ds1.Tables[0];

			System.IO.StringReader sr2 = new System.IO.StringReader(table2);
			DataSet ds2 = new DataSet();
			ds2.ReadXml(sr2);
			DataTable dt2 = new DataTable();
			dt2 = ds2.Tables[0];

			var tableUnique1 = dt1.AsEnumerable().Except(dt2.AsEnumerable(), DataRowComparer.Default);
			DataTable tableResult1 = tableUnique1.CopyToDataTable<DataRow>();

			var tableUnique2 = dt2.AsEnumerable().Except(tableResult1.AsEnumerable(), DataRowComparer.Default);
			DataTable tableResult2 = tableUnique2.CopyToDataTable<DataRow>();

			DataTable tableResult3 = tableResult1;
			tableResult3.Merge(tableResult2);

			return this.GenerateActivityResult(tableResult3);
		}
	}
}