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
using System.Data.OleDb;
namespace PO
{       
    /// <summary>
    ///  This class is the ChangePassword Form
    /// </summary>
    public partial class ChangePassword : Form
    {
        //u stores the current User's information
        private User u;

        /// <summary>
        ///  Constructor
        ///  
        ///  @param: User
        ///  @return: none
        /// </summary>
        public ChangePassword(User a)
        {
            InitializeComponent();

            //Saves the current User's information into u
            u = a;
        }

        /// <summary>
        ///  Event Handler for the HomePic
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void HomePic_Click(object sender, EventArgs e)
        {
            //Create a new AdminHomePage Form
            Form n = new AdminHomePage(u);
            
            //Close this Form
            this.Close();
            
            //Shwo the new AdminHomePage Form
            n.Show();
        }

        /// <summary>
        ///  Event handler for the ChangePassword Button
        ///  
        ///  @param:
        ///  @return:
        /// </summary>
        private void changepwdbtn_Click(object sender, EventArgs e)
        {
            //If any of the TextBoxes are blank, an update cannot be performed
            if (currentpwdtxt.Text == "" || newpwdtxt.Text == "" || confirmpwdtxt.Text == "")
            {
                MessageBox.Show("Please do not leave any fields blank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            //If the new password and the confirmation password are not the same
            //can't update. Gotta make sure the User knows exactly what is being input
            else if (newpwdtxt.Text != confirmpwdtxt.Text)
            {
                MessageBox.Show("The passwords entered don't match. Please re-enter them.", "Password Match Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Fill adminTableDataGridView based on Username, and Current Password
            try
            {
                this.adminTableTableAdapter.FillByUsernamePwd(this.pODBDataSet.AdminTable, u.Username, currentpwdtxt.Text);
            }
            catch(System.Exception)
            {
                MessageBox.Show("Database error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //If there is not exactly one entry in the Database, the User entered incorrect data
            if (adminTableDataGridView.Rows.Count - 1 != 1)
            {
                MessageBox.Show("The information you entered is not correct. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //If the User entered correct data
            else
            {
                //Update the User's information in the Database
                try
                {
                    this.adminTableTableAdapter.UpdateQuery(newpwdtxt.Text, u.Username);
                    this.adminTableTableAdapter.Update(this.pODBDataSet.AdminTable);
                } 
                catch(System.Exception)
                {
                    MessageBox.Show("Update failed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        /// <summary>
        ///  Event handler for the Changepassword Load Event
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void ChangePassword_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pODBDataSet.AdminTable' table. You can move, or remove it, as needed.
            //this.adminTableTableAdapter.Fill(this.pODBDataSet.AdminTable);

        }

        /// <summary>
        ///  Event handler for the AddUser Tool Strip Menu Item
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a new AddUser Form
            Form n = new AddUser(u);
            
            //Close this Form
            this.Close();
            
            //Show the new AddUser Form
            n.Show();
        }

        /// <summary>
        ///  Event handler for the Search Tool Strip Menu Item
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a new StudentSearch Form
            Form n = new StudentSearch(u);
            
            //Close this Form
            this.Close();
            
            //Shwo the new StudentSearch Form
            n.Show();
        }

        /// <summary>
        ///  Event handler for the LogOut Tool Strip Menu Item
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a new StudentSearch Form
            Form n = new StudentSearch(new User());
            
            //Close this Form
            this.Close();
            
            //Show the new StudentSearch Form
            n.Show();
            
        }

        /// <summary>
        ///  Event handler for the Add Tool Strip Menu Item
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a new AddStudentAddress Form
            Form n = new AddStudentAddress(u, this);
            
            //Hide this Form
            this.Hide();
            
            //Show the new AddStudentAddress Form
            n.Show();
            
        }

        /// <summary>
        ///  Event handler for the RemoveUser Tool Strip Menu Item
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void removeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a new RemoveUser Form
            Form n = new RemoveUser(u);
            
            //Close this Form
            this.Close();
            
            //Show the new RemoveUser Form
            n.Show();
        }

        /// <summary>
        ///  Event handler for the Exit Tool Strip Menu Item
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
