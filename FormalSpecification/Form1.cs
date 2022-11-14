using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormalSpecification
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Choose a file",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TbFileName.Text = openFileDialog.FileName;
                using (FileStream fs = File.Open(openFileDialog.FileName, FileMode.Open))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);

                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        // Printing the file contents
                        inputTb.Text = temp.GetString(b);
                    }
                }
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            // Confirm Save
            DialogResult result;
            result = MessageBox.Show("Do you want to save file?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question); if (result == DialogResult.No)
            {
                return;
            }

            // Save
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (outputTb.Text != null)
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog()
                        {
                            InitialDirectory = @"C:\",
                            Title = "Choose a file",

                            DefaultExt = "txt",
                            Filter = "txt files (*.txt)|*.txt",
                            FilterIndex = 2,
                            RestoreDirectory = true,
                            FileName = "result",
                        };

                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            if (saveFileDialog1.CheckFileExists == false)
                            {
                                using (FileStream fs = File.Create(saveFileDialog1.FileName))
                                {
                                    // Add some text to file    
                                    Byte[] content = new UTF8Encoding(true).GetBytes(outputTb.Text);
                                    fs.Write(content, 0, content.Length);
                                }
                            }
                            else
                            {
                                outputTb.SaveFile(saveFileDialog1.FileName);
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            inputTb.Clear();
            outputTb.Clear();
            TbFileName.Clear();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string line in outputTb.Lines)
                sb.AppendLine(line);

            Clipboard.SetText(sb.ToString());
        }

        private void btnConvertToCSharp_Click(object sender, EventArgs e)
        {

        }

        private void btnConvertToCplusplus_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
