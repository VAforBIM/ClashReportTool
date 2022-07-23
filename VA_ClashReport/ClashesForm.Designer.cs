
namespace IND_3DviewFromNavisWorks
{
    partial class ClashesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClashesForm));
            this.BrowseButton = new System.Windows.Forms.Button();
            this.FileLocationTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Item1checkBox = new System.Windows.Forms.CheckBox();
            this.Item2checkBox = new System.Windows.Forms.CheckBox();
            this.CreateClashesButton = new System.Windows.Forms.Button();
            this.RangeTextBox = new System.Windows.Forms.TextBox();
            this.RangeLabel = new System.Windows.Forms.Label();
            this.RangeExampleLabel = new System.Windows.Forms.Label();
            this.ItemSelectionLabel = new System.Windows.Forms.Label();
            this.BrowseLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(279, 27);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 26);
            this.BrowseButton.TabIndex = 0;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // FileLocationTextBox
            // 
            this.FileLocationTextBox.Location = new System.Drawing.Point(13, 31);
            this.FileLocationTextBox.Name = "FileLocationTextBox";
            this.FileLocationTextBox.Size = new System.Drawing.Size(260, 20);
            this.FileLocationTextBox.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Item1checkBox
            // 
            this.Item1checkBox.AutoSize = true;
            this.Item1checkBox.Location = new System.Drawing.Point(13, 90);
            this.Item1checkBox.Name = "Item1checkBox";
            this.Item1checkBox.Size = new System.Drawing.Size(55, 17);
            this.Item1checkBox.TabIndex = 2;
            this.Item1checkBox.Text = "Item 1";
            this.Item1checkBox.UseVisualStyleBackColor = true;
            // 
            // Item2checkBox
            // 
            this.Item2checkBox.AutoSize = true;
            this.Item2checkBox.Location = new System.Drawing.Point(74, 90);
            this.Item2checkBox.Name = "Item2checkBox";
            this.Item2checkBox.Size = new System.Drawing.Size(55, 17);
            this.Item2checkBox.TabIndex = 3;
            this.Item2checkBox.Text = "Item 2";
            this.Item2checkBox.UseVisualStyleBackColor = true;
            // 
            // CreateClashesButton
            // 
            this.CreateClashesButton.Location = new System.Drawing.Point(120, 113);
            this.CreateClashesButton.Name = "CreateClashesButton";
            this.CreateClashesButton.Size = new System.Drawing.Size(143, 23);
            this.CreateClashesButton.TabIndex = 4;
            this.CreateClashesButton.Text = "Create clashes";
            this.CreateClashesButton.UseVisualStyleBackColor = true;
            this.CreateClashesButton.Click += new System.EventHandler(this.CreateClashesButton_Click);
            // 
            // RangeTextBox
            // 
            this.RangeTextBox.Location = new System.Drawing.Point(190, 88);
            this.RangeTextBox.Name = "RangeTextBox";
            this.RangeTextBox.Size = new System.Drawing.Size(164, 20);
            this.RangeTextBox.TabIndex = 5;
            // 
            // RangeLabel
            // 
            this.RangeLabel.AutoSize = true;
            this.RangeLabel.Location = new System.Drawing.Point(194, 57);
            this.RangeLabel.Name = "RangeLabel";
            this.RangeLabel.Size = new System.Drawing.Size(135, 13);
            this.RangeLabel.TabIndex = 6;
            this.RangeLabel.Text = "Leave empty for all clashes";
            // 
            // RangeExampleLabel
            // 
            this.RangeExampleLabel.AutoSize = true;
            this.RangeExampleLabel.Location = new System.Drawing.Point(195, 72);
            this.RangeExampleLabel.Name = "RangeExampleLabel";
            this.RangeExampleLabel.Size = new System.Drawing.Size(106, 13);
            this.RangeExampleLabel.TabIndex = 7;
            this.RangeExampleLabel.Text = "e.g 0-15 for selection";
            // 
            // ItemSelectionLabel
            // 
            this.ItemSelectionLabel.AutoSize = true;
            this.ItemSelectionLabel.Location = new System.Drawing.Point(10, 57);
            this.ItemSelectionLabel.Name = "ItemSelectionLabel";
            this.ItemSelectionLabel.Size = new System.Drawing.Size(140, 13);
            this.ItemSelectionLabel.TabIndex = 8;
            this.ItemSelectionLabel.Text = "Select either item 1 or item 2";
            // 
            // BrowseLabel
            // 
            this.BrowseLabel.AutoSize = true;
            this.BrowseLabel.Location = new System.Drawing.Point(12, 15);
            this.BrowseLabel.Name = "BrowseLabel";
            this.BrowseLabel.Size = new System.Drawing.Size(152, 13);
            this.BrowseLabel.TabIndex = 9;
            this.BrowseLabel.Text = "Browse to your .txt clash report";
            // 
            // ClashesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 148);
            this.Controls.Add(this.BrowseLabel);
            this.Controls.Add(this.ItemSelectionLabel);
            this.Controls.Add(this.RangeExampleLabel);
            this.Controls.Add(this.RangeLabel);
            this.Controls.Add(this.RangeTextBox);
            this.Controls.Add(this.CreateClashesButton);
            this.Controls.Add(this.Item2checkBox);
            this.Controls.Add(this.Item1checkBox);
            this.Controls.Add(this.FileLocationTextBox);
            this.Controls.Add(this.BrowseButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClashesForm";
            this.Text = "Create 3D view for clash inspection";
            this.Load += new System.EventHandler(this.ClashesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox FileLocationTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox Item1checkBox;
        private System.Windows.Forms.CheckBox Item2checkBox;
        private System.Windows.Forms.Button CreateClashesButton;
        private System.Windows.Forms.TextBox RangeTextBox;
        private System.Windows.Forms.Label RangeLabel;
        private System.Windows.Forms.Label RangeExampleLabel;
        private System.Windows.Forms.Label ItemSelectionLabel;
        private System.Windows.Forms.Label BrowseLabel;
    }
}