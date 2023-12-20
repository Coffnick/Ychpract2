using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ychpract2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Naklad: Window
    {
        Db database = new Db();
        public Naklad()
        {
            InitializeComponent();
            Loaddata();
        }
        private void Exit(object sender, EventArgs e)
        {
            Choice ch = new Choice();
            this.Close();
            ch.ShowDialog();
            
        }
        private void Poisk_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Poisk.Text == "")
            {
                Poisk.Text = "Дата накладной";
            }
        }
        private void Poisk_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Poisk.Text == "Дата накладной")
            {
                Poisk.Text = "";
            }
        }
        private void Loaddata()
        {
            string query = "SELECT * FROM prixod";
            SqlDataAdapter adapter = new SqlDataAdapter(query, database.getConnection());

            DataSet ds = new DataSet();
            adapter.Fill(ds, "prixod");

            AdminDataGrid.ItemsSource = ds.Tables["prixod"].DefaultView;
             query = "SELECT * FROM rasxod";
             adapter = new SqlDataAdapter(query, database.getConnection());

            ds = new DataSet();
            adapter.Fill(ds, "rasxod");

            AdminDataGridRasxod.ItemsSource = ds.Tables["rasxod"].DefaultView;
        }

        private void save()
        {
            database.openCon();
            DataTable dt = ((DataView)AdminDataGrid.ItemsSource).ToTable();

            foreach (DataRow row in dt.Rows)
            {
                int id_Clients = Convert.ToInt32(row["id_Clients"]);
                string Name = row["Name"].ToString();
                int phone = Convert.ToInt32(row["phone"]);
                string Lname = row["Lname"].ToString();


                string query = "UPDATE Clients SET Name = @Name ,phone = @phone,Lname=@Lname WHERE id_Clients = @id_Clients";
                SqlCommand command = new SqlCommand(query, database.getConnection());

                command.Parameters.AddWithValue("@id_Clients", id_Clients);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@Lname", Lname);

                command.ExecuteNonQuery();
            }
        }
        private void SaveData_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                save();
            }
            catch (Exception)
            {
                MessageBox.Show("Введены неверные значения!");
            }
        }
    }
}
