using System.ComponentModel;
using System.Windows.Forms;

namespace UI
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblTitle = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelTotalMembers = new System.Windows.Forms.Panel();
            this.lblTotalMembers = new System.Windows.Forms.Label();
            this.iconTotalMembers = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelActiveMemberships = new System.Windows.Forms.Panel();
            this.lblActiveMemberships = new System.Windows.Forms.Label();
            this.iconActiveMemberships = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelExpiredMemberships = new System.Windows.Forms.Panel();
            this.lblExpiredMemberships = new System.Windows.Forms.Label();
            this.iconExpiredMemberships = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelTotalRevenue = new System.Windows.Forms.Panel();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.iconTotalRevenue = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelMonthlyRevenue = new System.Windows.Forms.Panel();
            this.chartMonthlyRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblMonthlyRevenueTitle = new System.Windows.Forms.Label();
            this.panelScrollableContainer = new System.Windows.Forms.Panel();
            this.panelRecentMembers = new System.Windows.Forms.Panel();
            this.dataGridRecentMembers = new System.Windows.Forms.DataGridView();
            this.lblRecentMembersTitle = new System.Windows.Forms.Label();
            this.panelUpcomingExpirations = new System.Windows.Forms.Panel();
            this.dataGridUpcomingExpirations = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblUpcomingExpirationsTitle = new System.Windows.Forms.Label();
            this.panelGenderDistribution = new System.Windows.Forms.Panel();
            this.chartGenderDistribution = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblGenderDistributionTitle = new System.Windows.Forms.Label();
            this.panelAgeDistribution = new System.Windows.Forms.Panel();
            this.chartAgeDistribution = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblAgeDistributionTitle = new System.Windows.Forms.Label();
            this.panelMembershipType = new System.Windows.Forms.Panel();
            this.chartMembershipType = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblMembershipTypeTitle = new System.Windows.Forms.Label();
            this.panelTotalMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconTotalMembers)).BeginInit();
            this.panelActiveMemberships.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconActiveMemberships)).BeginInit();
            this.panelExpiredMemberships.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconExpiredMemberships)).BeginInit();
            this.panelTotalRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconTotalRevenue)).BeginInit();
            this.panelMonthlyRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlyRevenue)).BeginInit();
            this.panelScrollableContainer.SuspendLayout();
            this.panelRecentMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecentMembers)).BeginInit();
            this.panelUpcomingExpirations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUpcomingExpirations)).BeginInit();
            this.panelGenderDistribution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGenderDistribution)).BeginInit();
            this.panelAgeDistribution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAgeDistribution)).BeginInit();
            this.panelMembershipType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMembershipType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(195, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.textBox1.Location = new System.Drawing.Point(744, 14);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Search for something...";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1051, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panelTotalMembers
            // 
            this.panelTotalMembers.AutoSize = true;
            this.panelTotalMembers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelTotalMembers.Controls.Add(this.lblTotalMembers);
            this.panelTotalMembers.Controls.Add(this.iconTotalMembers);
            this.panelTotalMembers.Controls.Add(this.label2);
            this.panelTotalMembers.Location = new System.Drawing.Point(12, 64);
            this.panelTotalMembers.Name = "panelTotalMembers";
            this.panelTotalMembers.Size = new System.Drawing.Size(219, 86);
            this.panelTotalMembers.TabIndex = 3;
            // 
            // lblTotalMembers
            // 
            this.lblTotalMembers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotalMembers.Font = new System.Drawing.Font("Nirmala UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMembers.ForeColor = System.Drawing.Color.White;
            this.lblTotalMembers.Location = new System.Drawing.Point(0, 32);
            this.lblTotalMembers.Margin = new System.Windows.Forms.Padding(10);
            this.lblTotalMembers.Name = "lblTotalMembers";
            this.lblTotalMembers.Size = new System.Drawing.Size(170, 54);
            this.lblTotalMembers.TabIndex = 2;
            this.lblTotalMembers.Text = "999999";
            // 
            // iconTotalMembers
            // 
            this.iconTotalMembers.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconTotalMembers.Image = ((System.Drawing.Image)(resources.GetObject("iconTotalMembers.Image")));
            this.iconTotalMembers.Location = new System.Drawing.Point(170, 32);
            this.iconTotalMembers.Name = "iconTotalMembers";
            this.iconTotalMembers.Size = new System.Drawing.Size(49, 54);
            this.iconTotalMembers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconTotalMembers.TabIndex = 1;
            this.iconTotalMembers.TabStop = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Members";
            // 
            // panelActiveMemberships
            // 
            this.panelActiveMemberships.AutoSize = true;
            this.panelActiveMemberships.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelActiveMemberships.Controls.Add(this.lblActiveMemberships);
            this.panelActiveMemberships.Controls.Add(this.iconActiveMemberships);
            this.panelActiveMemberships.Controls.Add(this.label4);
            this.panelActiveMemberships.Location = new System.Drawing.Point(262, 64);
            this.panelActiveMemberships.Name = "panelActiveMemberships";
            this.panelActiveMemberships.Size = new System.Drawing.Size(234, 86);
            this.panelActiveMemberships.TabIndex = 4;
            // 
            // lblActiveMemberships
            // 
            this.lblActiveMemberships.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblActiveMemberships.Font = new System.Drawing.Font("Nirmala UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveMemberships.ForeColor = System.Drawing.Color.White;
            this.lblActiveMemberships.Location = new System.Drawing.Point(0, 32);
            this.lblActiveMemberships.Margin = new System.Windows.Forms.Padding(10);
            this.lblActiveMemberships.Name = "lblActiveMemberships";
            this.lblActiveMemberships.Size = new System.Drawing.Size(185, 54);
            this.lblActiveMemberships.TabIndex = 2;
            this.lblActiveMemberships.Text = "  200";
            // 
            // iconActiveMemberships
            // 
            this.iconActiveMemberships.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconActiveMemberships.Image = ((System.Drawing.Image)(resources.GetObject("iconActiveMemberships.Image")));
            this.iconActiveMemberships.Location = new System.Drawing.Point(185, 31);
            this.iconActiveMemberships.Name = "iconActiveMemberships";
            this.iconActiveMemberships.Size = new System.Drawing.Size(49, 55);
            this.iconActiveMemberships.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconActiveMemberships.TabIndex = 1;
            this.iconActiveMemberships.TabStop = false;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "Active Memberships";
            // 
            // panelExpiredMemberships
            // 
            this.panelExpiredMemberships.AutoSize = true;
            this.panelExpiredMemberships.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelExpiredMemberships.Controls.Add(this.lblExpiredMemberships);
            this.panelExpiredMemberships.Controls.Add(this.iconExpiredMemberships);
            this.panelExpiredMemberships.Controls.Add(this.label6);
            this.panelExpiredMemberships.Location = new System.Drawing.Point(529, 64);
            this.panelExpiredMemberships.Name = "panelExpiredMemberships";
            this.panelExpiredMemberships.Size = new System.Drawing.Size(264, 86);
            this.panelExpiredMemberships.TabIndex = 5;
            // 
            // lblExpiredMemberships
            // 
            this.lblExpiredMemberships.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblExpiredMemberships.Font = new System.Drawing.Font("Nirmala UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpiredMemberships.ForeColor = System.Drawing.Color.White;
            this.lblExpiredMemberships.Location = new System.Drawing.Point(0, 32);
            this.lblExpiredMemberships.Margin = new System.Windows.Forms.Padding(10);
            this.lblExpiredMemberships.Name = "lblExpiredMemberships";
            this.lblExpiredMemberships.Size = new System.Drawing.Size(215, 54);
            this.lblExpiredMemberships.TabIndex = 2;
            this.lblExpiredMemberships.Text = "  100";
            // 
            // iconExpiredMemberships
            // 
            this.iconExpiredMemberships.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconExpiredMemberships.Image = ((System.Drawing.Image)(resources.GetObject("iconExpiredMemberships.Image")));
            this.iconExpiredMemberships.Location = new System.Drawing.Point(215, 31);
            this.iconExpiredMemberships.Name = "iconExpiredMemberships";
            this.iconExpiredMemberships.Size = new System.Drawing.Size(49, 55);
            this.iconExpiredMemberships.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconExpiredMemberships.TabIndex = 1;
            this.iconExpiredMemberships.TabStop = false;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(264, 31);
            this.label6.TabIndex = 0;
            this.label6.Text = "Expired Memberships";
            // 
            // panelTotalRevenue
            // 
            this.panelTotalRevenue.AutoSize = true;
            this.panelTotalRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelTotalRevenue.Controls.Add(this.lblTotalRevenue);
            this.panelTotalRevenue.Controls.Add(this.iconTotalRevenue);
            this.panelTotalRevenue.Controls.Add(this.label8);
            this.panelTotalRevenue.Location = new System.Drawing.Point(825, 64);
            this.panelTotalRevenue.Name = "panelTotalRevenue";
            this.panelTotalRevenue.Size = new System.Drawing.Size(247, 103);
            this.panelTotalRevenue.TabIndex = 6;
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Nirmala UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.White;
            this.lblTotalRevenue.Location = new System.Drawing.Point(0, 31);
            this.lblTotalRevenue.Margin = new System.Windows.Forms.Padding(10);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(168, 72);
            this.lblTotalRevenue.TabIndex = 2;
            this.lblTotalRevenue.Text = "99,999";
            // 
            // iconTotalRevenue
            // 
            this.iconTotalRevenue.Image = ((System.Drawing.Image)(resources.GetObject("iconTotalRevenue.Image")));
            this.iconTotalRevenue.Location = new System.Drawing.Point(168, 33);
            this.iconTotalRevenue.Name = "iconTotalRevenue";
            this.iconTotalRevenue.Size = new System.Drawing.Size(76, 65);
            this.iconTotalRevenue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconTotalRevenue.TabIndex = 1;
            this.iconTotalRevenue.TabStop = false;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(247, 31);
            this.label8.TabIndex = 0;
            this.label8.Text = "Total Revenue";
            // 
            // panelMonthlyRevenue
            // 
            this.panelMonthlyRevenue.AutoSize = true;
            this.panelMonthlyRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelMonthlyRevenue.Controls.Add(this.chartMonthlyRevenue);
            this.panelMonthlyRevenue.Controls.Add(this.lblMonthlyRevenueTitle);
            this.panelMonthlyRevenue.Location = new System.Drawing.Point(12, 182);
            this.panelMonthlyRevenue.Name = "panelMonthlyRevenue";
            this.panelMonthlyRevenue.Size = new System.Drawing.Size(1064, 268);
            this.panelMonthlyRevenue.TabIndex = 7;
            // 
            // chartMonthlyRevenue
            // 
            this.chartMonthlyRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.Gray;
            this.chartMonthlyRevenue.ChartAreas.Add(chartArea1);
            this.chartMonthlyRevenue.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend1.Name = "Legend1";
            this.chartMonthlyRevenue.Legends.Add(legend1);
            this.chartMonthlyRevenue.Location = new System.Drawing.Point(0, 34);
            this.chartMonthlyRevenue.Name = "chartMonthlyRevenue";
            this.chartMonthlyRevenue.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.LabelBackColor = System.Drawing.Color.White;
            series1.LabelBorderColor = System.Drawing.Color.White;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartMonthlyRevenue.Series.Add(series1);
            this.chartMonthlyRevenue.Size = new System.Drawing.Size(1064, 234);
            this.chartMonthlyRevenue.TabIndex = 1;
            this.chartMonthlyRevenue.Text = "chart1";
            // 
            // lblMonthlyRevenueTitle
            // 
            this.lblMonthlyRevenueTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMonthlyRevenueTitle.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthlyRevenueTitle.ForeColor = System.Drawing.Color.White;
            this.lblMonthlyRevenueTitle.Location = new System.Drawing.Point(0, 0);
            this.lblMonthlyRevenueTitle.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblMonthlyRevenueTitle.Name = "lblMonthlyRevenueTitle";
            this.lblMonthlyRevenueTitle.Size = new System.Drawing.Size(1064, 31);
            this.lblMonthlyRevenueTitle.TabIndex = 0;
            this.lblMonthlyRevenueTitle.Text = "Monthly Revenue";
            // 
            // panelScrollableContainer
            // 
            this.panelScrollableContainer.AutoScroll = true;
            this.panelScrollableContainer.Controls.Add(this.panelRecentMembers);
            this.panelScrollableContainer.Controls.Add(this.button1);
            this.panelScrollableContainer.Controls.Add(this.panelUpcomingExpirations);
            this.panelScrollableContainer.Controls.Add(this.textBox1);
            this.panelScrollableContainer.Controls.Add(this.panelGenderDistribution);
            this.panelScrollableContainer.Controls.Add(this.lblTitle);
            this.panelScrollableContainer.Controls.Add(this.panelAgeDistribution);
            this.panelScrollableContainer.Controls.Add(this.panelMembershipType);
            this.panelScrollableContainer.Controls.Add(this.panelMonthlyRevenue);
            this.panelScrollableContainer.Controls.Add(this.panelTotalRevenue);
            this.panelScrollableContainer.Controls.Add(this.panelExpiredMemberships);
            this.panelScrollableContainer.Controls.Add(this.panelActiveMemberships);
            this.panelScrollableContainer.Controls.Add(this.panelTotalMembers);
            this.panelScrollableContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScrollableContainer.Location = new System.Drawing.Point(0, 0);
            this.panelScrollableContainer.Name = "panelScrollableContainer";
            this.panelScrollableContainer.Size = new System.Drawing.Size(1100, 748);
            this.panelScrollableContainer.TabIndex = 8;
            // 
            // panelRecentMembers
            // 
            this.panelRecentMembers.AutoSize = true;
            this.panelRecentMembers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelRecentMembers.Controls.Add(this.dataGridRecentMembers);
            this.panelRecentMembers.Controls.Add(this.lblRecentMembersTitle);
            this.panelRecentMembers.Location = new System.Drawing.Point(562, 739);
            this.panelRecentMembers.Name = "panelRecentMembers";
            this.panelRecentMembers.Size = new System.Drawing.Size(444, 268);
            this.panelRecentMembers.TabIndex = 12;
            // 
            // dataGridRecentMembers
            // 
            this.dataGridRecentMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRecentMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridRecentMembers.Location = new System.Drawing.Point(0, 31);
            this.dataGridRecentMembers.Name = "dataGridRecentMembers";
            this.dataGridRecentMembers.RowTemplate.Height = 24;
            this.dataGridRecentMembers.Size = new System.Drawing.Size(444, 237);
            this.dataGridRecentMembers.TabIndex = 1;
            // 
            // lblRecentMembersTitle
            // 
            this.lblRecentMembersTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRecentMembersTitle.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentMembersTitle.ForeColor = System.Drawing.Color.White;
            this.lblRecentMembersTitle.Location = new System.Drawing.Point(0, 0);
            this.lblRecentMembersTitle.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblRecentMembersTitle.Name = "lblRecentMembersTitle";
            this.lblRecentMembersTitle.Size = new System.Drawing.Size(444, 31);
            this.lblRecentMembersTitle.TabIndex = 0;
            this.lblRecentMembersTitle.Text = "Recent Members";
            // 
            // panelUpcomingExpirations
            // 
            this.panelUpcomingExpirations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelUpcomingExpirations.Controls.Add(this.dataGridUpcomingExpirations);
            this.panelUpcomingExpirations.Controls.Add(this.lblUpcomingExpirationsTitle);
            this.panelUpcomingExpirations.Location = new System.Drawing.Point(44, 739);
            this.panelUpcomingExpirations.Name = "panelUpcomingExpirations";
            this.panelUpcomingExpirations.Size = new System.Drawing.Size(444, 268);
            this.panelUpcomingExpirations.TabIndex = 11;
            // 
            // dataGridUpcomingExpirations
            // 
            this.dataGridUpcomingExpirations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUpcomingExpirations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn4 });
            this.dataGridUpcomingExpirations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridUpcomingExpirations.Location = new System.Drawing.Point(0, 31);
            this.dataGridUpcomingExpirations.Name = "dataGridUpcomingExpirations";
            this.dataGridUpcomingExpirations.RowTemplate.Height = 24;
            this.dataGridUpcomingExpirations.Size = new System.Drawing.Size(444, 237);
            this.dataGridUpcomingExpirations.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Member ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Membership Type";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Expiration Date";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // lblUpcomingExpirationsTitle
            // 
            this.lblUpcomingExpirationsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUpcomingExpirationsTitle.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcomingExpirationsTitle.ForeColor = System.Drawing.Color.White;
            this.lblUpcomingExpirationsTitle.Location = new System.Drawing.Point(0, 0);
            this.lblUpcomingExpirationsTitle.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblUpcomingExpirationsTitle.Name = "lblUpcomingExpirationsTitle";
            this.lblUpcomingExpirationsTitle.Size = new System.Drawing.Size(444, 31);
            this.lblUpcomingExpirationsTitle.TabIndex = 0;
            this.lblUpcomingExpirationsTitle.Text = "Upcoming Membership Expirations";
            // 
            // panelGenderDistribution
            // 
            this.panelGenderDistribution.AutoSize = true;
            this.panelGenderDistribution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelGenderDistribution.Controls.Add(this.chartGenderDistribution);
            this.panelGenderDistribution.Controls.Add(this.lblGenderDistributionTitle);
            this.panelGenderDistribution.Location = new System.Drawing.Point(758, 457);
            this.panelGenderDistribution.Name = "panelGenderDistribution";
            this.panelGenderDistribution.Size = new System.Drawing.Size(318, 265);
            this.panelGenderDistribution.TabIndex = 10;
            // 
            // chartGenderDistribution
            // 
            this.chartGenderDistribution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            chartArea2.Name = "ChartArea1";
            chartArea2.ShadowColor = System.Drawing.Color.Gray;
            this.chartGenderDistribution.ChartAreas.Add(chartArea2);
            this.chartGenderDistribution.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend2.Name = "Legend1";
            this.chartGenderDistribution.Legends.Add(legend2);
            this.chartGenderDistribution.Location = new System.Drawing.Point(0, 31);
            this.chartGenderDistribution.Name = "chartGenderDistribution";
            this.chartGenderDistribution.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.LabelBackColor = System.Drawing.Color.White;
            series2.LabelBorderColor = System.Drawing.Color.White;
            series2.LabelForeColor = System.Drawing.Color.White;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValuesPerPoint = 6;
            this.chartGenderDistribution.Series.Add(series2);
            this.chartGenderDistribution.Size = new System.Drawing.Size(318, 234);
            this.chartGenderDistribution.TabIndex = 1;
            this.chartGenderDistribution.Text = "chart3";
            // 
            // lblGenderDistributionTitle
            // 
            this.lblGenderDistributionTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGenderDistributionTitle.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenderDistributionTitle.ForeColor = System.Drawing.Color.White;
            this.lblGenderDistributionTitle.Location = new System.Drawing.Point(0, 0);
            this.lblGenderDistributionTitle.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblGenderDistributionTitle.Name = "lblGenderDistributionTitle";
            this.lblGenderDistributionTitle.Size = new System.Drawing.Size(318, 31);
            this.lblGenderDistributionTitle.TabIndex = 0;
            this.lblGenderDistributionTitle.Text = "Gender Distribution";
            // 
            // panelAgeDistribution
            // 
            this.panelAgeDistribution.AutoSize = true;
            this.panelAgeDistribution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelAgeDistribution.Controls.Add(this.chartAgeDistribution);
            this.panelAgeDistribution.Controls.Add(this.lblAgeDistributionTitle);
            this.panelAgeDistribution.Location = new System.Drawing.Point(44, 457);
            this.panelAgeDistribution.Name = "panelAgeDistribution";
            this.panelAgeDistribution.Size = new System.Drawing.Size(318, 265);
            this.panelAgeDistribution.TabIndex = 9;
            // 
            // chartAgeDistribution
            // 
            this.chartAgeDistribution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            chartArea3.Area3DStyle.Enable3D = true;
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea3.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            chartArea3.Name = "ChartArea1";
            chartArea3.ShadowColor = System.Drawing.Color.Gray;
            this.chartAgeDistribution.ChartAreas.Add(chartArea3);
            this.chartAgeDistribution.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend3.Name = "Legend1";
            this.chartAgeDistribution.Legends.Add(legend3);
            this.chartAgeDistribution.Location = new System.Drawing.Point(0, 31);
            this.chartAgeDistribution.Name = "chartAgeDistribution";
            this.chartAgeDistribution.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.LabelBackColor = System.Drawing.Color.White;
            series3.LabelBorderColor = System.Drawing.Color.White;
            series3.LabelForeColor = System.Drawing.Color.White;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.YValuesPerPoint = 6;
            this.chartAgeDistribution.Series.Add(series3);
            this.chartAgeDistribution.Size = new System.Drawing.Size(318, 234);
            this.chartAgeDistribution.TabIndex = 1;
            this.chartAgeDistribution.Text = "chart3";
            // 
            // lblAgeDistributionTitle
            // 
            this.lblAgeDistributionTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAgeDistributionTitle.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgeDistributionTitle.ForeColor = System.Drawing.Color.White;
            this.lblAgeDistributionTitle.Location = new System.Drawing.Point(0, 0);
            this.lblAgeDistributionTitle.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblAgeDistributionTitle.Name = "lblAgeDistributionTitle";
            this.lblAgeDistributionTitle.Size = new System.Drawing.Size(318, 31);
            this.lblAgeDistributionTitle.TabIndex = 0;
            this.lblAgeDistributionTitle.Text = "Age Group Distribution";
            // 
            // panelMembershipType
            // 
            this.panelMembershipType.AutoSize = true;
            this.panelMembershipType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelMembershipType.Controls.Add(this.chartMembershipType);
            this.panelMembershipType.Controls.Add(this.lblMembershipTypeTitle);
            this.panelMembershipType.Location = new System.Drawing.Point(399, 457);
            this.panelMembershipType.Name = "panelMembershipType";
            this.panelMembershipType.Size = new System.Drawing.Size(318, 265);
            this.panelMembershipType.TabIndex = 8;
            // 
            // chartMembershipType
            // 
            this.chartMembershipType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            chartArea4.Area3DStyle.Enable3D = true;
            chartArea4.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea4.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea4.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea4.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea4.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            chartArea4.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            chartArea4.Name = "ChartArea1";
            chartArea4.ShadowColor = System.Drawing.Color.Gray;
            this.chartMembershipType.ChartAreas.Add(chartArea4);
            this.chartMembershipType.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend4.Name = "Legend1";
            this.chartMembershipType.Legends.Add(legend4);
            this.chartMembershipType.Location = new System.Drawing.Point(0, 31);
            this.chartMembershipType.Name = "chartMembershipType";
            this.chartMembershipType.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.LabelBackColor = System.Drawing.Color.White;
            series4.LabelBorderColor = System.Drawing.Color.White;
            series4.LabelForeColor = System.Drawing.Color.White;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartMembershipType.Series.Add(series4);
            this.chartMembershipType.Size = new System.Drawing.Size(318, 234);
            this.chartMembershipType.TabIndex = 1;
            this.chartMembershipType.Text = "chart2";
            // 
            // lblMembershipTypeTitle
            // 
            this.lblMembershipTypeTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMembershipTypeTitle.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembershipTypeTitle.ForeColor = System.Drawing.Color.White;
            this.lblMembershipTypeTitle.Location = new System.Drawing.Point(0, 0);
            this.lblMembershipTypeTitle.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblMembershipTypeTitle.Name = "lblMembershipTypeTitle";
            this.lblMembershipTypeTitle.Size = new System.Drawing.Size(318, 31);
            this.lblMembershipTypeTitle.TabIndex = 0;
            this.lblMembershipTypeTitle.Text = "Membership Type Distribution";
            // 
            // DashboardForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1100, 748);
            this.Controls.Add(this.panelScrollableContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardForm";
            this.panelTotalMembers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconTotalMembers)).EndInit();
            this.panelActiveMemberships.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconActiveMemberships)).EndInit();
            this.panelExpiredMemberships.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconExpiredMemberships)).EndInit();
            this.panelTotalRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconTotalRevenue)).EndInit();
            this.panelMonthlyRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlyRevenue)).EndInit();
            this.panelScrollableContainer.ResumeLayout(false);
            this.panelScrollableContainer.PerformLayout();
            this.panelRecentMembers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecentMembers)).EndInit();
            this.panelUpcomingExpirations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUpcomingExpirations)).EndInit();
            this.panelGenderDistribution.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartGenderDistribution)).EndInit();
            this.panelAgeDistribution.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAgeDistribution)).EndInit();
            this.panelMembershipType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMembershipType)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelRecentMembers;
        private System.Windows.Forms.DataGridView dataGridRecentMembers;
        private System.Windows.Forms.Label lblRecentMembersTitle;

        private System.Windows.Forms.DataGridView dataGridUpcomingExpirations;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

        private System.Windows.Forms.Panel panelUpcomingExpirations;
        private System.Windows.Forms.Label lblUpcomingExpirationsTitle;

        private System.Windows.Forms.Panel panelGenderDistribution;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGenderDistribution;
        private System.Windows.Forms.Label lblGenderDistributionTitle;

        private System.Windows.Forms.Panel panelMonthlyRevenue;

        private System.Windows.Forms.Panel panelAgeDistribution;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAgeDistribution;
        private System.Windows.Forms.Label lblAgeDistributionTitle;

        private System.Windows.Forms.Panel panelMembershipType;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMembershipType;
        private System.Windows.Forms.Label lblMembershipTypeTitle;

        private System.Windows.Forms.Panel panelScrollableContainer;

        private System.Windows.Forms.Label lblMonthlyRevenueTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMonthlyRevenue;

        private System.Windows.Forms.Panel panelTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.PictureBox iconTotalRevenue;
        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Panel panelExpiredMemberships;
        private System.Windows.Forms.Label lblExpiredMemberships;
        private System.Windows.Forms.PictureBox iconExpiredMemberships;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Panel panelActiveMemberships;
        private System.Windows.Forms.Label lblActiveMemberships;
        private System.Windows.Forms.PictureBox iconActiveMemberships;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label lblTotalMembers;

        private System.Windows.Forms.PictureBox iconTotalMembers;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Panel panelTotalMembers;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.Label lblTitle;

        #endregion
    }
}