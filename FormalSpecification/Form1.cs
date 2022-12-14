using Microsoft.CSharp;
using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace FormalSpecification
{
    public partial class Form1 : Form
    {
        private static HandleHighlight _handleHighlight = new HandleHighlight();

        private static HandleGenerate _handleGenerate = new HandleGenerate();
        
        private static CPlusPlusHandling cPlusPlusHandling = new CPlusPlusHandling();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exist();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void btnConvertToCSharp_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(inputTb.Text))
            {
                MessageBox.Show("Input Invalid!");
                return;
            }

            _handleGenerate.SetInput(inputTb.Text);

            outputTb.Text = _handleGenerate.Generate();

            _handleHighlight.Highlight(outputTb);
        }

        private void btnConvertToCplusplus_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(inputTb.Text))
            {
                MessageBox.Show("Input Invalid!");
                return;
            }

            cPlusPlusHandling.SetInput(inputTb.Text);

            outputTb.Text = cPlusPlusHandling.Generate();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exist();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void copyOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void OpenFile()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TbFileName.Text = openFileDialog1.SafeFileName.Substring(0, openFileDialog1.SafeFileName.LastIndexOf("."));

                using (FileStream fs = File.Open(openFileDialog1.FileName, FileMode.Open))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);

                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        // Printing the file contents
                        inputTb.Text = temp.GetString(b);
                    }

                    inputTb.Text = inputTb.Text.Trim();

                    string temp3 = "";

                    for (int i = 0; i < inputTb.Lines.Length; i++)
                    {
                        if (i == 0 || i > 2)
                            temp3 += String.Concat(inputTb.Lines[i].Where(c => !Char.IsWhiteSpace(c)));

                        if (i == 1)
                        {
                            temp3 += inputTb.Lines[i].Substring(0, 3) + " ";
                            temp3 += String.Concat(inputTb.Lines[i].Substring(3).Where(c => !Char.IsWhiteSpace(c)));
                        }

                        if (i == 2)
                        {
                            temp3 += inputTb.Lines[2].Substring(0, 4) + " ";
                            temp3 += String.Concat(inputTb.Lines[i].Substring(4).Where(c => !Char.IsWhiteSpace(c)));
                        }

                        if (i < 2)
                        {
                            temp3 += "\n";
                        }

                    }

                    //string temp4 = "";
                    //for (int i = 3; i < inputTb.Lines.Length; i++)
                    //{
                    //    temp4 += inputTb.Lines[i].ToString();
                    //}
                    //string[] temp5 = temp4.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

                    //temp3 += temp5[0] + "\n" + temp5[1];

                    inputTb.Text = temp3;

                    _handleHighlight.Highlight(inputTb);
                }
            }
        }

        private void SaveFile()
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

        private void Exist()
        {
            this.Close();
        }

        private void Clear()
        {
            inputTb.Clear();
            outputTb.Clear();
            TbFileName.Clear();
        }

        private void Copy()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string line in outputTb.Lines)
                sb.AppendLine(line);

            if (sb.Length > 0)
            {
                Clipboard.SetText(sb.ToString());
            }
        }

        [Obsolete]
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (outputTb.Text[0] == 'u')
            {
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                ICodeCompiler compiler = codeProvider.CreateCompiler();
                string output = "Out.exe";
                ToolStripButton ButtonObject = (ToolStripButton)sender;

                CompilerParameters parameters = new CompilerParameters();

                //Make sure we generate an EXE, not a DLL
                parameters.GenerateExecutable = true;
                parameters.OutputAssembly = output;
                CompilerResults results = compiler.CompileAssemblyFromSource(parameters, outputTb.Text);

                if (results.Errors.Count > 0)
                {
                    string error_string = "";
                    foreach (CompilerError CompErr in results.Errors)
                    {
                        error_string = "Line number " + CompErr.Line +
                                    ", Error Number: " + CompErr.ErrorNumber +
                                    ", '" + CompErr.ErrorText + ";" +
                                    Environment.NewLine + Environment.NewLine;
                    }
                    DialogResult error = MessageBox.Show(error_string, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    //Successful Compile
                    //If we clicked run then launch our EXE
                    if (ButtonObject.Text == "Run") Process.Start(output);
                }
            }
            else
            {
                string powershellText = outputTb.Text;
                System.Diagnostics.Process.Start("Powershell.exe", powershellText);
            }
        }
    }
}
