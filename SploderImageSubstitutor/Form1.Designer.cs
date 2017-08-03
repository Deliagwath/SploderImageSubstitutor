namespace SploderImageSubstitutor
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
            this.XMLButton = new System.Windows.Forms.Button();
            this.ImageButton = new System.Windows.Forms.Button();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.DebugButton = new System.Windows.Forms.Button();
            this.XMLFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TextBoxLog = new System.Windows.Forms.TextBox();
            this.ImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // XMLButton
            // 
            this.XMLButton.Location = new System.Drawing.Point(13, 13);
            this.XMLButton.Name = "XMLButton";
            this.XMLButton.Size = new System.Drawing.Size(116, 23);
            this.XMLButton.TabIndex = 0;
            this.XMLButton.Text = "XML Location";
            this.XMLButton.UseVisualStyleBackColor = true;
            this.XMLButton.Click += new System.EventHandler(this.XMLButton_Click);
            // 
            // ImageButton
            // 
            this.ImageButton.Location = new System.Drawing.Point(13, 42);
            this.ImageButton.Name = "ImageButton";
            this.ImageButton.Size = new System.Drawing.Size(116, 23);
            this.ImageButton.TabIndex = 1;
            this.ImageButton.Text = "Image Location(s)";
            this.ImageButton.UseVisualStyleBackColor = true;
            this.ImageButton.Click += new System.EventHandler(this.ImageButton_Click);
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(13, 71);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(116, 23);
            this.ConvertButton.TabIndex = 2;
            this.ConvertButton.Text = "Convert and Swap";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // DebugButton
            // 
            this.DebugButton.Location = new System.Drawing.Point(12, 100);
            this.DebugButton.Name = "DebugButton";
            this.DebugButton.Size = new System.Drawing.Size(116, 23);
            this.DebugButton.TabIndex = 3;
            this.DebugButton.Text = "Debug";
            this.DebugButton.UseVisualStyleBackColor = true;
            // 
            // XMLFileDialog
            // 
            this.XMLFileDialog.FileName = "game.xml";
            // 
            // TextBoxLog
            // 
            this.TextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxLog.Location = new System.Drawing.Point(136, 13);
            this.TextBoxLog.Multiline = true;
            this.TextBoxLog.Name = "TextBoxLog";
            this.TextBoxLog.ReadOnly = true;
            this.TextBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxLog.Size = new System.Drawing.Size(293, 110);
            this.TextBoxLog.TabIndex = 4;
            this.TextBoxLog.WordWrap = false;
            // 
            // ImageFileDialog
            // 
            this.ImageFileDialog.FileName = "image";
            this.ImageFileDialog.Multiselect = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 135);
            this.Controls.Add(this.TextBoxLog);
            this.Controls.Add(this.DebugButton);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.ImageButton);
            this.Controls.Add(this.XMLButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button XMLButton;
        private System.Windows.Forms.Button ImageButton;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.Button DebugButton;
        private System.Windows.Forms.OpenFileDialog XMLFileDialog;
        private System.Windows.Forms.TextBox TextBoxLog;
        private System.Windows.Forms.OpenFileDialog ImageFileDialog;

    }
}

