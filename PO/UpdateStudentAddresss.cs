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
    ///  This class is the Form UpdateStudentAddress
    /// </summary>
    public partial class UpdateStudentAddress : Form
    {
        //newP holds the values of the new student.
        private Student newP;

        //last holds the last form that was up
        //so that the user can return to it.
        private Form last;

        //u holds the current user's information
        private User u;

        /// <summary>
        ///  Constructor.
        ///  
        ///  @param: Student, Form, User
        ///  @return: none
        /// </summary>
        public UpdateStudentAddress(Student s, Form f, User a)
        {
            InitializeComponent();

            //save the information passed in
            newP = s;
            last = f;
            u = a;

            //call the initialization method
            init(s);
        }

        /// <summary>
        ///  Event handler for the Update Button
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void updateButton_Click(object sender, EventArgs e)
        {
            //Get the result of the button click on the MessageBox
            DialogResult result = MessageBox.Show("Are you sure you entered the data right and wish to update?", "Continue?",
                MessageBoxButtons.YesNo);

            //If the user clicks the "Yes" button
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Set newP member data with the corresponding TextBox data
                newP.FName = fnameTextBox.Text;
                newP.MidName = mnameTextBox.Text;
                newP.LName = lnameTextBox.Text;
                newP.Email = emailTextBox.Text;
                newP.MNum = mnumTextBox.Text;
                newP.MStAddress = msuaddressTextBox.Text;
                newP.MCity = "Wichita Falls";
                newP.MState = "TX";
                newP.MZip = "76308";
                newP.NStAddress = newaddressTextBox.Text;
                newP.NCity = newcityTextBox.Text;
                newP.NState = newstateTextBox.Text;
                newP.NZip = newzipTextBox.Text;
                newP.NCountry = newcountryTextBox.Text;
                
                //Close the last from the user was in
                last.Close();

                //Create a new StudentSearch Form
                Form n = new StudentSearch(u, newP);

                //Close this Form
                this.Close();

                //Show the new StudentSearch Form
                n.Show();
                
            }
        }

        /// <summary>
        ///  Event handler for the Home Picture
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void HomePic_Click(object sender, EventArgs e)
        {
            //Close the last Form
            last.Close();

            //Create a new AdminHomePage Form
            Form n = new AdminHomePage(u);
            
            //Close this Form
            this.Close();
            
            //Show the new AdminHomePage Form
            n.Show();
        }

        /// <summary>
        ///  Event handler for the Cancel Button
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            //Show the last Form
            last.Show();
            //Close this Form
            this.Close();
        }

        /// <summary>
        ///  Event handler for the Radio Buttons
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void radiobuttons_CheckedChanged(object sender, EventArgs e)
        {
            //If the sundanceRadioButton is checked
            //set the msuaddressTextBox text to "2602 Midwestern Pkwy"
            if (sundanceRadioButton.Checked == true)
            {
                msuaddressTextBox.Text = "2602 Midwestern Pkwy";
            }

            //If the sunwatcherRadioButton is checked
            //set the msuaddressTextBox text to "3704 Louis J. Rodriguez"
            else if (sunwatcherRadioButton.Checked == true)
            {
                msuaddressTextBox.Text = "3704 Louis J. Rodriguez";
            }

            //If the poboxRadioButton is checked
            //set the msuaddressTextBox text to "3410 Taft Blvd"
            else if (poboxRadioButton.Checked == true)
            {
                msuaddressTextBox.Text = "3410 Taft Blvd";
            }

            //If the otherRadioButton is checked
            //reset the msuaddressTextBox text to empty
            else if (otherRadioButton.Checked == true)
            {
                msuaddressTextBox.Text = "";
            }

        }

        /// <summary>
        ///  Initializes the Form with the Student's information
        ///  
        ///  @param: Student
        ///  @return: none
        /// </summary>
        private void init(Student s)
        {
            //fill the textboxes on screen
            fnameTextBox.Text = s.FName;
            mnameTextBox.Text = s.MidName;
            lnameTextBox.Text = s.LName;
            emailTextBox.Text = s.Email;
            mnumTextBox.Text = s.MNum;
            msuaddressTextBox.Text = s.MStAddress;
            aptmailTextBox.Text = s.Aptmb;
            newaddressTextBox.Text = s.NStAddress;
            newcityTextBox.Text = s.NCity;
            newstateTextBox.Text = s.NState;
            newzipTextBox.Text = s.NZip;
            newcountryTextBox.Text = s.NCountry;

            //if they lived in sundance
            if (s.MStAddress == "2602 Midwestern Pkwy")
            {
                sundanceRadioButton.Checked = true;
            }

            //if they lived in sunwatcher
            else if (s.MStAddress == "3704 Louis J. Rodriguez")
            {
                sunwatcherRadioButton.Checked = true;
            }

            //if they have a PO Box
            else if (s.MStAddress == "3410 Taft Blvd")
            {
                poboxRadioButton.Checked = true;
            }

            //if they live at "Other"
            else
            {
                otherRadioButton.Checked = true;
            }
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
        ///  Event Handler for the ChangePassword Tool Strip Menu Item
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
        ///  Event Handler for the LogOut Tool Strip Menu Item
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a new StudentSearch Form
            //Giving it a User that is not an admin
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

            //Show new StudentSearch Form
            n.Show();
        }

        /// <summary>
        ///  Event Handler for the Add Tool Strip Menu Item
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
