using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TotalCom
{
    static class FileManager
    {
        // ну такое
        public static string[] ShowDirectoryAndFiles(string path)
        {
            string[] answer = new string[2];

            try
            {
                var subDirectory = Directory.GetDirectories(path);
                var fileArray = Directory.GetFiles(path);

                string[] allContent = new string[subDirectory.Length + fileArray.Length]; 

                subDirectory.CopyTo(allContent, 0);
                fileArray.CopyTo(allContent, subDirectory.Length);
                
                return allContent;
            }
            catch(Exception ex)
            {
                // вообще пиздец
                answer[0] = ex.Message;
                answer[1] = "-1";
                return answer;
            }
        }
        public static int CreateFile(string currentPath, string FileName)
        {
            string sum = currentPath + "\\" + FileName;

            try 
            {
                File.Create(sum);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return 0;
        }
        public static int CreateFolder(string currentPath, string FileName)
        {
            string sum = currentPath + "\\" + FileName;

            try
            {
                Directory.CreateDirectory(sum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }

            return 0;
        }
        public static int DeleteFile(string currentPath, string FileName)
        {
            string sum = currentPath + "\\" + FileName;

            try
            {
                File.Delete(sum);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }

            return 0;
        }
        public static int DeleteFolder(string currentPath, string FileName)
        {
            string sum = currentPath + "\\" + FileName;

            try
            {
                Directory.Delete(sum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }

            return 0;
        }

    }
}
