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
using System.Windows.Shapes;

namespace Ychpract2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Naklad: Window
    {
        public Naklad()
        {
            InitializeComponent();
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
    }
}
