/*
 * Michael Whitley and Trey Brumley
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
    ///  This class is the Form StudentSearch
    /// </summary>
    public partial class StudentSearch : Form
    {
        //u holds the current user's information
        private User u;

        /// <summary>
        ///  Default Constructor.
        ///  
        ///  @param: User
        ///  @return: none
        /// </summary>
        public StudentSearch(User a)
        {
            InitializeComponent();

            //Saves the current user's information to be used
            //in the Form later
            u = a;

            init();
        }

        /// <summary>
        ///  Alternate Constructor
        ///  Used when updating a entry in the Database
        ///  
        ///  @param:
        ///  @return:
        /// </summary>
        public StudentSearch(User a, Student newP)
        {
            InitializeComponent();

            //Saves the current user's information to be used
            //in the Form later
            u = a;

            init();

            //Perform the Update
            try
            {
                this.studentTableTableAdapter.UpdateQuery(newP.FName, newP.MidName, newP.LName, newP.NStAddress, newP.NCity,
                newP.NState, newP.NZip, newP.Email, newP.MStAddress, newP.MState, newP.MZip, newP.DateAdded,
                newP.MNum, newP.NCountry, newP.MCity, newP.Aptmb, newP.ID);
                this.studentTableTableAdapter.Update(this.pODBDataSet.StudentTable);
            }
            catch(System.Exception)
            {
                MessageBox.Show("Update failed.","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  Event handler for the Load action of the StudentSearch Form
        ///  Uncommenting the second line will result in ResultList
        ///  being populated with the entire contents of the Database
        ///  when the Form is initially loaded.
        /// 
        ///  @param:
        ///  @return:
        /// </summary>
        private void StudentSearch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rosterDataSet.Rosters' table. You can move, or remove it, as needed.
           // this.studentTableTableAdapter.Fill(this.pODBDataSet.StudentTable);

        }

        /// <summary>
        ///  Event Handler for the LogIn Tool Strip Menu Item
        ///  and the AdminLogin Button
        ///  
        ///  @param: object, EventArgs
        ///  @return:
        /// </summary>
        private void AdminLogin_Click(object sender, EventArgs e)
        {
            //if the current User is an Admin
            if (u.isAdmin())
            {
                //Change the text of the login components on the Form
                adminloginButton.Text = "Admin Login";
                logInToolStripMenuItem.Text = "Login";

                //Hide the components that only an Admin can use
                updateButton.Visible = false;
                addressToolStripMenuItem.Visible = false;
                homePictureBox.Visible = false;

                //Display a MessageBox confirmation
                MessageBox.Show("You have successfully been logged out. Click OK to return.", "Logged out", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //if the current User is not an Admin
            else if(!u.isAdmin())
            {
                //Create a new AdminLogin Form
                Form m = new AdminLogin();
                //Show the new AdminLogin Form
                m.Show();
                //Close this Form
                this.Hide();
            }
        }


        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int init = Convert.ToInt32(QueueView.RowCount);
            Label[] label = new Label[init];

            for (int c = 0; c < init; c++)
                label[c] = new Label();

            int count = Convert.ToInt32(QueueView.RowCount);
            
            for (int c = 0; c < count; c++)
            {
                string fn, mn, ln, ns, nc, nstate, ncountry, nz;
                
                // Gets information and converts to strings
                fn = Convert.ToString(QueueView.Rows[c].Cells[1].Value);
                mn = Convert.ToString(QueueView.Rows[c].Cells[2].Value);
                ln = Convert.ToString(QueueView.Rows[c].Cells[0].Value);
                ns = Convert.ToString(QueueView.Rows[c].Cells[3].Value);
                nc = Convert.ToString(QueueView.Rows[c].Cells[4].Value);
                nstate = Convert.ToString(QueueView.Rows[c].Cells[5].Value);
                nz = Convert.ToString(QueueView.Rows[c].Cells[6].Value);
                ncountry = Convert.ToString(QueueView.Rows[c].Cells[7].Value);
                
                // Stores label information
                label[c].setLastName(ln);
                label[c].setFirstName(fn);
                label[c].setMiddleName(mn);
                label[c].setNewStreet(ns);
                label[c].setNewCity(nc);
                label[c].setNewState(nstate);
                label[c].setNewZIP(nz);
                label[c].setNewCountry(ncountry);
            }
            
            LabelQueue lq = new LabelQueue(label);
            Print Pform = new Print(lq, u);
            Pform.Show();
        }

        private void forcePrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult forceprintresult = MessageBox.Show("Are you sure you want to force print?", "Force Print", MessageBoxButtons.YesNoCancel);
        }

        /// <summary>
        ///  Event Handler for the Radio Buttons on the Form
        ///  
        ///  @param:
        ///  @return:
        /// </summary>
        private void radiobuttons_CheckChanged(object sender, EventArgs e)
        {
            //If Name Radio Button is Checked
            if (nameRadioButton.Checked)
            {
                //Make the Name Panel Visible
                namePanel.Visible = true;

                //and Hide the MSU ID Panel
                idPanel.Visible = false;
            }

            //If the MSU ID Radio Button is Checked
            else if (idRadioButton.Checked)
            {
                //Make the MSU ID Panel Visible
                idPanel.Visible = true;

                //and Hide the Name Panel
                namePanel.Visible = false;
            }
        }

        /// <summary>
        ///  Event Handler for the Search Button
        ///  
        ///  @param:
        ///  @return:
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            //If searching by name
            if (nameRadioButton.Checked)
            {
                //If you don't enter anything, we can't search...
                if (firstnameTextBox.Text == "" && middlenameTextBox.Text == "" && lastnameTextBox.Text == "")
                {
                    MessageBox.Show("You have to enter a name to search!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //If you leave the firstnameTextBox we can't search
                else if (firstnameTextBox.Text == "" && lastnameTextBox.Text != "")
                {
                    MessageBox.Show("You left the First Name field blank. Please provide a First Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //If you leave the lastnameTextBox empty we can't search
                else if (firstnameTextBox.Text != "" && lastnameTextBox.Text == "")
                {
                    MessageBox.Show("You left the Last Name field blank. Please provide a Last Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //otherwise, we can search... yay
                else
                {
                    //if searching by first name, last name, AND middle name
                    if (middlenameTextBox.Text != "")
                    {
                        //perform the query
                        try
                        {
                            studentTableTableAdapter.FillByName(this.pODBDataSet.StudentTable, firstnameTextBox.Text, middlenameTextBox.Text, lastnameTextBox.Text);
                            if (ResultList.Rows.Count - 1 == 0)
                            {
                                MessageBox.Show("It seems that the person you were searching for is not in the database." + System.Environment.NewLine + "Please try a different search.",
                                "Attention", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                        }
                        catch (System.Exception)
                        {
                            MessageBox.Show("Error retrieving data.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //if only searching by first and last name
                    else if (middlenameTextBox.Text == "")
                    {
                        //perform the query
                        try
                        {
                            studentTableTableAdapter.FillByFirstLast(this.pODBDataSet.StudentTable, firstnameTextBox.Text, lastnameTextBox.Text);
                            if (ResultList.Rows.Count - 1 == 0)
                            {
                                MessageBox.Show("It seems that the person you were searching for is not in the database." + System.Environment.NewLine + "Please try a different search.",
                                "Attention", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                        }
                        catch (System.Exception)
                        {
                            MessageBox.Show("Error retrieving data.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            //if searching by MNumber
            else if (idRadioButton.Checked)
            {
                //If the MSU ID Text Box is not empty
                if (idTextBox.Text != "")
                {

                    //perform the query
                    try
                    {
                        studentTableTableAdapter.FillByMNum(this.pODBDataSet.StudentTable, idTextBox.Text);
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("Error retrieving data.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        ///  Event Handler for the AdminHome Tool Strip Menu Item and 
        ///  the Home Picture Box
        ///  
        ///  @param:
        ///  @return:
        /// </summary>
        private void adminHomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //just in case someone some how got the button
            //to show up without being an Admin
            //we check to see if the current User is an Admin
            if (u.isAdmin())
            {
                //Create a new AdminHomePage Form
                Form n = new AdminHomePage(u);

                //Close this Form
                this.Close();

                //Show the new AdminHomePage Form
                n.Show();
            }
        }

        /// <summary>
        ///  Event handler for the Update Tool Strip Menu Item and 
        ///  the Update Button
        ///  
        ///  @param:
        ///  @return:
        /// </summary>
        private void updateButton_Click(object sender, EventArgs e)
        {
            //Stores the number of selected rows
            int selectedRowCount = ResultList.Rows.GetRowCount(DataGridViewElementStates.Selected);

            //if there is only one row selected
            if (selectedRowCount == 1)
            {
                //Get the selected row's index and store it
                int selectedRowIndex = ResultList.SelectedCells[0].RowIndex;

                //Create a DataGridViewRow containing the information of the
                //selected row in ResultList
                DataGridViewRow selectedRow = ResultList.Rows[selectedRowIndex];

                //Declare some variables to store the information from ResultList
                int id;
                String fn, ln, midn, em, madd, mc, mst, mz, nadd, nc, nst, nz, ncountry, dateadded, mnum, amb;
                DateTime date;
                int day, month, year;
                char[] delim = { '/', ' ' };
                String[] info;

                //Get the information from ResultList and
                //store it in the variables
                id = Convert.ToInt32(selectedRow.Cells[0].Value);
                fn = Convert.ToString(selectedRow.Cells[1].Value);
                midn = Convert.ToString(selectedRow.Cells[2].Value);
                ln = Convert.ToString(selectedRow.Cells[3].Value);
                nadd = Convert.ToString(selectedRow.Cells[4].Value);
                nc = Convert.ToString(selectedRow.Cells[5].Value);
                nst = Convert.ToString(selectedRow.Cells[6].Value);
                nz = Convert.ToString(selectedRow.Cells[7].Value);
                em = Convert.ToString(selectedRow.Cells[8].Value);
                madd = Convert.ToString(selectedRow.Cells[9].Value);
                mst = Convert.ToString(selectedRow.Cells[10].Value);
                mz = Convert.ToString(selectedRow.Cells[11].Value);
                dateadded = Convert.ToString(selectedRow.Cells[12].Value);
                mnum = Convert.ToString(selectedRow.Cells[13].Value);
                ncountry = Convert.ToString(selectedRow.Cells[14].Value);
                mc = Convert.ToString(selectedRow.Cells[15].Value);
                amb = Convert.ToString(selectedRow.Cells[16].Value);

                info = dateadded.Split(delim);
                month = Convert.ToInt32(info[0]);
                day = Convert.ToInt32(info[1]);
                year = Convert.ToInt32(info[2]);
                date = new DateTime(year, month, day);

                //Create a new Student based on the stored information from ResultList
                Student s = new Student(mnum, fn, ln, midn, em, madd, mc, mst, mz, nadd, nc, nst, nz, ncountry, date, amb, id);
                
                //Create a new UpdateStudentAddress Form
                Form n = new UpdateStudentAddress(s, this, u);

                //Hide this Form
                this.Hide();

                //Show the new UpdateStudentAddress Form
                n.Show();
            }

            //If the User has selected more than one row selected
            else if (selectedRowCount > 1)
            {
                //Show a MessageBox that tells the User to only select one row
                MessageBox.Show("Please select only one student to be updated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            //If the User has not selected a row at all
            else if (selectedRowCount < 1)
            {
                //Show a MessageBox that tells teh User to select a row
                MessageBox.Show("You must select a student to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        ///  Initializes elements on the Form and
        ///  makes the ResultList display columns in a more appeasing way
        ///  
        ///  @param:
        ///  @return:
        /// </summary>
        private void init()
        {
            QueueView.AllowUserToAddRows = false;

            //Hides the columns related to the location
            //of MSU
            ResultList.Columns[0].Visible = false;
            ResultList.Columns[10].Visible = false;
            ResultList.Columns[11].Visible = false;
            ResultList.Columns[15].Visible = false;

            //Brings the columns related to the Student's
            //new address closer to the left
            ResultList.Columns[14].DisplayIndex = 8;
            ResultList.Columns[9].DisplayIndex = 4;
            ResultList.Columns[16].DisplayIndex = 5;

            //Moves the Last Name column of QueueView
            //to after the Middle Name column... it really bugged me.
            QueueView.Columns[0].DisplayIndex = 2;

            //If the current User is an Admin
            if (u.isAdmin())
            {
                //Change the text of the LogIn components
                adminloginButton.Text = "Logout";
                logInToolStripMenuItem.Text = "Logout";

                //Make the Admin-Only components Visible
                adminHomeToolStripMenuItem.Visible = true;
                updateButton.Visible = true;
                addressToolStripMenuItem.Visible = true;
                homePictureBox.Visible = true;
            }

            //If the current User is not an Admin
            else if (!u.isAdmin())
            {
                //Change teh text of the LogIn components
                adminloginButton.Text = "Admin Login";
                adminToolStripMenuItem.Text = "Login";

                //Make the Admin-Only components Hidden
                adminHomeToolStripMenuItem.Visible = false;
                updateButton.Visible = false;
                addressToolStripMenuItem.Visible = false;
                homePictureBox.Visible = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            //Create a new AddStudentAddress Form
            Form n = new AddStudentAddress(u, this);
            
            //Hide this Form
            this.Hide();
            
            //Show the new AddStudentAddress Form
            n.Show();
        }

        private void AddQ_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = ResultList.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = ResultList.Rows[selectedRowIndex];
            int rowIndex;

            int counter = Convert.ToInt32(numberofcopies.Text);
            int total = Convert.ToInt32(QueueView.RowCount) + counter;

            // The empty row is the 31st row, which means 31 rows amounts to 30 labels.
            if (total > 31)
            {
                MessageBox.Show("This action will put you over 30 labels.  Please delete some or reduce the number of labels to be added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                total = total - counter;
            }
            else
            {
                if (total == 31)
                    MessageBox.Show("You now have 30 labels in the queue.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (counter > 0)
                {                   
                    rowIndex = this.QueueView.Rows.Add();
                    var row = this.QueueView.Rows[rowIndex];

                    row.Cells[0].Value = selectedRow.Cells[3].Value; // Last Name
                    row.Cells[1].Value = selectedRow.Cells[1].Value; // First Name
                    row.Cells[2].Value = selectedRow.Cells[2].Value; // Middle Name
                    row.Cells[3].Value = selectedRow.Cells[4].Value; // New Street
                    row.Cells[4].Value = selectedRow.Cells[5].Value; // New City
                    row.Cells[5].Value = selectedRow.Cells[6].Value; // New State
                    row.Cells[6].Value = selectedRow.Cells[7].Value; // New Country
                    row.Cells[7].Value = selectedRow.Cells[14].Value;// New ZIP
                    row.Cells[8].Value = selectedRow.Cells[12].Value;// Date Added

                    counter--;
                }
            }
        }

        private void RemoveQ_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in QueueView.SelectedCells)
            {
                if (oneCell.Selected)
                    QueueView.Rows.RemoveAt(oneCell.RowIndex);
            }
        }

        /// <summary>
        ///  Event handler for the ExitApplication Tool Strip Menu Item
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
