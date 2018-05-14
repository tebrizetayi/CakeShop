using System;
using System.Collections.Generic;
using System.Text;

namespace CakeShop.Net.Model.DTO
{
    public class UserDto : BaseDto
    {
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string SaltPassword
        {
            get;
            set;
        }
        public string AlternatePassword
        {
            get;
            set;
        }
    }
}
