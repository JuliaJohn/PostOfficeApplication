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
    ///  This class is AddStudentAddress Form
    /// </summary>
    public partial class AddStudentAddress : Form
    {
        //last stores the last Form that was visited
        private Form last;
        
        //u stores the current User's information
        private User u;
        
        //cancelclicked tells if the cancelbutton was clicked
        private bool cancelclicked;
        
        //homeclicked tell if the homebutton was clicked
        private bool homeclicked;

        /// <summary>
        ///  Default constructor
        ///  
        ///  @param: User, Form
        ///  @return: none
        /// </summary>
        public AddStudentAddress(User a, Form f)
        {
            InitializeComponent();

            //Store the passed in User
            u = a;
            
            //Store the passed in Form
            last = f;
        }

        /// <summary>
        ///  Event handler for the RadioButtons
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            //If the Sundance Radio Button is Checked
            if (sundanceRadioButton.Checked == true)
            {
                //Change the MSU Address TextBox to "2602 Midwestern Pkwy"
                msuaddressTextBox.Text = "2602 Midwestern Pkwy";
            }

            //If the Sunwatcher Radio Button is Checked
            else if (SunwatcherRadioButton.Checked == true)
            {
                //Change the MSU Address TextBox to "3704 Louis J. Rodriguez"
                msuaddressTextBox.Text = "3704 Louis J. Rodriguez";
            }

            //If the POBox Radio Button is Checked
            else if (poboxRadioButton.Checked == true)
            {
                //Change the MSU Address TextBox to "3410 Taft Blvd"
                msuaddressTextBox.Text = "3410 Taft Blvd";
            }

            //If the Other Radio Button is Checked 
            else if (otherRadioButton.Checked == true)
            {
                //Reset the MSU Address and AptMB TextBoxes
                msuaddressTextBox.Text = "";
                aptmailTextBox.Text = "";
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
            //if you left some text boxes blank, throw up an "Error"
            //really it's just a messagebox that says there was an error
            if (firstTextBox.Text == "" || lastTextBox.Text == "" || msuaddressTextBox.Text == "" || aptmailTextBox.Text == ""
                || address1TextBox.Text == "" || naCityTextBox.Text == "" || nacountryTextBox.Text == "")
            {
                MessageBox.Show("Please fill in the necessary fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //otherwise put it in the database
            else
            {
                try
                {
                    this.studentTableTableAdapter.Insert(firstTextBox.Text, middleTextBox.Text, lastTextBox.Text, address1TextBox.Text + address2TextBox,
                        naCityTextBox.Text, nastateTextBox.Text, nazipTextBox.Text, emailTextBox.Text,
                        msuaddressTextBox.Text, "TX", "76308", DateTime.Now, idTextBox.Text, nacountryTextBox.Text, "Wichita Falls", aptmailTextBox.Text);
                    this.studentTableTableAdapter.Update(this.pODBDataSet.StudentTable);
                    this.Close();
                    last.Show();
                }
                catch(System.Exception)
                {
                    MessageBox.Show("Insertion failed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        ///  Event handler for the AddStudentAddress Form Load Event
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void AddStudentAddress_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pODBDataSet.StudentTable' table. You can move, or remove it, as needed.
            //this.studentTableTableAdapter.Fill(this.pODBDataSet.StudentTable);
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
            
            //Show the new ChdangePassword Form
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
            
            //Show the new StudentSearch Form
            n.Show();
        }

        /// <summary>
        ///  Event handler for the AddStudentAddress FormClosing Event
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void AddStudentAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If the Home Button was clicked
            if(homeclicked)
            {
                //Close the last Form
                last.Close();
            }

            //If the Cancel Button was clicked
            else if(cancelclicked)
            {
                //Show the last Form
                last.Show();
            }
        }

        /// <summary>
        ///  Event handler for the Cancel Button
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void cancel_Click(object sender, EventArgs e)
        {
            //Set homeclicked and cancelclicked
            cancelclicked = true;
            homeclicked = false;

            //Close this Form
            this.Close();
        }

        /// <summary>
        ///  Event handler for the HomePic
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void HomePic_Click(object sender, EventArgs e)
        {
            //if the User is an Admin
            if(u.isAdmin())
            {
                //Create a new AdminHomPage
                Form n = new AdminHomePage(u);

                //Set homeclicked and cancelclicked
                homeclicked = true;
                cancelclicked = false;
                
                //Close this Form
                this.Close();

                //Show the new AdminHomePage Form
                n.Show();
            }

            //This code should never execute
            //Its really just here as a safty net
            //If the user is not an Admin
            else if(!u.isAdmin())
            {
                //Create a new StudentSearch Form
                Form n = new StudentSearch(new User());

                //Set homeclicked and cancelclicked
                homeclicked = true;
                cancelclicked = false;

                //Close this Form
                this.Close();
                //Show the new StudentSearch Form
                n.Show();
            }
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
