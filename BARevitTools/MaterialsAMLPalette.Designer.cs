namespace BARevitTools
{
    partial class MaterialsAMLPalette
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialsAMLPalette));
            this.paletteLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.paletteSelectPanel = new System.Windows.Forms.Panel();
            this.paletteSelectButton = new System.Windows.Forms.Button();
            this.paletteSelectLabel = new System.Windows.Forms.Label();
            this.paletteMaterialPanel = new System.Windows.Forms.Panel();
            this.paletteMaterialComboBox = new System.Windows.Forms.ComboBox();
            this.paletteMaterialLabel = new System.Windows.Forms.Label();
            this.paletteInstructionsTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.paletteLayoutPanel.SuspendLayout();
            this.paletteSelectPanel.SuspendLayout();
            this.paletteMaterialPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // paletteLayoutPanel
            // 
            this.paletteLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.paletteLayoutPanel.ColumnCount = 3;
            this.paletteLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paletteLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.paletteLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.paletteLayoutPanel.Controls.Add(this.paletteSelectPanel, 2, 0);
            this.paletteLayoutPanel.Controls.Add(this.paletteMaterialPanel, 1, 0);
            this.paletteLayoutPanel.Controls.Add(this.paletteInstructionsTextBox, 1, 1);
            this.paletteLayoutPanel.Controls.Add(this.pictureBox1, 0, 0);
            this.paletteLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paletteLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.paletteLayoutPanel.Name = "paletteLayoutPanel";
            this.paletteLayoutPanel.RowCount = 2;
            this.paletteLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.paletteLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paletteLayoutPanel.Size = new System.Drawing.Size(353, 105);
            this.paletteLayoutPanel.TabIndex = 0;
            // 
            // paletteSelectPanel
            // 
            this.paletteSelectPanel.BackColor = System.Drawing.SystemColors.Control;
            this.paletteSelectPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paletteSelectPanel.Controls.Add(this.paletteSelectButton);
            this.paletteSelectPanel.Controls.Add(this.paletteSelectLabel);
            this.paletteSelectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paletteSelectPanel.Location = new System.Drawing.Point(253, 3);
            this.paletteSelectPanel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.paletteSelectPanel.Name = "paletteSelectPanel";
            this.paletteSelectPanel.Size = new System.Drawing.Size(97, 52);
            this.paletteSelectPanel.TabIndex = 0;
            // 
            // paletteSelectButton
            // 
            this.paletteSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.paletteSelectButton.Location = new System.Drawing.Point(3, 21);
            this.paletteSelectButton.Name = "paletteSelectButton";
            this.paletteSelectButton.Size = new System.Drawing.Size(87, 23);
            this.paletteSelectButton.TabIndex = 1;
            this.paletteSelectButton.Text = "Select";
            this.paletteSelectButton.UseVisualStyleBackColor = false;
            this.paletteSelectButton.Click += new System.EventHandler(this.PaletteSelectButton_Click);
            // 
            // paletteSelectLabel
            // 
            this.paletteSelectLabel.AutoSize = true;
            this.paletteSelectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paletteSelectLabel.Location = new System.Drawing.Point(3, 4);
            this.paletteSelectLabel.Name = "paletteSelectLabel";
            this.paletteSelectLabel.Size = new System.Drawing.Size(86, 13);
            this.paletteSelectLabel.TabIndex = 0;
            this.paletteSelectLabel.Text = "Select Points:";
            // 
            // paletteMaterialPanel
            // 
            this.paletteMaterialPanel.BackColor = System.Drawing.SystemColors.Control;
            this.paletteMaterialPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paletteMaterialPanel.Controls.Add(this.paletteMaterialComboBox);
            this.paletteMaterialPanel.Controls.Add(this.paletteMaterialLabel);
            this.paletteMaterialPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paletteMaterialPanel.Location = new System.Drawing.Point(118, 3);
            this.paletteMaterialPanel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.paletteMaterialPanel.Name = "paletteMaterialPanel";
            this.paletteMaterialPanel.Size = new System.Drawing.Size(132, 52);
            this.paletteMaterialPanel.TabIndex = 1;
            // 
            // paletteMaterialComboBox
            // 
            this.paletteMaterialComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteMaterialComboBox.FormattingEnabled = true;
            this.paletteMaterialComboBox.Location = new System.Drawing.Point(3, 23);
            this.paletteMaterialComboBox.Name = "paletteMaterialComboBox";
            this.paletteMaterialComboBox.Size = new System.Drawing.Size(124, 21);
            this.paletteMaterialComboBox.TabIndex = 1;
            this.paletteMaterialComboBox.Text = "Default";
            // 
            // paletteMaterialLabel
            // 
            this.paletteMaterialLabel.AutoSize = true;
            this.paletteMaterialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paletteMaterialLabel.Location = new System.Drawing.Point(3, 4);
            this.paletteMaterialLabel.Name = "paletteMaterialLabel";
            this.paletteMaterialLabel.Size = new System.Drawing.Size(96, 13);
            this.paletteMaterialLabel.TabIndex = 0;
            this.paletteMaterialLabel.Text = "Select Material:";
            // 
            // paletteInstructionsTextBox
            // 
            this.paletteInstructionsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.paletteLayoutPanel.SetColumnSpan(this.paletteInstructionsTextBox, 2);
            this.paletteInstructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paletteInstructionsTextBox.Location = new System.Drawing.Point(118, 58);
            this.paletteInstructionsTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.paletteInstructionsTextBox.Multiline = true;
            this.paletteInstructionsTextBox.Name = "paletteInstructionsTextBox";
            this.paletteInstructionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.paletteInstructionsTextBox.Size = new System.Drawing.Size(232, 44);
            this.paletteInstructionsTextBox.TabIndex = 2;
            this.paletteInstructionsTextBox.Text = resources.GetString("paletteInstructionsTextBox.Text");
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::BARevitTools.Properties.Resources.materialsAMLInstructions;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.paletteLayoutPanel.SetRowSpan(this.pictureBox1, 2);
            this.pictureBox1.Size = new System.Drawing.Size(112, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // MaterialsAMLPalette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 111);
            this.Controls.Add(this.paletteLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(260, 103);
            this.Name = "MaterialsAMLPalette";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accent Material Line Picker";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MaterialsAMLPalette_FormClosed);
            this.paletteLayoutPanel.ResumeLayout(false);
            this.paletteLayoutPanel.PerformLayout();
            this.paletteSelectPanel.ResumeLayout(false);
            this.paletteSelectPanel.PerformLayout();
            this.paletteMaterialPanel.ResumeLayout(false);
            this.paletteMaterialPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel paletteSelectPanel;
        private System.Windows.Forms.Button paletteSelectButton;
        private System.Windows.Forms.Label paletteSelectLabel;
        private System.Windows.Forms.Panel paletteMaterialPanel;
        private System.Windows.Forms.Label paletteMaterialLabel;
        public System.Windows.Forms.ComboBox paletteMaterialComboBox;
        private System.Windows.Forms.TextBox paletteInstructionsTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TableLayoutPanel paletteLayoutPanel;
    }
}