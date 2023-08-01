using Login_Pape.Entities;
using Login_Pape.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Lógica de interacción para RegistroAspirante.xaml
    /// </summary>
    public partial class RegistroAspirante : Window
    {
        public RegistroAspirante()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordBox.Password) && passwordBox.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordBox.Focus();
        }

        private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
                textEmail.Visibility = Visibility.Collapsed;
            else
                textEmail.Visibility = Visibility.Visible;
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void txtCurp_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCurp.Text) && txtCurp.Text.Length > 0)
                textCurp.Visibility = Visibility.Collapsed;
            else
                textCurp.Visibility = Visibility.Visible;
        }

        private void textCurp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtCurp.Focus();
        }

        private void lblCancelar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow menu = new MainWindow();
            this.Close();
            menu.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlobalServices global = new GlobalServices();
            List<Usuario> list = global.GetUsuarios();
            MainWindow login = new MainWindow();

            string curp = txtCurp.Text;
            string correo = txtEmail.Text;
            string pass = passwordBox.Password;

            if (!list.Any(usuario => usuario.CURP.Equals(curp, StringComparison.OrdinalIgnoreCase) &&
                                 usuario.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase)))
            {
                Usuario user = new Usuario();
                user.CURP = curp;
                user.Correo = correo;
                user.Password = pass;
                user.FkRoles = 1;
                global.AddUser(user);
                MessageBox.Show("Usuario agregado");
                Close();
                login.Show();
            }
            else
            {
                MessageBox.Show("Estos datos ya existen en nuestra base de datos");
            }
        }
    }
}
