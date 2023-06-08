using Npgsql;
using System;
using System.Globalization;
using System.Threading;

namespace Material_costs
{
    public partial class Adding : System.Web.UI.Page
    {
        readonly private DataConntection connect = new DataConntection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Добавление записи о затратах материала в базу данных
        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                string standartCost;
                int quantity = Int32.Parse(ProductsTextBox.Text);
                if (IsStandart.Checked == true)
                {
                    standartCost = "'" + DateTextBox.Text + "', '" + quantity + "', 'true', '" + (10 * quantity) + "', '" + (7.5 * quantity) + "', '" + (1.5 * quantity) + "'";
                }
                else
                {
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    double al = double.Parse(AluminiumTextBox.Text);
                    double cu = double.Parse(CopperWireTextBox.Text);
                    double oil = double.Parse(OilTextBox.Text);
                    Thread.CurrentThread.CurrentCulture = temp_culture;
                    standartCost = "'" + DateTextBox.Text + "', '" + quantity + "', 'false', '" + al * quantity + "', '" + cu * quantity + "', '" + oil * quantity + "'";
                }
                NpgsqlCommand comm = new NpgsqlCommand("INSERT into public.\"" + _Default.User + "Cost\" (\"Date\", \"Quantity\", \"IsStandart\", \"AluminiumBlank\", \"CopperWire\", \"Oil\") VALUES (" + standartCost + ")", connect.getConnection());
                connect.OpenConnection();
                comm.ExecuteNonQuery();
                connect.CloseConnection();

                IncorrectData.Visible = true;
                IncorrectData.Text = "Запись добавлена";
                
            }
            catch
            {
                IncorrectData.Text = "Введены некорректные данные";
                IncorrectData.Visible = true;
            }
            DateTextBox.Text = "";
            IsStandart.Checked = true;
            AluminiumTextBox.Text = "";
            CopperWireTextBox.Text = "";
            OilTextBox.Text = "";
        }

        //Разблокирование полей для ввода затрат вручную
        protected void IsStandart_CheckedChanged(object sender, EventArgs e)
        {
            if(IsStandart.Checked == true)
            {
                AluminiumTextBox.Enabled = false;
                CopperWireTextBox.Enabled = false;
                OilTextBox.Enabled = false;
            }
            else
            {
                AluminiumTextBox.Enabled = true;
                CopperWireTextBox.Enabled = true;
                OilTextBox.Enabled = true;
            }
        }
    }
}