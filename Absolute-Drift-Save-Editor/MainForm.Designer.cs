namespace Absolute_Drift_Save_Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.loadToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.unlockAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.valuesToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.addValueToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripButton,
            this.loadToolStripButton,
            this.saveToolStripButton,
            this.unlockAllToolStripButton,
            this.valuesToolStripComboBox,
            this.addValueToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(515, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip";
            // 
            // aboutToolStripButton
            // 
            this.aboutToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutToolStripButton.AutoToolTip = false;
            this.aboutToolStripButton.Image = global::Absolute_Drift_Save_Editor.Properties.Resources.information;
            this.aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolStripButton.Name = "aboutToolStripButton";
            this.aboutToolStripButton.Size = new System.Drawing.Size(60, 22);
            this.aboutToolStripButton.Text = "About";
            this.aboutToolStripButton.Click += new System.EventHandler(this.aboutToolStripButton_Click);
            // 
            // loadToolStripButton
            // 
            this.loadToolStripButton.AutoToolTip = false;
            this.loadToolStripButton.Image = global::Absolute_Drift_Save_Editor.Properties.Resources.bullet_go;
            this.loadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadToolStripButton.Name = "loadToolStripButton";
            this.loadToolStripButton.Size = new System.Drawing.Size(53, 22);
            this.loadToolStripButton.Text = "Load";
            this.loadToolStripButton.Click += new System.EventHandler(this.loadToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.AutoToolTip = false;
            this.saveToolStripButton.Image = global::Absolute_Drift_Save_Editor.Properties.Resources.table_save;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(51, 22);
            this.saveToolStripButton.Text = "Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // unlockAllToolStripButton
            // 
            this.unlockAllToolStripButton.AutoToolTip = false;
            this.unlockAllToolStripButton.Image = global::Absolute_Drift_Save_Editor.Properties.Resources.lock_open;
            this.unlockAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.unlockAllToolStripButton.Name = "unlockAllToolStripButton";
            this.unlockAllToolStripButton.Size = new System.Drawing.Size(81, 22);
            this.unlockAllToolStripButton.Text = "Unlock All";
            this.unlockAllToolStripButton.Click += new System.EventHandler(this.unlockAllToolStripButton_Click);
            // 
            // valuesToolStripComboBox
            // 
            this.valuesToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valuesToolStripComboBox.DropDownWidth = 400;
            this.valuesToolStripComboBox.Name = "valuesToolStripComboBox";
            this.valuesToolStripComboBox.Size = new System.Drawing.Size(121, 25);
            // 
            // addValueToolStripButton
            // 
            this.addValueToolStripButton.Image = global::Absolute_Drift_Save_Editor.Properties.Resources.table_row_insert;
            this.addValueToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addValueToolStripButton.Name = "addValueToolStripButton";
            this.addValueToolStripButton.Size = new System.Drawing.Size(80, 22);
            this.addValueToolStripButton.Text = "Add Value";
            this.addValueToolStripButton.Click += new System.EventHandler(this.addValueToolStripButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(515, 420);
            this.dataGridView1.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 445);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Absolute Drift Save Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripComboBox valuesToolStripComboBox;
        private System.Windows.Forms.ToolStripButton addValueToolStripButton;
        private System.Windows.Forms.ToolStripButton unlockAllToolStripButton;
        private System.Windows.Forms.ToolStripButton loadToolStripButton;
    }
}

