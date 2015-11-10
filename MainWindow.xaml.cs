using System;
using Ejercicio01.MiBd;
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
using System.Text.RegularExpressions;

namespace Ejercicio01
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //guarda nuevo registro
            //Instanciar base de datos
            if ((Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z]+$"))&&(Regex.IsMatch(txtSueldo.Text, @"^\d+$")))
            {
            
                demoEF db = new demoEF();
                Empleado emp = new Empleado();
                emp.Nombre = txtNombre.Text;
                emp.Sueldo = int.Parse(txtSueldo.Text);
                
                db.Empleados.Add(emp);
                db.SaveChanges();

            }
                else
                 { MessageBox.Show("solo caracteres en nombre y/o numeros en sueldo"); }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if ((Regex.IsMatch(txtId.Text, @"^\d+$"))&&(Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z]+$"))&&(Regex.IsMatch(txtSueldo.Text, @"^\d+$")))
            {

                //actualiza
                demoEF db = new demoEF();

                int id = int.Parse(txtId.Text);
                var em = db.Empleados.SingleOrDefault(x => x.id == id);
                //  var em = from x in db.Empleados
                //         where x.id == id
                //       select x;
                if (em != null)
                {
                    em.Nombre = txtNombre.Text;
                    em.Sueldo = int.Parse(txtSueldo.Text);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("solo Numeros #id y/o caracteres en Nombre y/o numeros en sueldo"); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtId.Text, @"^\d+$"))//se esta verificando que se agregue 
            {
                //elimina registro
                demoEF db = new demoEF();

                int id = int.Parse(txtId.Text);
                var em = db.Empleados.SingleOrDefault(x => x.id == id);
                //  var em = from x in db.Empleados
                //         where x.id == id
                //       select x;
                if (em != null)
                {
                    db.Empleados.Remove(em);
                    db.SaveChanges();
                }

            }
            else { MessageBox.Show("solo Numeros #id"); }

        }

        private void txtId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //consulta por id
            if (Regex.IsMatch(txtId.Text, @"^\d+$"))
            {
                demoEF db = new demoEF();

                int id = int.Parse(txtId.Text);

                var reg = from s in db.Empleados
                          where s.id == id
                          select new
                          {
                              s.Nombre,
                              s.Sueldo
                          };
                dbGrid.ItemsSource = reg.ToList();
            }
            else { MessageBox.Show("solo Numeros #id"); }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //despliega todos los datos de la base de datos
            demoEF db = new demoEF();


            var reg = from s in db.Empleados

                      select s;
            dbGrid.ItemsSource = reg.ToList();
        }
    }
}
