﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zanarzedziami.Service;
using System.Threading.Tasks;

namespace zanarzedziami.Model
{
    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

