using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ychpract2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Db database = new Db();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoginButton(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Password.Password;

            DataTable dt = new DataTable();
            database.openCon();
            SqlDataAdapter adapter = new SqlDataAdapter();
            

            string sqlQuery = $"select id_Storekeeper,Password,Login from Storekeepers where Password ='{password}' and Login = '{login}'";

            SqlCommand command = new SqlCommand(sqlQuery, database.getConnection());

            adapter.SelectCommand = command;
     
            var role = command.ExecuteScalar();
            adapter.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                if (role != null)
                {
                    
                    MessageBox.Show("Вы успешно вошли в систему", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    Choice ch = new Choice();
                    this.Close();
                    ch.ShowDialog();
                }
                else
                    MessageBox.Show("Аккаунт не существует или у вас нет доступа", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("Аккаунт не существует или у вас нет доступа", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
 
        }
    }
}
