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
    ///  This class is the AdminHomePage Form
    /// </summary>
    public partial class AdminHomePage : Form
    {
        //u stores the current User's information
        private User u;

        /// <summary>
        ///  Default constructor
        ///  
        ///  @param:
        ///  @return:
        /// </summary>
        public AdminHomePage(User a)
        {
            InitializeComponent();
            
            //Stores the current User's information to be used
            u = a;
        }

        /// <summary>
        ///  Event handler for the Student Search Button
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void adminSearchStudent_Click(object sender, EventArgs e)
        {
            //Create a new StudentSearch Form
            Form n = new StudentSearch(u);
            
            //Close this Form
            this.Close();
            
            //Show the new StudentSearch Form
            n.Show();
        }

        /// <summary>
        ///  Event handler for the Logout Button
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void adminLogOut_Click(object sender, EventArgs e)
        {
            //Create a new StudentSearch Form
            Form n = new StudentSearch(new User());
            
            //Close this Form
            this.Close();
            
            //Show the new StudentSearch Form
            n.Show();
        }

        /// <summary>
        ///  Event handler for the AddUser Button
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void adduserbtn_Click(object sender, EventArgs e)
        {
            //Create a new AddUser Form
            Form n = new AddUser(u);
            
            //Close this Form
            this.Close();
            
            //Show the new AddUser Form
            n.Show();
        }

        /// <summary>
        ///  Event handler for the ChangePassword Button
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void adminChangePswrd_Click(object sender, EventArgs e)
        {
            //Create a new ChangePassword Form
            Form n = new ChangePassword(u);
            
            //Close this Form
            this.Close();
            
            //Show the new ChangePassword Form
            n.Show();
        }

        /// <summary>
        ///  Event handler for RemoveUser Button
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void removeuserbtn_Click(object sender, EventArgs e)
        {
            //Create a new RemoveUser Form
            Form n = new RemoveUser(u);
            
            //Close this Form
            this.Close();
            
            //Show the new RemoveUser Form
            n.Show();
        }

        /// <summary>
        ///  Event handler for the AddStudent Button
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void addstudentButton_Click(object sender, EventArgs e)
        {
            //Create a new AddStudentAddress Form
            Form n = new AddStudentAddress(u, this); 
           
            //Hide this Form
            this.Hide();
            
            //Show the new AddStudentAddress Form
            n.Show();
        }


        /// <summary>
        ///  Event hanlder for the ExitApplication Tool Strip Menu Item
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
