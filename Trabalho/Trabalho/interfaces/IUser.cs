﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.models;

namespace Trabalho.interfaces
{
    public interface IUser
    {
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }

        User LogIn(User[] UserList,string email,string password);
        Hashtable Register(Hashtable UserList);
    }
}
