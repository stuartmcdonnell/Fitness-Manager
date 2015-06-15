namespace FitNess3
{
    partial class Client_Planner
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
            this.radCalendar1 = new Telerik.WinControls.UI.RadCalendar();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radCalendar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radCalendar1
            // 
            this.radCalendar1.Location = new System.Drawing.Point(12, 12);
            this.radCalendar1.Name = "radCalendar1";
            this.radCalendar1.Size = new System.Drawing.Size(362, 281);
            this.radCalendar1.TabIndex = 0;
            this.radCalendar1.Text = "Client Sessions";
            this.radCalendar1.ThemeName = "Windows8";
            this.radCalendar1.SelectionChanged += new System.EventHandler(this.radCalendar1_SelectionChanged);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0))).Enabled = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(380, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 281);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Session Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(9, 80);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(285, 160);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Session Notes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Session Time:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(209, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add Session";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(111, 246);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Update Session";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.dateTimePicker1.CustomFormat = "HH:mm";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(109, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(103, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 246);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 29);
            this.button3.TabIndex = 6;
            this.button3.Text = "Remove Session";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Client_Planner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 305);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radCalendar1);
            this.Name = "Client_Planner";
            this.Text = "Client Planner";
            this.Load += new System.EventHandler(this.Client_Planner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radCalendar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadCalendar radCalendar1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button3;
    }
}