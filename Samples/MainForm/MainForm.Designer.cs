namespace SimpleIfcViewer
{
    partial class MainForm
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
            this.tv = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdSelectFile = new System.Windows.Forms.Button();
            this.pg = new System.Windows.Forms.PropertyGrid();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.Location = new System.Drawing.Point(0, 38);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(406, 692);
            this.tv.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdSelectFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 38);
            this.panel1.TabIndex = 1;
            // 
            // cmdSelectFile
            // 
            this.cmdSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelectFile.Location = new System.Drawing.Point(12, 8);
            this.cmdSelectFile.Name = "cmdSelectFile";
            this.cmdSelectFile.Size = new System.Drawing.Size(761, 23);
            this.cmdSelectFile.TabIndex = 2;
            this.cmdSelectFile.Text = "Select File...";
            this.cmdSelectFile.UseVisualStyleBackColor = true;
            this.cmdSelectFile.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // pg
            // 
            this.pg.Dock = System.Windows.Forms.DockStyle.Right;
            this.pg.Location = new System.Drawing.Point(406, 38);
            this.pg.Name = "pg";
            this.pg.Size = new System.Drawing.Size(379, 692);
            this.pg.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 730);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.pg);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "SimpleIfcViewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdSelectFile;
        private System.Windows.Forms.PropertyGrid pg;
    }
}

