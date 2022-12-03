namespace FormalSpecification
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.existToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpenFile = new System.Windows.Forms.ToolStripButton();
            this.btnSaveFile = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConvertToCSharp = new System.Windows.Forms.ToolStripButton();
            this.btnConvertToCplusplus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRun = new System.Windows.Forms.ToolStripButton();
            this.inputTb = new System.Windows.Forms.RichTextBox();
            this.outputTb = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TbFileName = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator3,
            this.btnOpenFile,
            this.btnSaveFile,
            this.btnExit,
            this.toolStripSeparator2,
            this.btnConvertToCSharp,
            this.btnConvertToCplusplus,
            this.toolStripSeparator1,
            this.btnRun});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1118, 48);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.existToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(60, 45);
            this.toolStripDropDownButton1.Text = "Menu";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(132, 30);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // existToolStripMenuItem
            // 
            this.existToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("existToolStripMenuItem.Image")));
            this.existToolStripMenuItem.Name = "existToolStripMenuItem";
            this.existToolStripMenuItem.Size = new System.Drawing.Size(132, 30);
            this.existToolStripMenuItem.Text = "Exist";
            this.existToolStripMenuItem.Click += new System.EventHandler(this.existToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 48);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile.Image")));
            this.btnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(29, 45);
            this.btnOpenFile.Text = "Open Input";
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveFile.Image")));
            this.btnSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(29, 45);
            this.btnSaveFile.Text = "Save Output";
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnExit
            // 
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(29, 45);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
            // 
            // btnConvertToCSharp
            // 
            this.btnConvertToCSharp.AutoSize = false;
            this.btnConvertToCSharp.BackColor = System.Drawing.Color.LightBlue;
            this.btnConvertToCSharp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnConvertToCSharp.Image = ((System.Drawing.Image)(resources.GetObject("btnConvertToCSharp.Image")));
            this.btnConvertToCSharp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConvertToCSharp.Margin = new System.Windows.Forms.Padding(4, 2, 4, 3);
            this.btnConvertToCSharp.Name = "btnConvertToCSharp";
            this.btnConvertToCSharp.Size = new System.Drawing.Size(38, 32);
            this.btnConvertToCSharp.Text = "C#";
            this.btnConvertToCSharp.Click += new System.EventHandler(this.btnConvertToCSharp_Click);
            // 
            // btnConvertToCplusplus
            // 
            this.btnConvertToCplusplus.AutoSize = false;
            this.btnConvertToCplusplus.BackColor = System.Drawing.Color.LightBlue;
            this.btnConvertToCplusplus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnConvertToCplusplus.Image = ((System.Drawing.Image)(resources.GetObject("btnConvertToCplusplus.Image")));
            this.btnConvertToCplusplus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConvertToCplusplus.Margin = new System.Windows.Forms.Padding(4, 2, 4, 3);
            this.btnConvertToCplusplus.Name = "btnConvertToCplusplus";
            this.btnConvertToCplusplus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnConvertToCplusplus.Size = new System.Drawing.Size(51, 32);
            this.btnConvertToCplusplus.Text = "C++";
            this.btnConvertToCplusplus.Click += new System.EventHandler(this.btnConvertToCplusplus_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // btnRun
            // 
            this.btnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(29, 45);
            this.btnRun.Text = "Run";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // inputTb
            // 
            this.inputTb.BackColor = System.Drawing.SystemColors.Window;
            this.inputTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputTb.Font = new System.Drawing.Font("Calibri", 11F);
            this.inputTb.ForeColor = System.Drawing.SystemColors.WindowText;
            this.inputTb.Location = new System.Drawing.Point(0, 0);
            this.inputTb.Name = "inputTb";
            this.inputTb.Size = new System.Drawing.Size(457, 583);
            this.inputTb.TabIndex = 3;
            this.inputTb.Text = "";
            // 
            // outputTb
            // 
            this.outputTb.BackColor = System.Drawing.SystemColors.Window;
            this.outputTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputTb.Font = new System.Drawing.Font("Calibri", 11F);
            this.outputTb.ForeColor = System.Drawing.SystemColors.WindowText;
            this.outputTb.Location = new System.Drawing.Point(0, 0);
            this.outputTb.Name = "outputTb";
            this.outputTb.Size = new System.Drawing.Size(633, 586);
            this.outputTb.TabIndex = 2;
            this.outputTb.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 81);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 190, 3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.inputTb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.outputTb);
            this.splitContainer1.Size = new System.Drawing.Size(1096, 579);
            this.splitContainer1.SplitterDistance = 452;
            this.splitContainer1.SplitterIncrement = 2;
            this.splitContainer1.SplitterWidth = 11;
            this.splitContainer1.TabIndex = 6;
            // 
            // TbFileName
            // 
            this.TbFileName.Location = new System.Drawing.Point(13, 52);
            this.TbFileName.Name = "TbFileName";
            this.TbFileName.Size = new System.Drawing.Size(100, 24);
            this.TbFileName.TabIndex = 7;
            this.TbFileName.Text = "file_name.txt";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1008, 24);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 48);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(899, 24);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(98, 48);
            this.btnCopy.TabIndex = 9;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.Title = "Choose Input";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1118, 672);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.TbFileName);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 8F);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Generate";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSaveFile;
        private System.Windows.Forms.ToolStripButton btnOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnConvertToCSharp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnConvertToCplusplus;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.RichTextBox inputTb;
        private System.Windows.Forms.RichTextBox outputTb;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton btnRun;
        private System.Windows.Forms.TextBox TbFileName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem existToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

