﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPatternAPI.Application.ViewModels.Product
{
    public class VM_Create_Product 
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
}
