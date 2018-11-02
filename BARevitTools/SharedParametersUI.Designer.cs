namespace BARevitTools
{
    partial class SharedParametersUI
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SharedParameterTypeTextBox = new System.Windows.Forms.TextBox();
            this.SharedParameterTypeLabel = new System.Windows.Forms.Label();
            this.SharedParameterNameLabel = new System.Windows.Forms.Label();
            this.SharedParameterGroupLabel = new System.Windows.Forms.Label();
            this.SharedParameterNameComboBox = new System.Windows.Forms.ComboBox();
            this.SharedParameterGroupComboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SharedParameterAddButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 161);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.SharedParameterTypeTextBox);
            this.panel1.Controls.Add(this.SharedParameterTypeLabel);
            this.panel1.Controls.Add(this.SharedParameterNameLabel);
            this.panel1.Controls.Add(this.SharedParameterGroupLabel);
            this.panel1.Controls.Add(this.SharedParameterNameComboBox);
            this.panel1.Controls.Add(this.SharedParameterGroupComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 126);
            this.panel1.TabIndex = 0;
            // 
            // SharedParameterTypeTextBox
            // 
            this.SharedParameterTypeTextBox.Location = new System.Drawing.Point(68, 77);
            this.SharedParameterTypeTextBox.Name = "SharedParameterTypeTextBox";
            this.SharedParameterTypeTextBox.ReadOnly = true;
            this.SharedParameterTypeTextBox.Size = new System.Drawing.Size(210, 20);
            this.SharedParameterTypeTextBox.TabIndex = 2;
            // 
            // SharedParameterTypeLabel
            // 
            this.SharedParameterTypeLabel.AutoSize = true;
            this.SharedParameterTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SharedParameterTypeLabel.Location = new System.Drawing.Point(3, 80);
            this.SharedParameterTypeLabel.Name = "SharedParameterTypeLabel";
            this.SharedParameterTypeLabel.Size = new System.Drawing.Size(39, 13);
            this.SharedParameterTypeLabel.TabIndex = 1;
            this.SharedParameterTypeLabel.Text = "Type:";
            // 
            // SharedParameterNameLabel
            // 
            this.SharedParameterNameLabel.AutoSize = true;
            this.SharedParameterNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SharedParameterNameLabel.Location = new System.Drawing.Point(3, 46);
            this.SharedParameterNameLabel.Name = "SharedParameterNameLabel";
            this.SharedParameterNameLabel.Size = new System.Drawing.Size(43, 13);
            this.SharedParameterNameLabel.TabIndex = 1;
            this.SharedParameterNameLabel.Text = "Name:";
            // 
            // SharedParameterGroupLabel
            // 
            this.SharedParameterGroupLabel.AutoSize = true;
            this.SharedParameterGroupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SharedParameterGroupLabel.Location = new System.Drawing.Point(3, 11);
            this.SharedParameterGroupLabel.Name = "SharedParameterGroupLabel";
            this.SharedParameterGroupLabel.Size = new System.Drawing.Size(45, 13);
            this.SharedParameterGroupLabel.TabIndex = 1;
            this.SharedParameterGroupLabel.Text = "Group:";
            // 
            // SharedParameterNameComboBox
            // 
            this.SharedParameterNameComboBox.FormattingEnabled = true;
            this.SharedParameterNameComboBox.Location = new System.Drawing.Point(68, 43);
            this.SharedParameterNameComboBox.Name = "SharedParameterNameComboBox";
            this.SharedParameterNameComboBox.Size = new System.Drawing.Size(210, 21);
            this.SharedParameterNameComboBox.TabIndex = 0;
            this.SharedParameterNameComboBox.SelectedIndexChanged += new System.EventHandler(this.SharedParameterNameComboBox_SelectedIndexChanged);
            // 
            // SharedParameterGroupComboBox
            // 
            this.SharedParameterGroupComboBox.FormattingEnabled = true;
            this.SharedParameterGroupComboBox.Location = new System.Drawing.Point(68, 8);
            this.SharedParameterGroupComboBox.Name = "SharedParameterGroupComboBox";
            this.SharedParameterGroupComboBox.Size = new System.Drawing.Size(210, 21);
            this.SharedParameterGroupComboBox.TabIndex = 0;
            this.SharedParameterGroupComboBox.SelectedIndexChanged += new System.EventHandler(this.SharedParameterGroupComboBox_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SharedParameterAddButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 126);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 35);
            this.panel2.TabIndex = 1;
            // 
            // SharedParameterAddButton
            // 
            this.SharedParameterAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SharedParameterAddButton.Location = new System.Drawing.Point(178, 6);
            this.SharedParameterAddButton.Name = "SharedParameterAddButton";
            this.SharedParameterAddButton.Size = new System.Drawing.Size(101, 23);
            this.SharedParameterAddButton.TabIndex = 0;
            this.SharedParameterAddButton.Text = "Add Parameter";
            this.SharedParameterAddButton.UseVisualStyleBackColor = true;
            this.SharedParameterAddButton.Click += new System.EventHandler(this.SharedParameterAddButton_Click);
            // 
            // SharedParametersUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SharedParametersUI";
            this.Text = "Shared Parameters";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label SharedParameterTypeLabel;
        private System.Windows.Forms.Label SharedParameterNameLabel;
        private System.Windows.Forms.Label SharedParameterGroupLabel;
        private System.Windows.Forms.Button SharedParameterAddButton;
        public System.Windows.Forms.TextBox SharedParameterTypeTextBox;
        public System.Windows.Forms.ComboBox SharedParameterNameComboBox;
        public System.Windows.Forms.ComboBox SharedParameterGroupComboBox;
    }
}