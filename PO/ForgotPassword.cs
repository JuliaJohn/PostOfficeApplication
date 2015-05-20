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
using System.Net.Mail;
using System.Configuration;

namespace PO
{
    /// <summary>
    ///  This class is the ForgotPassword Form
    /// </summary>
    public partial class ForgotPassword : Form
    {
        //password stores the User's entered password
        private String password;
        
        //email stores the User's entered email
        private String email;
        
        //to stores the User's email
        private String to;
        
        //from stores the email from which the email is sent
        private String from;
        
        //sub stores the text of the subject line
        private String sub;
        
        //msg stores the text of the messsage 
        private String msg;

        /// <summary>
        ///  Constructor
        ///  
        ///  @param: none
        ///  @return: none;
        /// </summary>
        public ForgotPassword()
        {
            InitializeComponent();

            //initialize the member data to the empty String
            password = "";
            email = "";
            to = "";
            from = "";
            sub = "";
            msg = "";
        }

        /// <summary>
        ///  Event handler for the SendEmail Button
        ///  
        ///  @param:
        ///  @return:
        /// </summary>
        private void sendemailbtn_Click(object sender, EventArgs e)
        {
            //Get the email from the textbox on the form
            email = emailtxt.Text;

            //Fill the invisible datagridview based on the email
            this.adminTableTableAdapter.FillByEmail(pODBDataSet.AdminTable, email);

            //If there is only one entry in the database, get the information
            //and send it to the email.
            if (adminDataGridView.Rows.Count == 1)
            {
                //Send the Email
                try
                {
                    //set the member data based on entered data and AdminDataGridView
                    to = adminDataGridView.Rows[adminDataGridView.Rows[0].Index].Cells[2].Value.ToString();
                    from = "MSUPOHELP@gmail.com";
                    sub = "PO Application Forgotten Password!";
                    password = adminDataGridView.Rows[adminDataGridView.Rows[0].Index].Cells[3].Value.ToString();
                    msg = "It seems you have forgotten your password, so here it is:" + '\n';
                    msg += password;

                    //Create a new SmtpClient
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;

                    //Create new NetworkCredentials
                    System.Net.NetworkCredential credentials = new
                                        System.Net.NetworkCredential("MSUPOHELP@gmail.com", "MsuSEItDepends2015");
                    smtpClient.Credentials = credentials;

                    string[] tos;
                    this.to = this.to.Replace(',', ' ');

                    tos = this.to.Split();
                    for (int i = 0; i < tos.Length; i++)
                    {
                        MailMessage ml = new MailMessage(this.from, tos[i].ToString(), this.sub, this.msg);
                        ml.IsBodyHtml = true;
                        smtpClient.Send(ml);
                    }
                    MessageBox.Show("Your email is on it's way, it may be just a moment!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (ArgumentException p)
                {
                    MessageBox.Show(p.Message, "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                catch (SmtpException p)
                {
                    MessageBox.Show(p.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Close this Form
                this.Close();
            }
            
            //If the Email is not in the Database
            else
            {
                MessageBox.Show("There doesn't seem to be anyone with that email in the system! Please re-enter your email or contact a system administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  Event handler fort the Cancel Button
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void cancelbtn_Click(object sender, EventArgs e)
        {
            //Close this Form
            this.Close();
        }

        /// <summary>
        ///  Event handler for ForgotPassword Load Event
        ///  
        ///  @param: object, EventArgs
        ///  @return: none
        /// </summary>
        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pODBDataSet.AdminTable' table. You can move, or remove it, as needed.
            this.adminTableTableAdapter.Fill(this.pODBDataSet.AdminTable);
        }
    }
}
