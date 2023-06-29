using Aspose.Cells;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Material_costs
{
    public partial class AllUserTables : System.Web.UI.Page
    {
        readonly private DataConntection connect = new DataConntection();
        private DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateDataTable();
        }
        private void CreateDataTable()
        {
            //Разметка полей DataTable
            dt = new DataTable();
            DataColumn dc1 = new DataColumn("ID");
            DataColumn dc2 = new DataColumn("Логин");
            DataColumn dc3 = new DataColumn("Выбор");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);

            //Передача данных из базы данных в DataTable
            connect.OpenConnection();
            NpgsqlCommand comm = new NpgsqlCommand("select * from public.\"Accounts\" order by \"ID\"", connect.getConnection());
            NpgsqlDataReader reader;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    DataRow drNew = dt.NewRow();
                    drNew["ID"] = reader.GetInt32(0).ToString();
                    drNew["Логин"] = reader.GetString(1);
                    dt.Rows.Add(drNew);
                }
                catch { }
            }
            connect.CloseConnection();
            UsersTables.DataSource = dt;
            UsersTables.DataBind();
        }

        protected void Download_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            int chosenNote = Convert.ToInt32(btn.Attributes["RowIndex"]);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CostTables";
            string user = UsersTables.Rows[chosenNote].Cells[1].Text.ToString();
            CreateExcelFile(desktopPath, user);
        }

        protected void DownloadAllButton_Click(object sender, EventArgs e)
        {
            int length = UsersTables.Rows.Count;
            for(int i = 0; i < length; i++)
            {
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CostTables";
                    string user = UsersTables.Rows[i].Cells[1].Text.ToString();
                    CreateExcelFile(desktopPath, user);
                
            }
        }
        public void CreateExcelFile(string desktopPath, string user)
        {
            //Перенос данных в DataTable
            Aspose.Cells.Workbook workbookForDataTable = new Aspose.Cells.Workbook();
            System.Data.DataTable userTable = new System.Data.DataTable(_Default.User + "Cost");

            userTable.Columns.Add("ID", typeof(int));
            userTable.Columns.Add("Date", typeof(DateTime));
            userTable.Columns.Add("Quantity", typeof(int));
            userTable.Columns.Add("IsStandart", typeof(bool));
            userTable.Columns.Add("AluminiumBlank", typeof(int));
            userTable.Columns.Add("CopperWire", typeof(double));
            userTable.Columns.Add("Oil", typeof(double));

            DataRow userRecord;

            Directory.CreateDirectory(desktopPath);
            connect.OpenConnection();
            NpgsqlCommand comm = new NpgsqlCommand("select * from public.\"" + user + "Cost\"", connect.getConnection());
            NpgsqlDataReader reader;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    userRecord = userTable.NewRow();
                    userRecord["ID"] = reader.GetInt32(0);
                    userRecord["Date"] = reader.GetDateTime(1);
                    userRecord["Quantity"] = reader.GetInt32(2);
                    userRecord["IsStandart"] = reader.GetBoolean(3);
                    userRecord["AluminiumBlank"] = int.Parse(reader.GetString(4));
                    userRecord["CopperWire"] = double.Parse(reader.GetString(5));
                    userRecord["Oil"] = double.Parse(reader.GetString(6));

                    userTable.Rows.Add(userRecord);
                }
                catch { }

            }
            connect.CloseConnection();

            //Создание файла и сохранение данных
            ImportTableOptions importOptions = new ImportTableOptions();
            Aspose.Cells.Worksheet dataTableWorksheet = workbookForDataTable.Worksheets[0];
            dataTableWorksheet.Cells.ImportData(userTable, 0, 0, importOptions);
            dataTableWorksheet.AutoFitColumns();
            workbookForDataTable.Save(desktopPath + "\\" + user + "Cost.xlsx");
        }
    }
}