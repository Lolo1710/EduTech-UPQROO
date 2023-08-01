using Login_Pape.Context;
using Login_Pape.Entities;
using Login_Pape.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Org.BouncyCastle.Crypto.Tls;

namespace Login_Pape.Vistas
{
    /// <summary>
    /// Lógica de interacción para HomaAspirante.xaml
    /// </summary>
    public partial class HomaAspirante : System.Windows.Window
    {
        public HomaAspirante()
        {
            InitializeComponent();
            Labels(lblNombreCompleto, lblTelefono, lblCorreo, lblCarrera, lblEstatus);
            Actualiza();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            Close();
            login.Show();
        }

        string rutaActa;
        string rutaCertificado;
        string rutaCurp;
        byte[] curp = null;
        byte[] acta = null;
        byte[] certificado = null;

        private void btnActa_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*",
                Title = "Acta de Nacimiento"
            };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rutaActa = openFileDialog.FileName;
                byte[] acta = File.ReadAllBytes(rutaActa);
            }
         }

        private void btnCertificado_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*",
                Title = "Certificado"
            };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rutaCertificado = openFileDialog.FileName;
                byte[] certificado = File.ReadAllBytes(rutaCertificado);
            }
        }

        private void btnCurp_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*",
                Title = "CURP"
            };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rutaCurp = openFileDialog.FileName;
                byte[] curp = File.ReadAllBytes(rutaCurp);
            }
        }

        private void btnGenerarFicha_Click(object sender, RoutedEventArgs e)
        {
            SubirDocs.Visibility = Visibility.Collapsed;
            GenFicha.Visibility = Visibility.Visible;
            ValidPay.Visibility = Visibility.Collapsed;
        }

        private void btnPagoFicha_Click(object sender, RoutedEventArgs e)
        {
            SubirDocs.Visibility = Visibility.Collapsed;
            GenFicha.Visibility = Visibility.Collapsed;
            ValidPay.Visibility = Visibility.Visible;
        }

        private void btnDocumentacion_Click(object sender, RoutedEventArgs e)
        {
            SubirDocs.Visibility = Visibility.Visible;
            GenFicha.Visibility = Visibility.Collapsed;
            ValidPay.Visibility = Visibility.Collapsed;
        }

        private void btnGenFicha_Loaded(object sender, RoutedEventArgs e)
        {
            VerificarYHabilitarBoton();
        }

        private void VerificarYHabilitarBoton()
        {
            if (lblEstatus.Content.ToString() == "Aprobado")
            {
                btnGenFicha.IsEnabled = true;
            }
            else
            {
                btnGenFicha.IsEnabled = false;
            }
        }

        private void btnSubirPago_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*",
                Title = "CURP"
            };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //string rutaPDF = openFileDialog.FileName;
                // Aquí puedes guardar el contenido del archivo PDF en la base de datos
                //GuardarPDFEnBaseDeDatos(rutaPDF);
                System.Windows.MessageBox.Show("Todo chido");
            }
        }

        Usuario usuario = new Usuario();
        Aspirante aspirante = new Aspirante();

        private void btnCargarDatos_Click(object sender, RoutedEventArgs e)
        {
            AspiranteServices servicesAspirante = new AspiranteServices();
            UsuarioServices servicesUsuarios = new UsuarioServices();

            

            if (rutaCurp != null && rutaActa != null && rutaCertificado != null)
            {
                curp = Encoding.UTF8.GetBytes(rutaCurp);
                acta = Encoding.UTF8.GetBytes(rutaActa);
                certificado = Encoding.UTF8.GetBytes(rutaCertificado);
            }
            else
            {
                System.Windows.MessageBox.Show("Por favor carga tus documentos");
            }

            int id = Auth.Authentication.IdUsuario;

            using (var _context = new ApplicationDbContext())
            {
                usuario = _context.Usuarios.Find(id);
                if (string.IsNullOrEmpty(usuario.Nombre) && string.IsNullOrEmpty(usuario.ApellidoM) && string.IsNullOrEmpty(usuario.ApellidoP) && string.IsNullOrEmpty(usuario.SuperMz) && string.IsNullOrEmpty(usuario.Mz) && string.IsNullOrEmpty(usuario.Lt) && string.IsNullOrEmpty(usuario.Calle) && string.IsNullOrEmpty(usuario.Telefono))
                {
                    if(txtNombreAspirante.Text != "" && txtApellidoM.Text != "" && txtApellidoP.Text != "" && txtspmza.Text != "" && txtManzana.Text != "" && txtLote.Text != "" && txtCalle.Text != "" && txtTelefono.Text != "" && comboboxCarrera.SelectedValue != null && curp != null && acta != null && certificado != null)
                    {
                        usuario.Nombre = txtNombreAspirante.Text;
                        usuario.ApellidoM = txtApellidoM.Text;
                        usuario.ApellidoP = txtApellidoP.Text;
                        usuario.SuperMz = txtspmza.Text;
                        usuario.Mz = txtManzana.Text;
                        usuario.Lt = txtLote.Text;
                        usuario.Calle = txtCalle.Text;
                        usuario.Telefono = txtTelefono.Text;
                        aspirante.Carrera = comboboxCarrera.SelectedIndex.ToString();
                        aspirante.CurpPDF = curp;
                        aspirante.ActaPDF = acta;
                        aspirante.CertificadoPDF = certificado;
                        aspirante.FkUser = usuario.PkUser;
                        servicesUsuarios.AddUser(usuario);
                        servicesAspirante.AddAspirante(aspirante);

                        System.Windows.MessageBox.Show("Datos actualizados");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Rellena todos los campos son obligatorios");
                    }
                    
                }
                else
                {
                    System.Windows.MessageBox.Show("Tus datos ya han sido capturados anteriormente" + "\nSi necesitas editarlos ponte en contacto con la institucion");
                }
            }

            
        }

        private void Labels(System.Windows.Controls.Label lbl1, System.Windows.Controls.Label lbl2, System.Windows.Controls.Label lbl3, System.Windows.Controls.Label lbl4, System.Windows.Controls.Label lbl5)
        {
            Usuario localuser = new Usuario();
            Aspirante localasp = new Aspirante();
            int id = Auth.Authentication.IdUsuario;
            using (var _context = new ApplicationDbContext())
            {
                localuser = _context.Usuarios.Find(id);
                if (!string.IsNullOrEmpty(localuser.Nombre) && !string.IsNullOrEmpty(localuser.Telefono) && !string.IsNullOrEmpty(localuser.Correo))
                {
                    lbl1.Content = localuser.Nombre;
                    lbl2.Content = localuser.Telefono;
                    lbl3.Content = localuser.Correo;
                    lbl4.Content = localuser.CURP;
                    lbl5.Content = "Aprobado";
                }
            }
        }

        private void comboboxCarrera_Loaded(object sender, RoutedEventArgs e)
        {
            comboboxCarrera.Items.Add("Opción 1");
            comboboxCarrera.Items.Add("Opción 2");
            comboboxCarrera.Items.Add("Opción 3");
        }

        private void btnGenFicha_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "Ficha_Pago.pdf";
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            string filePath = System.IO.Path.Combine(downloadsPath, fileName);

            if (File.Exists(filePath))
            {
                System.Windows.MessageBox.Show("El archivo PDF ya existe en la carpeta Descargas.", "Archivo Existente", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                int id = Auth.Authentication.IdUsuario;
                Usuario localuser = new Usuario();

                using (var _context = new ApplicationDbContext())
                {
                    localuser = _context.Usuarios.Find(id);
                }

                iTextSharp.text.Document doc = new iTextSharp.text.Document();

                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                        doc.Open();

                        PdfPTable table = new PdfPTable(2);

                        string nombre = "EduTech";
                        string correo = "94948493";
                        string telefono = "Santander";
                        string sexo = "7384673993847456367";
                        string Nombre = $"{localuser.Nombre} {localuser.ApellidoM} {localuser.ApellidoP}";

                        table.AddCell("Universidad");
                        table.AddCell(nombre);

                        table.AddCell("Convenio");
                        table.AddCell(correo);

                        table.AddCell("Banco");
                        table.AddCell(telefono);

                        table.AddCell("Alumno");
                        table.AddCell(Nombre);

                        table.AddCell("Referencia");
                        table.AddCell(sexo);

                        doc.Add(table);

                        doc.Close();
                    }

                    System.Windows.MessageBox.Show("El archivo PDF se ha guardado en la carpeta Descargas.", "Guardar PDF", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error al generar el PDF: " + ex.Message);
                }
            }
        }

        private void actualizar_Click(object sender, RoutedEventArgs e)
        {
            Actualiza();
            VerificarYHabilitarBoton();
        }

        private void Actualiza()
        {
            int id = Auth.Authentication.IdUsuario;
            Usuario localuser = new Usuario();

            using (var _context = new ApplicationDbContext())
            {
                localuser = _context.Usuarios.Find(id);
            }

            if(!string.IsNullOrEmpty(localuser.Nombre) && !string.IsNullOrEmpty(localuser.ApellidoM))
            {
                actualizar.IsEnabled = false;
                string name = localuser.Nombre;
                string last = localuser.ApellidoM;
                char ininame = name[0];
                char inilast = last[0];
                Labels(lblNombreCompleto, lblTelefono, lblCorreo, lblCarrera, lblEstatus);
                txtNamePersonalizado.Text = $"{name} {last}";
                Iniciales.Text = $"{ininame}{inilast}";
                txtWelcome.Text = $"Hola {name}, bienvenido!";
            }
            else
            {
                actualizar.IsEnabled = true;
            }
        }
    }
}
