using System;
using System.Collections.Generic;

namespace OnlineShopping.BL
{
    public class User
    {
        private string _username = "client123";
        public string Username
        {
            get
            {
                return _username;
            }
        }

        private string _password = "12345678";
        public string Password
        {
            get
            {
                return _password;
            }
        }
        public User (string buyerUsername, string buyerPassword)
        {
            this.BuyerUsername = buyerUsername;
            this.BuyerPassword = buyerPassword;
        }

        public string BuyerUsername { get; set; }
        public string BuyerPassword { get; set; }

        [Serializable]
        public enum UserRole
        {
            Client,
            Buyer

        }
    }
}
