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
    ///  This class is the Admin class
    ///  Child of the User class
    ///  Stores Admin information
    /// </summary>
    public class Admin : User
    {
        //fName stores the Admin's First Name
        private String fName;
        
        //lName stores the Admin's Last Name
        private String lName;
        
        //username stores the Admin's Username
        private String username;

        /// <summary>
        ///  Default constructor
        ///  
        ///  @param: String, String, String
        ///  @return: none
        /// </summary>
        public Admin(String f, String l, String u)
        {
            //Stores the passed in data
            //in the member data
            fName = f;
            lName = l;
            username = u;
        }

        /// <summary>
        ///  Checks if the Admin is an Admin
        ///  
        ///  @param: none
        ///  @return: bool
        /// </summary>
        public override bool isAdmin()
        {
            return true;
        }

        /// <summary>
        ///  Property of fName
        /// </summary>
        public override String FName
        {
            get
            {
                return fName;
            }
        }

        /// <summary>
        ///  Property of lName
        /// </summary>
        public override String LName
        {
            get
            {
                return lName;
            }
        }

        /// <summary>
        ///  Property of username
        /// </summary>
        public override String Username
        {
            get
            {
                return username;
            }
        }
    }
}
