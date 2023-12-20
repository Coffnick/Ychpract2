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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Goods : Window
    {
        Db database = new Db();
        public Goods()
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
        private void Loaddata()
        {
            string query = "SELECT * FROM Goods";
            SqlDataAdapter adapter = new SqlDataAdapter(query, database.getConnection());

            DataSet ds = new DataSet();
            adapter.Fill(ds,"Goods");

            AdminDataGrid.ItemsSource = ds.Tables["Goods"].DefaultView;
        }
        
        private void save()
        {
            database.openCon();
            DataTable dt = ((DataView)AdminDataGrid.ItemsSource).ToTable();
    
            foreach (DataRow row in dt.Rows)
            {
                int id_Goods = Convert.ToInt32(row["id_Goods"]);
                string manufacturer = row["manufacturer"].ToString();
                int articul = Convert.ToInt32(row["articul"]);
                string description = row["description"].ToString();
                string supplier = row["supplier"].ToString();
                int quantity =Convert.ToInt32(row["quantity"]);
                int price = Convert.ToInt32(row["price"]);

                string query = "UPDATE Goods SET manufacturer = @manufacturer ,articul = @articul,description=@description,supplier=@supplier, quantity=@quantity, price = @price  WHERE id_Goods = @id_Goods";
                SqlCommand command = new SqlCommand(query, database.getConnection());

                command.Parameters.AddWithValue("@id_Goods", id_Goods);
                command.Parameters.AddWithValue("@manufacturer", manufacturer);
                command.Parameters.AddWithValue("@articul", articul);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@supplier", supplier);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@price", price);

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
