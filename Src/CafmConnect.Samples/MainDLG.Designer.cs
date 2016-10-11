namespace CafmConnect.Samples
{
    partial class MainDLG
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._buttonCreateManufacturerData = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._buttonConsume = new System.Windows.Forms.Button();
            this._buttonViewer = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._buttonCreateManufacturerData);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 339);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manufacturer";
            // 
            // _buttonCreateManufacturerData
            // 
            this._buttonCreateManufacturerData.Dock = System.Windows.Forms.DockStyle.Top;
            this._buttonCreateManufacturerData.Location = new System.Drawing.Point(3, 16);
            this._buttonCreateManufacturerData.Name = "_buttonCreateManufacturerData";
            this._buttonCreateManufacturerData.Size = new System.Drawing.Size(291, 23);
            this._buttonCreateManufacturerData.TabIndex = 0;
            this._buttonCreateManufacturerData.Text = "Create Manufacturer Data";
            this._buttonCreateManufacturerData.UseVisualStyleBackColor = true;
            this._buttonCreateManufacturerData.Click += new System.EventHandler(this._buttonCreateManufacturerData_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this._buttonConsume);
            this.groupBox2.Location = new System.Drawing.Point(315, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 382);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer";
            // 
            // _buttonConsume
            // 
            this._buttonConsume.Dock = System.Windows.Forms.DockStyle.Top;
            this._buttonConsume.Location = new System.Drawing.Point(3, 16);
            this._buttonConsume.Name = "_buttonConsume";
            this._buttonConsume.Size = new System.Drawing.Size(316, 23);
            this._buttonConsume.TabIndex = 0;
            this._buttonConsume.Text = "Consume Manufacturer Data";
            this._buttonConsume.UseVisualStyleBackColor = true;
            // 
            // _buttonViewer
            // 
            this._buttonViewer.Location = new System.Drawing.Point(12, 371);
            this._buttonViewer.Name = "_buttonViewer";
            this._buttonViewer.Size = new System.Drawing.Size(297, 23);
            this._buttonViewer.TabIndex = 1;
            this._buttonViewer.Text = "StartViewer";
            this._buttonViewer.UseVisualStyleBackColor = true;
            this._buttonViewer.Click += new System.EventHandler(this._buttonViewer_Click);
            // 
            // MainDLG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 406);
            this.Controls.Add(this._buttonViewer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MainDLG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CafmConnect Samples";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _buttonCreateManufacturerData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button _buttonConsume;
        private System.Windows.Forms.Button _buttonViewer;
    }
}