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
   
    public partial class Sup : Window
    {
        Db database = new Db();
        public Sup()
        {
            InitializeComponent();
            Loaddata();
        }
        private void Exit (object sender, EventArgs e)
        {
            Choice ch = new Choice();
            this.Close();
            ch.ShowDialog();
           
        }
        private void Loaddata()
        {
            string query = "SELECT * FROM Supplier";
            SqlDataAdapter adapter = new SqlDataAdapter(query, database.getConnection());

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Supplier");

            AdminDataGrid.ItemsSource = ds.Tables["Supplier"].DefaultView;
        }

        private void save()
        {
            database.openCon();
            DataTable dt = ((DataView)AdminDataGrid.ItemsSource).ToTable();

            foreach (DataRow row in dt.Rows)
            {
                int id_Supplier = Convert.ToInt32(row["id_Supplier"]);
                string Name = row["Name"].ToString();
                int Phone = Convert.ToInt32(row["Phone"]);
                string Adress = row["Adress"].ToString();
                

                string query = "UPDATE Supplier SET Name = @Name ,Phone = @Phone,Adress=@Adress WHERE id_Supplier = @id_Supplier";
                SqlCommand command = new SqlCommand(query, database.getConnection());

                command.Parameters.AddWithValue("@id_Supplier", id_Supplier);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@Adress", Adress);
               
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
