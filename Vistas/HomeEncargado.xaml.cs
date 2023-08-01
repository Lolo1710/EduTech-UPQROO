using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Login_Pape.Vistas
{
    /// <summary>
    /// Lógica de interacción para HomeEncargado.xaml
    /// </summary>
    public partial class HomeEncargado : Window
    {
        public HomeEncargado()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            Close();
            login.Show();
        }
    }
}
