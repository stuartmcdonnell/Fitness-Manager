﻿namespace FitNess3
{
    partial class Home
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.add_client = new System.Windows.Forms.Button();
            this.assign_plan = new System.Windows.Forms.Button();
            this.search_client = new System.Windows.Forms.Button();
            this.list_users = new System.Windows.Forms.Button();
            this.modifydietplan = new System.Windows.Forms.Button();
            this.searchplan = new System.Windows.Forms.Button();
            this.listplans = new System.Windows.Forms.Button();
            this.showplancontent = new System.Windows.Forms.Button();
            this.addfood = new System.Windows.Forms.Button();
            this.listfoods = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(824, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(79, 22);
            this.toolStripLabel1.Text = "Please Log In!";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // add_client
            // 
            this.add_client.Enabled = false;
            this.add_client.Location = new System.Drawing.Point(6, 6);
            this.add_client.Name = "add_client";
            this.add_client.Size = new System.Drawing.Size(255, 78);
            this.add_client.TabIndex = 3;
            this.add_client.Text = "Add Client";
            this.add_client.UseVisualStyleBackColor = true;
            this.add_client.Click += new System.EventHandler(this.add_client_Click);
            // 
            // assign_plan
            // 
            this.assign_plan.Enabled = false;
            this.assign_plan.Location = new System.Drawing.Point(6, 90);
            this.assign_plan.Name = "assign_plan";
            this.assign_plan.Size = new System.Drawing.Size(255, 78);
            this.assign_plan.TabIndex = 4;
            this.assign_plan.Text = "Assign Diet/Workout";
            this.assign_plan.UseVisualStyleBackColor = true;
            this.assign_plan.Click += new System.EventHandler(this.assign_plan_Click);
            // 
            // search_client
            // 
            this.search_client.Enabled = false;
            this.search_client.Location = new System.Drawing.Point(267, 90);
            this.search_client.Name = "search_client";
            this.search_client.Size = new System.Drawing.Size(255, 78);
            this.search_client.TabIndex = 5;
            this.search_client.Text = "Search Client";
            this.search_client.UseVisualStyleBackColor = true;
            this.search_client.Click += new System.EventHandler(this.button2_Click);
            // 
            // list_users
            // 
            this.list_users.Enabled = false;
            this.list_users.Location = new System.Drawing.Point(267, 6);
            this.list_users.Name = "list_users";
            this.list_users.Size = new System.Drawing.Size(255, 78);
            this.list_users.TabIndex = 6;
            this.list_users.Text = "List Clients";
            this.list_users.UseVisualStyleBackColor = true;
            this.list_users.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // modifydietplan
            // 
            this.modifydietplan.Enabled = false;
            this.modifydietplan.Location = new System.Drawing.Point(6, 6);
            this.modifydietplan.Name = "modifydietplan";
            this.modifydietplan.Size = new System.Drawing.Size(255, 78);
            this.modifydietplan.TabIndex = 8;
            this.modifydietplan.Text = "Add/Modify Diet Plan";
            this.modifydietplan.UseVisualStyleBackColor = true;
            this.modifydietplan.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // searchplan
            // 
            this.searchplan.Enabled = false;
            this.searchplan.Location = new System.Drawing.Point(267, 90);
            this.searchplan.Name = "searchplan";
            this.searchplan.Size = new System.Drawing.Size(255, 78);
            this.searchplan.TabIndex = 9;
            this.searchplan.Text = "Search Plan";
            this.searchplan.UseVisualStyleBackColor = true;
            this.searchplan.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // listplans
            // 
            this.listplans.Enabled = false;
            this.listplans.Location = new System.Drawing.Point(267, 6);
            this.listplans.Name = "listplans";
            this.listplans.Size = new System.Drawing.Size(255, 78);
            this.listplans.TabIndex = 10;
            this.listplans.Text = "List Plans";
            this.listplans.UseVisualStyleBackColor = true;
            this.listplans.Click += new System.EventHandler(this.button3_Click);
            // 
            // showplancontent
            // 
            this.showplancontent.Enabled = false;
            this.showplancontent.Location = new System.Drawing.Point(6, 89);
            this.showplancontent.Name = "showplancontent";
            this.showplancontent.Size = new System.Drawing.Size(255, 78);
            this.showplancontent.TabIndex = 11;
            this.showplancontent.Text = "Show Plan Content";
            this.showplancontent.UseVisualStyleBackColor = true;
            this.showplancontent.Click += new System.EventHandler(this.button4_Click);
            // 
            // addfood
            // 
            this.addfood.Enabled = false;
            this.addfood.Location = new System.Drawing.Point(6, 6);
            this.addfood.Name = "addfood";
            this.addfood.Size = new System.Drawing.Size(255, 78);
            this.addfood.TabIndex = 13;
            this.addfood.Text = "Add Food";
            this.addfood.UseVisualStyleBackColor = true;
            this.addfood.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // listfoods
            // 
            this.listfoods.Enabled = false;
            this.listfoods.Location = new System.Drawing.Point(6, 90);
            this.listfoods.Name = "listfoods";
            this.listfoods.Size = new System.Drawing.Size(255, 78);
            this.listfoods.TabIndex = 14;
            this.listfoods.Text = "List Foods";
            this.listfoods.UseVisualStyleBackColor = true;
            this.listfoods.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(540, 199);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.add_client);
            this.tabPage1.Controls.Add(this.list_users);
            this.tabPage1.Controls.Add(this.assign_plan);
            this.tabPage1.Controls.Add(this.search_client);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(532, 173);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Clients";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.showplancontent);
            this.tabPage2.Controls.Add(this.listplans);
            this.tabPage2.Controls.Add(this.modifydietplan);
            this.tabPage2.Controls.Add(this.searchplan);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(532, 173);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Diet Plans";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.addfood);
            this.tabPage3.Controls.Add(this.listfoods);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(532, 173);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Foods";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(532, 173);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Workouts";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Controls.Add(this.button2);
            this.tabPage5.Controls.Add(this.toolStrip2);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(532, 173);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Exercises";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(255, 78);
            this.button1.TabIndex = 16;
            this.button1.Text = "Add Exercise";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_4);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(255, 78);
            this.button2.TabIndex = 17;
            this.button2.Text = "List Exercises";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_3);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripSeparator2,
            this.toolStripLabel2});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(526, 25);
            this.toolStrip2.TabIndex = 15;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(79, 22);
            this.toolStripLabel2.Text = "Please Log In!";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton2.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItem1.Text = "Login";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItem2.Text = "Change Password";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItem3.Text = "Logout";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(558, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(261, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click_1);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(255, 78);
            this.button3.TabIndex = 9;
            this.button3.Text = "Add/Modify Workout";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 89);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(255, 78);
            this.button4.TabIndex = 10;
            this.button4.Text = "Show Workout Content";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(267, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(255, 78);
            this.button5.TabIndex = 11;
            this.button5.Text = "List Workouts";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 237);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.Text = "LG Fitness - Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Button add_client;
        private System.Windows.Forms.Button assign_plan;
        private System.Windows.Forms.Button search_client;
        private System.Windows.Forms.Button list_users;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button modifydietplan;
        private System.Windows.Forms.Button searchplan;
        private System.Windows.Forms.Button listplans;
        private System.Windows.Forms.Button showplancontent;
        private System.Windows.Forms.Button addfood;
        private System.Windows.Forms.Button listfoods;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
    }
}

