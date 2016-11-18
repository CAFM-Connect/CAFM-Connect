namespace CafmConnect.Manufacturer.UI
{
    partial class ViewDLG
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
            this._buttonOK = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._textBoxCode = new System.Windows.Forms.TextBox();
            this._dataGridViewManufacturers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewManufacturers)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonOK
            // 
            this._buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOK.Location = new System.Drawing.Point(254, 363);
            this._buttonOK.Name = "_buttonOK";
            this._buttonOK.Size = new System.Drawing.Size(75, 23);
            this._buttonOK.TabIndex = 0;
            this._buttonOK.Text = "OK";
            this._buttonOK.UseVisualStyleBackColor = true;
            // 
            // _buttonCancel
            // 
            this._buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(12, 363);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 1;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Code";
            // 
            // _textBoxCode
            // 
            this._textBoxCode.Location = new System.Drawing.Point(12, 28);
            this._textBoxCode.Name = "_textBoxCode";
            this._textBoxCode.ReadOnly = true;
            this._textBoxCode.Size = new System.Drawing.Size(100, 20);
            this._textBoxCode.TabIndex = 3;
            // 
            // _dataGridViewManufacturers
            // 
            this._dataGridViewManufacturers.AllowUserToAddRows = false;
            this._dataGridViewManufacturers.AllowUserToDeleteRows = false;
            this._dataGridViewManufacturers.AllowUserToResizeColumns = false;
            this._dataGridViewManufacturers.AllowUserToResizeRows = false;
            this._dataGridViewManufacturers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridViewManufacturers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._dataGridViewManufacturers.BackgroundColor = System.Drawing.Color.White;
            this._dataGridViewManufacturers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewManufacturers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._dataGridViewManufacturers.Location = new System.Drawing.Point(12, 54);
            this._dataGridViewManufacturers.MultiSelect = false;
            this._dataGridViewManufacturers.Name = "_dataGridViewManufacturers";
            this._dataGridViewManufacturers.ReadOnly = true;
            this._dataGridViewManufacturers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this._dataGridViewManufacturers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridViewManufacturers.Size = new System.Drawing.Size(317, 303);
            this._dataGridViewManufacturers.TabIndex = 4;
            this._dataGridViewManufacturers.SelectionChanged += new System.EventHandler(this._dataGridViewManufacturers_SelectionChanged);
            // 
            // ViewDLG
            // 
            this.AcceptButton = this._buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(341, 398);
            this.Controls.Add(this._dataGridViewManufacturers);
            this.Controls.Add(this._textBoxCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ViewDLG";
            this.Text = "ManufacturerDLG";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewManufacturers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonOK;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _textBoxCode;
        private System.Windows.Forms.DataGridView _dataGridViewManufacturers;
    }
}