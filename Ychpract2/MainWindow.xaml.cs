using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoginButton(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Password.Password;
            if (password.Trim()==""||login.Trim()=="")
            {
                MessageBox.Show("Аккаунт не существует или у вас нет доступа", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Вы успешно вошли в систему", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                Choice ch = new Choice();
                 this.Close();
                 ch.ShowDialog();
            }
            
            
        }
    }
}
