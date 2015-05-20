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
    ///  This class is the AddUser Form
    /// </summary>
    public partial class AddUser : Form
    {
        //u stores the current User's information
        private User u;

        /// <summary>
        ///  Default constructor
        ///  
        ///  @param: none
        ///  @return: none
        /// </summary>
        public AddUser(User a)
        {
            InitializeComponent();

            //Stores the passed in User for use in the Form
            u = a;
        }

        /// <summary>
        ///  Event handler for the HomePic
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
            
            //Show the new AdminHomePage
            n.Show();
        }

        /// <summary>
        ///  Event handler for the ChangePassword Tool Strip Menu Item
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void changepwdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a new ChangePassword Form
            Form n = new ChangePassword(u);
            
            //Close this Form
            this.Close();
            
            //Show the new ChangePassword Form
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
        ///  Event Handler for the Search Tool Strip Menu Item
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
            
            //Show the new StudentSearch Form
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
        ///  Event handler for the AddUser Load Event
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void AddUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pODBDataSet.AdminTable' table. You can move, or remove it, as needed.
            try
            {
                this.adminTableTableAdapter.FillByUsernameAll(this.pODBDataSet.AdminTable);
            }
            catch(System.Exception)
            {
                MessageBox.Show("Database error.","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  Event handler for the AddUser Button
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void adduserbtn_Click(object sender, EventArgs e)
        {
            //If any of the TextBoxes are empty
            if(firsttxt.Text == "" || lasttxt.Text == "" || emailtxt.Text == "" || usernametxt.Text == "" || pwdtxt.Text == "" || confirmtxt.Text == "")
            {
                MessageBox.Show("Please do not leave any fields blank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //If the passwords match
            else if (pwdtxt.Text == confirmtxt.Text)
            {
                //Add a record into the Database
                try
                {
                    this.adminTableTableAdapter.InsertQuery(firsttxt.Text, lasttxt.Text, emailtxt.Text, pwdtxt.Text, usernametxt.Text);
                    this.adminTableTableAdapter.Update(this.pODBDataSet.AdminTable);
                    Form f = new AdminHomePage(u);
                    f.Show();
                    this.Close();
                }
                catch (System.Data.OleDb.OleDbException)
                {
                    MessageBox.Show("There already exists a user with that username. Please choose another.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    usernametxt.Text = "";
                }
                catch(System.Exception)
                {
                    MessageBox.Show("Insertion error.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
                MessageBox.Show("The passwords entered are not the same" + System.Environment.NewLine + "Please"
                    + " re-enter them.", "Password match error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //Show th enew AddStudentAddress Form
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
