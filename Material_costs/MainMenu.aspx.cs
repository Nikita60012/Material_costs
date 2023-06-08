using Aspose.Cells;
using Npgsql;
using System;
using System.Data;
using System.IO;

namespace Material_costs
{
    public partial class MainMenu : System.Web.UI.Page
    {
        readonly private DataConntection connect = new DataConntection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Закрытие приложения
        protected void ExitLinkButton_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "closePage", "window.close()", true);
        }

        //Скачивание записей о материальных затратах в отдельный .xlsx файл
        protected void DownloadDataButton_Click(object sender, EventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CostTables";
            CreateExcelFile(desktopPath);
        }
        
        //Создание файла и перенос в него данных
        public void CreateExcelFile(string desktopPath)
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
            NpgsqlCommand comm = new NpgsqlCommand("select * from public.\"" + _Default.User + "Cost\"", connect.getConnection());
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
            workbookForDataTable.Save(desktopPath + "\\" + _Default.User + "Cost.xlsx");
        }
    }
}