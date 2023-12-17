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
    public partial class Choice : Window
    {
        public Choice()
        {
            InitializeComponent();
        }
        private void Sup_click(object sender, RoutedEventArgs e)
        {
            Sup sup = new Sup();
            this.Close();
            sup.ShowDialog();
            
        }
        private void Client_click(object sender, RoutedEventArgs e)
        {
            Custom cus = new Custom();
            this.Close();
            cus.ShowDialog();
           
        }
        private void Goods_click(object sender, RoutedEventArgs e)
        {
            Goods goods = new Goods();
            this.Close();
            goods.ShowDialog();
           
        }
        private void Naklad_click(object sender, RoutedEventArgs e)
        {
            Naklad nak = new Naklad();
            this.Close();
            nak.ShowDialog();
            
        }
        private void Exit(object sender, EventArgs e)
        {
            MainWindow mn = new MainWindow();
            this.Close();
            mn.ShowDialog();
            
        }
    }
}
