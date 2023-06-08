using Npgsql;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Material_costs
{
    public partial class Viewing : System.Web.UI.Page
    {
        readonly private DataConntection connect = new DataConntection();
        private DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateDataTable();
        }

        //Передача данных в таблицу для просмотра
        private void CreateDataTable()
        {
            //Разметка полей DataTable
            dt = new DataTable();
            DataColumn dc1 = new DataColumn("ID");
            DataColumn dc2 = new DataColumn("Дата");
            DataColumn dc3 = new DataColumn("Количество изделий");
            DataColumn dc4 = new DataColumn("Стандарт");
            DataColumn dc5 = new DataColumn("Затраты");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);

            //Передача данных из базы данных в DataTable
            connect.OpenConnection();
            NpgsqlCommand comm = new NpgsqlCommand("select * from public.\"" + _Default.User + "Cost\" order by \"ID\"", connect.getConnection());
            NpgsqlDataReader reader;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    DataRow drNew = dt.NewRow();
                    drNew["ID"] = reader.GetInt32(0).ToString(); ;
                    drNew["Дата"] = reader.GetDate(1);
                    drNew["Количество изделий"] = reader.GetInt32(2).ToString();
                    drNew["Стандарт"] = reader.GetBoolean(3).ToString();
                    drNew["Затраты"] = "Подробнее";
                    dt.Rows.Add(drNew);
                }
                catch { }
            }
            connect.CloseConnection();
            GridView.DataSource = dt;
            GridView.DataBind();
        }

        //Выбор записи для отображения подробной информации о ней
        protected void MoreInfoLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            int chosenNote = Convert.ToInt32(btn.Attributes["RowIndex"]) + 1;
            OutputMoreInfo(chosenNote);
        }

        //Вывод подробной информации о расходе материала выбранной записи
        public void OutputMoreInfo(int index)
        {
            NpgsqlCommand comm = new NpgsqlCommand("select * from public.\"" + _Default.User + "Cost\" order by \"ID\" = " + index + "", connect.getConnection());
            connect.OpenConnection();
            NpgsqlDataReader reader;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    AluminiumTextBox.Text = reader.GetString(4).ToString();
                    CopperWireTextBox.Text = reader.GetString(5).ToString();
                    OilTextBox.Text = reader.GetString(6).ToString();
                }
                catch { }
            }
        }
    }
}