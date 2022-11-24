﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool success { get; set; } = true;
        public string message { get; set; }=String.Empty;

    }
}
