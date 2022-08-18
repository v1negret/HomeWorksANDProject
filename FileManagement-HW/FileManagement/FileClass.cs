using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement
{
    public static class FileClass { 
        public static void CreateFile(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);

                var file1 = file.Create();
                file1.Dispose();
                
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string GetNameByPath(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                string fileName = file.Name;
                return fileName;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;

        }

        public static void WriteToFile(string filePath, string text)
        {
            try
            {
                FileInfo file1 = new FileInfo(filePath);

                using (StreamWriter sw = file1.CreateText())
                {
                    sw.WriteLine(text);

                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
