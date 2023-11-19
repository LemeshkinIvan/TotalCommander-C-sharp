using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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

namespace TotalCom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string currentPath = @"C:\";
        
        public MainWindow()
        {
            // разработал Иван Лемешкин из 3-09Пс-3
            InitializeComponent();

            this.Title = "File Manager(x64) C#";

            lblCrtMssg.Content = "";

            const string defaultPath = @"C:\";
            var diskList = DriveInfo.GetDrives();

            for (int i = 0; i < diskList.Length; i++)
            {
                comboDisk.Items.Add(diskList[i]); 
            }
          
            txtFileDirectory.Text = defaultPath;

            var default_data = FileManager.ShowDirectoryAndFiles(defaultPath);
            showInViewer(default_data);
        }

        public void showInViewer(string[] data)
        {
            firstViewer.Items.Clear();
            labelLocated.Content = "You here: " + currentPath;

            if (data.Length != 0)
            {
                foreach (var t in data)
                {
                    firstViewer.Items.Add(t);
                }
            }
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
      
            if (firstViewer.SelectedItem is string t)
            {
                var data = FileManager.ShowDirectoryAndFiles(t);
                currentPath = t;
                showInViewer(data);
            }
        }

        private void btnFindDir_Click(object sender, RoutedEventArgs e)
        {
            currentPath = txtFileDirectory.Text;
            showInViewer(FileManager.ShowDirectoryAndFiles(txtFileDirectory.Text));
        }

        private void btnToPreviouslyFolder_Click(object sender, RoutedEventArgs e)
        {    
            if (currentPath.Length != 0)
            {
                char[] reversePath = currentPath.ToCharArray();
                Array.Reverse(reversePath);

                //string b = new string(reversePath);
                //MessageBox.Show(b);

                // должны удалить из строки последню папку
                string PrePath = "";
                bool flag = false;

                for (int i = 0; i < currentPath.Length; i++){
                    if ((reversePath[i] == '\\') && (flag == false))
                    {
                        flag = true;
                    }

                    if (flag == true)
                    {
                        PrePath += reversePath[i];
                    }
                }

                // reverse string again
                reversePath = PrePath.ToCharArray();
                Array.Reverse(reversePath);
                currentPath = new string(reversePath);
 
                if (currentPath.Length > 1)
                {
                    currentPath = currentPath.Remove(currentPath.Length - 1);
                    showInViewer(FileManager.ShowDirectoryAndFiles(currentPath));
                }   
            }
        }

        private void comboDisk_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = comboDisk.SelectedValue;
            var data = FileManager.ShowDirectoryAndFiles(t.ToString());
            currentPath = t.ToString();
            txtFileDirectory.Text = currentPath;
            showInViewer(data);  
        }

        private void btnCrtSmth_Click(object sender, RoutedEventArgs e)
        {
            CreateSmth d = new CreateSmth(currentPath);
            d.ShowDialog();
        }

        private void btnUpdatePath_Click(object sender, RoutedEventArgs e)
        {
            showInViewer(FileManager.ShowDirectoryAndFiles(currentPath));
        }
    }
}