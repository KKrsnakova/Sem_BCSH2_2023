﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Sem_BCSH2_2023.Model;

namespace Sem_BCSH2_2023.Model
{
    public class UserLogins
    {
      //  public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }


        public UserLogins(string username, string password, string fullName, string email)
        {
            Username = username;
            Password = password;
            FullName = fullName;
            Email = email;
        }


    }
}