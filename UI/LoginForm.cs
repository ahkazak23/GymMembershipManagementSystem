using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using BLL.Managers;

namespace UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.White;
            panel3.BackColor = Color.White;
            txtPassword.BackColor = SystemColors.Control;
            panel4.BackColor = SystemColors.Control;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            panel4.BackColor = Color.White;
            txtUsername.BackColor = SystemColors.Control;;
            panel3.BackColor = SystemColors.Control;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try 
            {
                AdminManager adminManager = new AdminManager();
                bool isAdmin = adminManager.LoginAdmin(username, password);

                if (isAdmin)
                {
                    lblFeedback.Text = $"Welcome {username}";
                    pnlFeedback.Visible = true; 
                    transitionTimer.Start();
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void transitionTimer_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.05;

            if (this.Opacity == 0)
            {
                transitionTimer.Stop();
                this.Hide();
                MemberManagementForm memberManagementForm = new MemberManagementForm();
                memberManagementForm.Show();
            }
            
        }
    }
}
