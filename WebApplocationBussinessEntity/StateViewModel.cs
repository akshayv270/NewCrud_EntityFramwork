﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplocationBussinessEntity
{
    public class StateViewModel
    {
        public int Id { get; set; }
        public string? StateName { get; set; }

        public bool IsActive { get; set; }
    }
}
