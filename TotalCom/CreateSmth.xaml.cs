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

namespace TotalCom
{
    /// <summary>
    /// Interaction logic for CreateSmth.xaml
    /// </summary>
    public partial class CreateSmth : Window
    {
        string fish = "Enter a name to file or directory";
        string currentPath = "";

        public CreateSmth(string path)
        {
            InitializeComponent();   
            txtGetFileName.Text = fish;
            this.currentPath = path;
            this.Title = "File Manager";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // create btn
            string name = "";
 
            if ((txtGetFileName.Text == fish) || (txtGetFileName.Text == ""))
            {
                MessageBox.Show("Text not entered");
            }
            else
            {
                name = txtGetFileName.Text;      
            }

            if (RadioFile.IsChecked == true) 
            {
                FileManager.CreateFile(currentPath, name);
                this.DialogResult = true;
            }

            if (RadioFolder.IsChecked == true)
            {
                FileManager.CreateFolder(currentPath, name);
                this.DialogResult = true;
            }
        }

        private void txtGetFileName_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // delete btn
            // code repeated :(
            string name = "";

            if ((txtGetFileName.Text == fish) || (txtGetFileName.Text == ""))
            {
                MessageBox.Show("Text not entered");
            }
            else
            {
                name = txtGetFileName.Text;
            }

            if (RadioFile.IsChecked == true)
            {
                FileManager.DeleteFile(currentPath, name);
                this.DialogResult = true;
            }

            if (RadioFolder.IsChecked == true)
            {
                FileManager.DeleteFolder(currentPath, name);
                this.DialogResult = true;
            }
        }
    }
}
