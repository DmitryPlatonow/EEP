﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEP.Entities.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? IsBlocked { get; set; }
    }
}
