using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle_Management_System.Models
{
    public class Logins : ILogin
    {
        VMSEntities entities = new VMSEntities();
        private LoginModel login = null;


        public Logins()
        {
            login = new LoginModel();
        }

        public bool CheckUser(LoginModel login)
        {
            try
            {
                bool hasEntity = entities.Logins.Where(x => x.userid == login.userid && x.userpass == login.userpass).Any();
                return hasEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public LoginModel GetUser(LoginModel login)
        {
            try
            {

                Login _login = entities.Logins.Where(x => x.userid == login.userid && x.userpass == login.userpass).FirstOrDefault();

                this.login.id = login.id;
                this.login.userid = login.userid;
                this.login.userpass = "";
                return this.login;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}