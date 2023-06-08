using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Material_costs
{
    public class Accaunts
    {
        private static bool isAdmin = false;
        private static bool isAuthorized = false;
        private static bool[] logIn = new bool[2];
        public static bool[] AdminCheck(string login, string password)
        {
            if(login == "nik" && password == "123")
            {
                isAdmin = true;
                isAuthorized = true;
            }else if(login == "bob" && password == "321")
            {
                isAuthorized = true;
            }
            logIn[0] = isAuthorized;
            logIn[1] = isAdmin;
            return logIn;
        }
    }
}