﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCar.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        //public int Status { get; set; } = 0;
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
