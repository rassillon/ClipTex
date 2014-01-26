using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ClipTex {

    static class Program {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>

        static string DataSavePath = System.Windows.Forms.Application.StartupPath + @"\ClipTex.data";
        public static bool canWrite = false;

        [STAThread]
        static void Main() {
            DataSave ds = new DataSave();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void WriteXML(DataSave ds) {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(DataSave));

            System.IO.StreamWriter file = new System.IO.StreamWriter(DataSavePath);
            writer.Serialize(file, ds);
            file.Close();
        }

        public static string ReadXML() {
            string extract ="Please select a file.";
            try {
                XDocument data = XDocument.Load(DataSavePath);
                extract = (String)data.Descendants().ToArray()[0];
            } catch (FileNotFoundException e) {}
            return extract;
        }

        public static void SaveTxtFile(String path, String text) {
            if (text != null) {
                try {
                    File.WriteAllText(path, File.ReadAllText(path) + text + "\n");
                } catch (FileNotFoundException e) {
                    File.Create(path);
                } catch (IOException e) {
                    Console.Write("IOEcpetpion asdfasdf");
                }
            }
        }
    }

    public class DataSave {
        public string txtFilePath;

        public DataSave() {
            var temp = Program.ReadXML();
            if (temp == null) {
                txtFilePath = "File not created. Select one.";
                Program.canWrite = false;
            } else {
                txtFilePath = temp;
                Program.canWrite = true;
            }
        }
    }
}
