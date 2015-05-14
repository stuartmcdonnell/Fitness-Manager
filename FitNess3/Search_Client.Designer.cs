namespace FitNess3
{
    partial class Search_Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search_Client));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.surname_textbox = new System.Windows.Forms.TextBox();
            this.forename_textbox = new System.Windows.Forms.TextBox();
            this.search_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Surname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Forename";
            // 
            // surname_textbox
            // 
            this.surname_textbox.Location = new System.Drawing.Point(72, 38);
            this.surname_textbox.Name = "surname_textbox";
            this.surname_textbox.Size = new System.Drawing.Size(116, 20);
            this.surname_textbox.TabIndex = 7;
            // 
            // forename_textbox
            // 
            this.forename_textbox.Location = new System.Drawing.Point(72, 12);
            this.forename_textbox.Name = "forename_textbox";
            this.forename_textbox.Size = new System.Drawing.Size(116, 20);
            this.forename_textbox.TabIndex = 6;
            this.forename_textbox.TextChanged += new System.EventHandler(this.forename_textbox_TextChanged);
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(108, 78);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(80, 34);
            this.search_button.TabIndex = 5;
            this.search_button.Text = "Search";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Search_Client
            // 
            this.AcceptButton = this.search_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 123);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.surname_textbox);
            this.Controls.Add(this.forename_textbox);
            this.Controls.Add(this.search_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Search_Client";
            this.Text = "Client Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Search_Client_FormClosing);
            this.Load += new System.EventHandler(this.Search_Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox surname_textbox;
        private System.Windows.Forms.TextBox forename_textbox;
        private System.Windows.Forms.Button search_button;
    }
}