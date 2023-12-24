using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
                int id = Convert.ToInt32(row["id"]);
                int storekeeper = Convert.ToInt32(row["storekeeper"]);
                string Client = row["Client"].ToString();
                string Date = row["Date"].ToString();
                int price = Convert.ToInt32(row["price"]);
                string goods = row["goods"].ToString();


                string query = "UPDATE prixod SET storekeeper = @storekeeper ,Client = @Client,Date=@Date,goods=@goods,price=@price WHERE id = @id";
                SqlCommand command = new SqlCommand(query, database.getConnection());

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@storekeeper", storekeeper);
                command.Parameters.AddWithValue("@Client", Client);
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@goods", goods);

                command.ExecuteNonQuery();
            }
        }
        private void saveRasxod()
        {
            database.openCon();
            DataTable dt = ((DataView)AdminDataGridRasxod.ItemsSource).ToTable();

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                int Storekeeper = Convert.ToInt32(row["Storekeeper"]);
                string Client = row["Client"].ToString();
                string date = row["date"].ToString();
                int price = Convert.ToInt32(row["price"]);
                string goods = row["goods"].ToString();


                string query = "UPDATE rasxod SET Storekeeper = @Storekeeper ,Client = @Client,date=@date,goods=@goods,price=@price WHERE id = @id";
                SqlCommand command = new SqlCommand(query, database.getConnection());

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@Storekeeper", Storekeeper);
                command.Parameters.AddWithValue("@Client", Client);
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@goods", goods);

                command.ExecuteNonQuery();
            }
        }
        private void SaveData_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                save();
                saveRasxod();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Введены неверные значения!");
            }
        }

        private void insert()
        {
            database.openCon();


            SqlDataAdapter da = new SqlDataAdapter("select id from prixod", database.getConnection());
            DataSet ds = new DataSet();
            da.Fill(ds, "id");

            List<int> idListApp = new List<int>();
            foreach (DataRow row in ds.Tables["id"].Rows)
            {
                idListApp.Add((int)row["id"]);
            }

            foreach (int _id in idListApp)
            {
                outputTextBox.Text = _id.ToString();
            }

            DataTable dt = ((DataView)AdminDataGrid.ItemsSource).ToTable();


            int count = 0;
            foreach (DataRow row in dt.Rows)
            {

                int id = Convert.ToInt32(row["id"]);            
                int storekeeper = Convert.ToInt32(row["storekeeper"]);
                string Client = row["Client"].ToString();
                string Date = row["Date"].ToString();
                int price = Convert.ToInt32(row["price"]);
                string goods = row["goods"].ToString();

                    
                if (idListApp.Contains(id))
                {
                    count++;
                }
                else
                {
                    string query = "INSERT INTO prixod (id,storekeeper,Client,Date,price) VALUES (@id, @storekeeper,@Client,@Date,@price)";
                    SqlCommand command = new SqlCommand(query, database.getConnection());
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@storekeeper", storekeeper);
                    command.Parameters.AddWithValue("@Client", Client);
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@goods", goods);
                    command.ExecuteNonQuery();
                }

            }
        }
        private void insertrasxod()
        {
            database.openCon();


            SqlDataAdapter da = new SqlDataAdapter("select id from rasxod", database.getConnection());
            DataSet ds = new DataSet();
            da.Fill(ds, "id");

            List<int> idListApp = new List<int>();
            foreach (DataRow row in ds.Tables["id"].Rows)
            {
                idListApp.Add((int)row["id"]);
            }

            DataTable dt = ((DataView)AdminDataGridRasxod.ItemsSource).ToTable();


            int count = 0;
            foreach (DataRow row in dt.Rows)
            {

                int id = Convert.ToInt32(row["id"]);
                int storekeeper = Convert.ToInt32(row["storekeeper"]);
                string Client = row["Client"].ToString();
                string Date = row["Date"].ToString();
                int price = Convert.ToInt32(row["price"]);
                string goods = row["goods"].ToString();


                if (idListApp.Contains(id))
                {
                    count++;
                }
                else
                {
                    string query = "INSERT INTO rasxod (id,storekeeper,Client,Date,price) VALUES (@id, @storekeeper,@Client,@Date,@price)";
                    SqlCommand command = new SqlCommand(query, database.getConnection());
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@storekeeper", storekeeper);
                    command.Parameters.AddWithValue("@Client", Client);
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@goods", goods);
                    command.ExecuteNonQuery();
                }

            }
        }
        private void InsertData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                insert();
                insertrasxod();
            }
            catch (Exception)
            {
                MessageBox.Show("Введены неверные значения!");
            }

        }
    }
}
