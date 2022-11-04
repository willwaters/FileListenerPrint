namespace FileListenerPrint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnSelFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTog = new System.Windows.Forms.Button();
            this.pbMarquee = new System.Windows.Forms.ProgressBar();
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.tFileChecker = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBPPFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBPPPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkBPP = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listening to:";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(125, 12);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(589, 23);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.Text = "C:\\Personal\\Code\\WorldDCS\\printoutput.txt";
            // 
            // btnSelFile
            // 
            this.btnSelFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelFile.Location = new System.Drawing.Point(720, 12);
            this.btnSelFile.Name = "btnSelFile";
            this.btnSelFile.Size = new System.Drawing.Size(37, 23);
            this.btnSelFile.TabIndex = 2;
            this.btnSelFile.Text = "...";
            this.btnSelFile.UseVisualStyleBackColor = true;
            this.btnSelFile.Click += new System.EventHandler(this.btnSelFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Print Destination:";
            // 
            // btnTog
            // 
            this.btnTog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTog.Location = new System.Drawing.Point(682, 155);
            this.btnTog.Name = "btnTog";
            this.btnTog.Size = new System.Drawing.Size(75, 23);
            this.btnTog.TabIndex = 5;
            this.btnTog.Text = "Start";
            this.btnTog.UseVisualStyleBackColor = true;
            this.btnTog.Click += new System.EventHandler(this.btnTog_Click);
            // 
            // pbMarquee
            // 
            this.pbMarquee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMarquee.Location = new System.Drawing.Point(17, 157);
            this.pbMarquee.MarqueeAnimationSpeed = 20;
            this.pbMarquee.Name = "pbMarquee";
            this.pbMarquee.Size = new System.Drawing.Size(652, 20);
            this.pbMarquee.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbMarquee.TabIndex = 6;
            this.pbMarquee.Visible = false;
            // 
            // cmbDestination
            // 
            this.cmbDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Location = new System.Drawing.Point(125, 42);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(589, 23);
            this.cmbDestination.TabIndex = 7;
            // 
            // tFileChecker
            // 
            this.tFileChecker.Interval = 200;
            this.tFileChecker.Tick += new System.EventHandler(this.tFileChecker_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtBPPFile);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBPPPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkBPP);
            this.groupBox1.Location = new System.Drawing.Point(12, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 78);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BPP";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(317, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBPPFile
            // 
            this.txtBPPFile.Enabled = false;
            this.txtBPPFile.Location = new System.Drawing.Point(44, 45);
            this.txtBPPFile.Name = "txtBPPFile";
            this.txtBPPFile.Size = new System.Drawing.Size(267, 23);
            this.txtBPPFile.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "File";
            // 
            // txtBPPPort
            // 
            this.txtBPPPort.Enabled = false;
            this.txtBPPPort.Location = new System.Drawing.Point(271, 16);
            this.txtBPPPort.Name = "txtBPPPort";
            this.txtBPPPort.Size = new System.Drawing.Size(83, 23);
            this.txtBPPPort.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Port";
            // 
            // chkBPP
            // 
            this.chkBPP.AutoSize = true;
            this.chkBPP.Location = new System.Drawing.Point(13, 20);
            this.chkBPP.Name = "chkBPP";
            this.chkBPP.Size = new System.Drawing.Size(85, 19);
            this.chkBPP.TabIndex = 0;
            this.chkBPP.Text = "Enable BPP";
            this.chkBPP.UseVisualStyleBackColor = true;
            this.chkBPP.CheckedChanged += new System.EventHandler(this.chkBPP_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 191);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbDestination);
            this.Controls.Add(this.pbMarquee);
            this.Controls.Add(this.btnTog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelFile);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(785, 153);
            this.Name = "Form1";
            this.Text = "File Printer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtFileName;
        private Button btnSelFile;
        private Label label2;
        private Button btnTog;
        private ProgressBar pbMarquee;
        private ComboBox cmbDestination;
        private System.Windows.Forms.Timer tFileChecker;
        private GroupBox groupBox1;
        private Button button1;
        private TextBox txtBPPFile;
        private Label label4;
        private TextBox txtBPPPort;
        private Label label3;
        private CheckBox chkBPP;
    }
}