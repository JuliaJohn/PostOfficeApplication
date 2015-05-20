/*
 * Michael Whitley  
 * 5/3/2015
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO
{
    /// <summary>
    ///  This class is used for the storage of
    ///  Student information.
    /// </summary>
    public class Student
    {
        
        //mNum stores the Mustang ID number of the Student
        private String mNum;
        
        //fName stores the First Name of the Student
        private String fName;
        
        //lName stores the Last Name of the Student
        private String lName;
        
        //midName stores the Middle Name of the Student
        private String midName;
        
        //email stores the Email address of the Student
        private String email;
        
        //mStAddress stores the Address at which the Student lived on campus
        private String mStAddress;
        
        //aptmb stores the Apartment or Mailbox number of the Student
        //while they lived on campus
        private String aptmb;
        
        //mCity stores the name of the City in which MSU is located
        private String mCity;
        
        //mState stores the name of the State in which MSU is located
        private String mState;
        
        //mZip stores the Zip code in which MSU is located
        private String mZip;
        
        //nStAddress stores the New Address at which the Student resides
        private String nStAddress;
        
        //nCity stores the New City in which the Student resides
        private String nCity;
        
        //nState stores the New State in which the Student resides
        private String nState;
        
        //nZip stores the New Zip code in which the Student resides
        private String nZip;
        
        //nCountry stores the New Country in which the Student resides
        private String nCountry;
        
        //dateAdded stores the date when the Student was added to the Database
        private DateTime dateAdded;
        
        //iD stores the Mustang ID number of the Student
        private int iD;

        /// <summary>
        ///  Constructor
        ///  
        ///  @param: String, String, String, String, String, String, String, String, String, String, String, String, String, 
        ///          String, DateTime, String, it
        ///  @return: none
        /// </summary>
        public Student(String mnum, String fn, String ln, String mn, String em, String mAdd, String mC, String mSt, 
            String mZ, String nAdd, String nC, String nSt, String nZ, String nCountry, DateTime now, String amb, int id)
        {
            //Saves all the passed in information to the Object
            mNum = mnum;
            fName = fn;
            lName = ln;
            midName = mn;
            email= em;
            mStAddress = mAdd;
            mCity = mC;
            mState = mSt;
            mZip = mZ;
            nStAddress = nAdd;
            nCity = nC;
            nState = nSt; 
            nZip = nZ;
            this.nCountry = nCountry;
            dateAdded = now;
            aptmb = amb;
            iD = id;
        }

        /// <summary>
        ///  Creates a String to be displayed in a MessageBox
        ///  
        ///  @param: none
        ///  @return: String
        /// </summary>
        public override String ToString()
        {
            String r ="";
            r += "First Name: " + fName + System.Environment.NewLine;
            r += "Middle Name: " + midName + System.Environment.NewLine;
            r += "Last Name: " + lName + System.Environment.NewLine;
            r += "New Address: " + nStAddress + "," + System.Environment.NewLine;
            r += "                  " + nCity + "," + System.Environment.NewLine;

            if(nZip != "")
            {
                r += "                  " + nZip + "," + System.Environment.NewLine;
            }

            r += "                  " + nCountry + System.Environment.NewLine;
            r += "MSU Address: " + mStAddress + aptmb + "," + System.Environment.NewLine;
            r += "                      " + mCity + "," + System.Environment.NewLine;
            r += "                      " + mState + "," + System.Environment.NewLine;
            r += "                      " + mZip + "," + System.Environment.NewLine;
            r += "Date Added: " + dateAdded.Date.ToString("d") + System.Environment.NewLine;
            return r;
        }

        /// <summary>
        ///  Property of fName
        /// </summary>
        public String FName
        {
            get
            {
                return fName;
            }

            set
            {
                fName = value;
            }
        }

        /// <summary>
        ///  Property of lName
        /// </summary>
        public String LName
        {
            get
            {
                return lName;
            }
            set
            {
                lName = value;
            }
        }

        /// <summary>
        ///  Property of midName
        /// </summary>
        public String MidName
        {
            get
            {
                return midName;
            }

            set
            {
                midName = value;
            }
        }

        /// <summary>
        ///  Property of email
        /// </summary>
        public String Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        /// <summary>
        ///  Property of mStAddress
        /// </summary>
        public String MStAddress
        {
            get
            {
                return mStAddress;
            }
            set
            {
                mStAddress= value;
            }
        }

        /// <summary>
        ///  Property of mCity
        /// </summary>
        public String MCity
        {
            get
            {
                return mCity;
            }
            set
            {
                mCity = value;
            }
        }

        /// <summary>
        ///  Property of mState
        /// </summary>
        public String MState
        {
            get
            {
                return mState;
            }
            set
            {
                mState = value;
            }
        }

        /// <summary>
        ///  Property of mZip
        /// </summary>
        public String MZip
        {
            get
            {
                return mZip;
            }
            set
            {
                mZip = value;
            }
        }

        /// <summary>
        ///  Property of nStAddress
        /// </summary>
        public String NStAddress
        {
            get
            {
                return nStAddress;
            }
            set
            {
                nStAddress = value;
            }
        }

        /// <summary>
        ///  Property of nCity
        /// </summary>
        public String NCity
        {
            get
            {
                return nCity;
            }
            set
            {
                nCity = value;
            }
        }

        /// <summary>
        ///  Property of nState
        /// </summary>
        public String NState
        {
            get
            {
                return nState;
            }
            set
            {
                nState = value;
            }
        }

        /// <summary>
        ///  Property of nZip
        /// </summary>
        public String NZip
        {
            get
            {
                return nZip;
            }
            set
            {
                nZip = value;
            }
        }

        /// <summary>
        ///  Property of dateAdded
        /// </summary>
        public DateTime DateAdded
        {
            get
            {
                return dateAdded;
            }
            set
            {
                dateAdded = value;
            }
        }

        /// <summary>
        ///  Property of mNum
        /// </summary>
        public String MNum
        {
            get
            {
                return mNum;
            }

            set
            {
                mNum = value;
            }
        }

        /// <summary>
        ///  Property of nCountry
        /// </summary>
        public String NCountry
        {
            get
            {
                return nCountry;
            }

            set
            {
                nCountry = value;
            }
        }

        /// <summary>
        ///  Property of aptmb
        /// </summary>
        public String Aptmb
        {
            get
            {
                return aptmb;
            }

            set
            {
                aptmb = value;
            }
        }

        /// <summary>
        ///  Property of iD
        /// </summary>
        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }
    }
}
