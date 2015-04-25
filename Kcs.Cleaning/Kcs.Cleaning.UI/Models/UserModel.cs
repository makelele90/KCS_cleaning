﻿using System;

namespace Kcs.Cleaning.UI.Models
{
	public class UserModel
	{
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
	    public DateTime CreatedOn { get; set; }
	}
}