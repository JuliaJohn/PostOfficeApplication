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
    ///  This class is the super-class
    ///  to the admin class
    /// </summary>
    public class User
    {   
        //fName stores the first name of the user
        private String fName;

        //lName stores the last name of the user
        private String lName;

        //username stores the Username of the user
        private String username;

        /// <summary>
        ///  Default constructor.
        ///  Initializes all the values to the
        ///  empty string
        ///  
        ///  @param: none
        ///  @return: none
        /// </summary>
        public User()
        {
            fName = "";
            lName = "";
            username = "";
        }

        /// <summary>
        ///  This method returns whether or not a user
        ///  is an admin
        ///  User is not an admin
        ///  
        ///  @param: none
        ///  @returns: bool
        /// </summary>
        public virtual bool isAdmin()
        {
            return false;
        }

        /// <summary>
        ///  Property of fName
        ///  
        ///  @param: none
        ///  @returns: String
        /// </summary>
        public virtual String FName
        {
            get
            {
                return fName;
            }
        }

        /// <summary>
        ///  Property of lName
        ///  
        ///  @param: none
        ///  @returns: String
        /// </summary>
        public virtual String LName
        {
            get
            {
                return lName;
            }
        }

        /// <summary>
        ///  Property of username
        ///  
        ///  @param: none
        ///  @returns: String
        /// </summary>
        public virtual String Username
        {
            get
            {
                return username;
            }
        }
    }
}
