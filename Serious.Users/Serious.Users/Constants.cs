using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serious.Users
{
    public static class Constants
    {
        public const int MAX_STRING_LENGTH_NAME = 50;
        public const int MAX_STRING_LENGTH_PASSWORD = 50;

        public const string MASTER = "master";
        public const string FORMS = "Forms";
        public const string AUTH_PATH = "system.web/authentication";
        public const string USER_NAME = "user_name";
        public const string AES_IV_256 = @"!QAZ2WSX#EDC4RFV";

        public const string LOG_OUT = "logout";

        #region actions

        public const string MANAGE_USERS = "ManageUsers";

        #endregion
    }
}