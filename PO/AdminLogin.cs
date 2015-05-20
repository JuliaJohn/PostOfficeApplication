/*
 * Michael Whitley  
 * 5/3/2015
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PO
{
    /// <summary>
    ///  This class is AdminLogin Form
    /// </summary>
    public partial class AdminLogin : Form
    {
        //username stores the username entered by the User
        private String username;
        
        //pwd stores the password entered by the User
        private String pwd;
        Form f;
        //f stores the for that was last shown

        /// <summary>
        ///  Default constructor
        ///  
        ///  @param:
        ///  @return:
        /// </summary>
        public AdminLogin()
        {
            InitializeComponent();
            username = "";
            pwd = "";
        }

        /// <summary>
        ///  Event handler for the Home Picture Box
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Create a new StudentSearch Form
            Form n = new StudentSearch(new User());

            //Close this Form
            this.Close();

            //Show the new StudentSearch Form
            n.Show();
        }

        /// <summary>
        ///  Event Handler for the AdminLogin Button
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void adminLogInButton_Click(object sender, EventArgs e)
        {
            //first off, handle the possibility that the username/password
            //fields could be blank. totally possible
            if (txtUsername.Text == "")
            {
                MessageBox.Show("You can't leave the Username field blank! Put something in there!", "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            if (txtPassword.Text == "")
            {
                MessageBox.Show("We don't allow empty passwords! Please enter your password.", "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            else
            {
                //store the information on the form
                username = txtUsername.Text;
                pwd = txtPassword.Text;

                //2 possible things
                //Login correct
                //login incorrect

                adminTableTableAdapter.FillByUsernamePwd(this.pODBDataSet.AdminTable, username, pwd);
                dataGridView1.Invalidate();
                dataGridView1.Refresh();

                //If there is only one row in dataGridView
                //Meaning Login correct
                if (dataGridView1.Rows.Count - 1 == 1)
                {
                    //Get the information from dataGridView
                    int selected = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow d = dataGridView1.Rows[selected];
                    String fn = Convert.ToString(d.Cells[0].Value);
                    String ln = Convert.ToString(d.Cells[1].Value);
                    String un = Convert.ToString(d.Cells[4].Value);

                    //Create a new AdminHomePage Form
                    Form n = new AdminHomePage(new Admin(fn, ln, un));

                    //Close this Form
                    this.Close();

                    //Show the new AdminHomePage
                    n.Show();
                }

                //If the login is not successful
                else
                {
                    MessageBox.Show("Incorrect username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        ///  Event handler for the AdminLogin Form Load Event
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void AdminLogin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pODBDataSet.AdminTable' table. You can move, or remove it, as needed.
            //this.adminTableTableAdapter1.Fill(this.pODBDataSet.AdminTable);

        }

        /// <summary>
        ///  Event handler for the LoginHelp Link
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void LoginHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form n = new ForgotPassword();
            n.Show();
        }

    }
}
