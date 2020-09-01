using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeySim_API
{
    public partial class ButtonSettingForm : Form
    {
        private static DataTable ReadExcelFile(string sheetName, string path)
        {
            using (OleDbConnection conn = new OleDbConnection())
            {
                DataTable dt = new DataTable();
                string Import_FileName = path;
                string fileExtension = Path.GetExtension(Import_FileName);
                if (fileExtension == ".xls")
                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                if (fileExtension == ".xlsx")
                    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = "Select * from [" + sheetName + "$]";
                    comm.Connection = conn;
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(dt);
                        return dt;
                    }
                }
            }

        }

        private static readonly DataTable dt1 = ReadExcelFile("Sheet1", "C:/Users/ataberk.oklu/Keys.xlsx");
        private static char UniqueIDEnum = (char)0;

        private readonly IList<KeyClass> KeyList = dt1.AsEnumerable().Select(row =>
            new KeyClass
            {
                UniqueID = UniqueIDEnum++,
                Name = row.Field<string>("Name"),
                ReportID = row.Field<string>("ReportID"),
                Byte1 = row.Field<char>("Byte1"),
                Byte2 = row.Field<char>("Byte2")
            }).ToList();

        public ButtonSettingForm()
        {
            InitializeComponent();
        }

    }
}
