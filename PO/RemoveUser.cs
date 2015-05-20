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
    ///  This class is the Form RemoveUser
    /// </summary>
    public partial class RemoveUser : Form
    {
        //u stores the current User's information
        private User u;

        /// <summary>
        ///  Constructor
        ///  
        ///  @param: User
        ///  @return: none
        /// </summary>
        public RemoveUser(User a)
        {
            InitializeComponent();

            //Stores the current User's information
            u = a;
        }

        /// <summary>
        ///  Event handler for AddUser Tool Strip Menu Item
        ///  
        ///  @param: object, Event Args
        ///  @return: none
        /// </summary>
        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a new Adduser Form
            Form n = new AddUser(u);
            
            //Close this Form
            this.Close();
            
            //Show the new AddUser Form
            n.Show();
        }

        /// <summary>
        ///  Event handler for ChangePassword Tool Strip Menu Item
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
        ///  Event handler for the Home Pic
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void HomePic_Click(object sender, EventArgs e)
        {
            //Make sure the User is an Admin
            if(u.isAdmin())
            {
                //Create a new AdminHomePage Form
                Form n = new AdminHomePage(u);
            
                //Close this Form
                this.Close();
            
                //Show the new AdminHomePage Form
                n.Show();
            }

            //
            else if(!u.isAdmin())
            {
                //Create a new StudentSearch Form
                Form n = new StudentSearch(new User());

                //Close this Form
                this.Close();

                //Show the new StudentSearch Form
                n.Show();
            }
        }

        /// <summary>
        ///  Event handler for the RemoveUser Form
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void RemoveUser_Load(object sender, EventArgs e)
        {
                try
                {
                    this.adminTableTableAdapter.FillByUsernameAll(this.pODBDataSet.AdminTable);
                    LoadComboBox();
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Error retrieving data.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        /// <summary>
        ///  Loads the ComboBox on the form based on
        ///  the information in teh adminTableDataGridView on the Form
        ///  
        ///  @param:
        ///  @return:
        /// </summary>
        private void LoadComboBox()
        {
            //L stores the List of items to be loaded into userComboBox
            List<String> L = new List<String>();

            //Loads L based on the information in adminTableDataGridView
            for (int j = 0; j < adminTableDataGridView.Rows.Count-1; j++)
            {
                L.Add(adminTableDataGridView.Rows[j].Cells[4].Value.ToString());
            }

            //Loads userComboBox based on the information in L
            foreach (String user in L)
                userComboBox.Items.Add(user);
        }

        /// <summary>
        ///  Event handler for the RemoveUser Button
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void removeuserbtn_Click(object sender, EventArgs e)
        {
            //s stores the information in userComboBox 
            String s = userComboBox.Text;

            //Makes sure you can't delete
            //the currently logged in person
            if(s == u.Username)
            {
                MessageBox.Show("Not possible to remove yourself.","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //if you are deleting someone that is not the currently
            //logged in person
            else
            {
                //perform the query
                try
                {
                    this.adminTableTableAdapter.DeleteQueryByUsername(s);
                    this.adminTableTableAdapter.Update(this.pODBDataSet.AdminTable);
                }
                catch(System.Exception)
                {
                    MessageBox.Show("Deletion failed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        ///  Event handler for the LogOut Tool Strip Menu Item
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create new StudentSearch Form
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
