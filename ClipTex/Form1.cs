using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipTex {
    public partial class Form1 : Form {
        DataSave ds = new DataSave();
        string text = "";
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Program.SaveTxtFile(ds.txtFilePath, Clipboard.GetText());
        }

        private void Form1_Load(object sender, EventArgs e) {
            textBox1.Text = ds.txtFilePath;
            if (Program.canWrite) {
                button1.Enabled = true;
            } else {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            SaveFileDialog file = new SaveFileDialog();
            file.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            file.Filter = "Text Files|*.txt";
            if (file.ShowDialog() == DialogResult.OK) {
                ds.txtFilePath = file.FileName;
                Program.SaveTxtFile(ds.txtFilePath, text);
                Program.WriteXML(ds);
                textBox1.Text = ds.txtFilePath;
            }

            if (Program.canWrite) {
                button1.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            Program.SaveTxtFile(ds.txtFilePath, text);
            Program.WriteXML(ds);
        }

        private void button3_Click(object sender, EventArgs e) {
            Process.Start(ds.txtFilePath);
        }

    }
}
