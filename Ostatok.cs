﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstatokSklad
{
    public class Ostatok : Entity
    {
        public string TovarName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
