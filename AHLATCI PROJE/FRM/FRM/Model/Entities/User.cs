﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class User :IPerson
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }


    }
}
