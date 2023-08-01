using Login_Pape.Auth;
using Login_Pape.Entities;
using Login_Pape.Services;
using Login_Pape.Vistas;
using MySqlX.XDevAPI.Relational;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Login_Pape
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtEmail.Text;
            string password = passwordBox.Password;

            Usuario usuario = ObtenerUsuario(username, password);
            Auth.Authentication.IdUsuario = usuario.PkUser;


            if (usuario != null)
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Por favor, ingresa un nombre de usuario y contraseña válidos.");
                    return;
                }
                string rol = usuario.Roles.Nombre;
                switch (rol)
                {
                    case "Aspirante":
                        HomaAspirante aspirante = new HomaAspirante();
                        Close();
                        aspirante.Show();
                        break;
                    case "Estudiante":
                        HomeEstudiante estudiante = new HomeEstudiante();
                        Close();
                        estudiante.Show();
                        break;
                    case "Profesor":
                        HomeProfesor profesor = new HomeProfesor();
                        Close();
                        profesor.Show();
                        break;
                    case "Coordinador":
                        HomeCoordinador coordinador = new HomeCoordinador();
                        Close();
                        coordinador.Show();
                        break;
                    case "Encargado":
                        HomeEncargado encargado = new HomeEncargado();
                        Close();
                        encargado.Show();
                        break;
                    default:
                        break;
                }

            }
            else
            {
                MessageBox.Show("Credenciales invalidas. Por favor intentelo nuevamente", "Inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        GlobalServices usuarioservices = new GlobalServices();
        
        private Usuario ObtenerUsuario(string username, string password)
        {

            List<Usuario> usuarios = usuarioservices.GetUsuarios();
            List<Roles> roles = usuarioservices.GetRoles();

            Usuario usuario = usuarios.FirstOrDefault(u => u.CURP == username && u.Password == password);

            if (usuario != null)
            {
                Roles rolUsuario = roles.FirstOrDefault(r => r.PkRol == usuario.FkRoles);
                usuario.Roles = rolUsuario;
            }

            return usuario;
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistroAspirante registro = new RegistroAspirante();
            this.Close();
            registro.Show();
        }
    }
}