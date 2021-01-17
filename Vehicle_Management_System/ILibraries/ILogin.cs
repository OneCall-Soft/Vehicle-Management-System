using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Management_System.Models;

namespace Vehicle_Management_System
{
   public interface ILogin
    {
        /// <summary>
        /// It is called when a user is to be validated 
        /// </summary>
        /// <param name="login">user credentials</param>
        /// <returns>true/false</returns>
        bool CheckUser(LoginModel login);
    }
}
