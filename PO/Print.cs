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
    public partial class Print : Form
    {
        private bool loggedin;
        private LabelQueue lq;
        private User u;
        public static char[] NewLine = { '\r', '\n' };
        public Print(LabelQueue queue, User a)
        {
            InitializeComponent();
            u = a;
            init();
            lq = queue;
            DateTime currentDate = DateTime.Now;
            DateTime date2 = DateTime.Now.AddMonths(-18);
            Bitmap bmp = new Bitmap(837, 1025);
            
            //pictureBox1.Size = new System.Drawing.Size(600,600);
            Graphics PrintPreview = Graphics.FromImage(bmp);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Near;
            int x, y, c = 0;
            //this.Size = new System.Drawing.Size(600, 300);
            Rectangle [,] rect = new Rectangle[30,5];
            for (int count = 0; count < 30; count++)
            {
                // Get coordinates for where to put values.
                x = ((count /10) * 280) + 45;
                // Accounts for column gap
                if (count /10 > 0)
                    x = x + ((count % 3)-30) ;
                y = ((count % 10) * 93) ;

                for (int count2 = 0; count2 < 5; count2++)
                {
                    rect[count, count2] = new Rectangle(x, y, 200, 94);
                    y = y + 33;
                }
            }
            Font trFont = new Font("Times New Roman", 15, GraphicsUnit.Pixel);
            
            PrintPreview.Clear(Color.White);
             //Prints each label at its position in the bitmap
            while (c < lq.labels.Length - 1)
            {
                string firstLine,over;
                DateTime Time = lq.labels[c].GetDateAdded();
                int result = DateTime.Compare(Time, date2);
                firstLine = lq.labels[c].GetFirstName() + ", " + lq.labels[c].GetLastName() + " " + lq.labels[c].GetMiddleName() + "\n" + lq.labels[c].GetNewStreet() + " \n" + lq.labels[c].GetNewCity() + ", " + lq.labels[c].GetNewState() + ", " + lq.labels[c].GetNewZIP() + lq.labels[c].GetNewCountry() + " \n";
                over = "Return to sender";
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                if (result < 0)
                {
                    PrintPreview.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    PrintPreview.DrawString(firstLine, trFont, drawBrush, rect[c, 2], stringFormat);
                }
                else if(result > 18)
                {
                    PrintPreview.DrawString(over, trFont, drawBrush, rect[c, 2], stringFormat);
                }

                        c++;
            }

            PrintPreview.Flush();
            pictureBox1.Image = bmp;
            
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (u.isAdmin())
            {
                this.Close();
                Form f = new AdminHomePage(u);
            }

            else
            {
                this.Close();
                Form f = new StudentSearch(new User());
            }
        }

        private void init()
        {
            if (u.isAdmin())
            {
                logOutToolStripMenuItem.Text = "Logout";
            }

            else if (!u.isAdmin())
            {
                logOutToolStripMenuItem.Text = "Login";
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(u.isAdmin())
            {
                Form n = new Print(lq, new User());
                this.Close();
                n.Show();
            }

            else if(!u.isAdmin())
            {
                DialogResult result = MessageBox.Show("If you continue, you will lose the items in the Print Queue.\n Do you want to continue?", "Notice",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(result == DialogResult.Yes)
                {
                    Form n = new AdminLogin();
                    this.Close();
                    n.Show();
                }
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form n = new StudentSearch(u);
            this.Close();
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
        private void PrintButton_Click(object sender, System.EventArgs e)
    {
            DialogResult forceprintresult = MessageBox.Show("Are you sure you want to print?", "Print", MessageBoxButtons.YesNoCancel);
            System.Drawing.Printing.PrintDocument pd = new
            System.Drawing.Printing.PrintDocument();
            pd.PrintPage+=new
            System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);
            pd.Print();
    }

        private void pd_PrintPage(object sender,
        System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image,0,0);
        }

        private void Print_Load(object sender, EventArgs e)
        {

        }
    }
}
