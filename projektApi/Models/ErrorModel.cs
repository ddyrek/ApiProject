﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projektApi.Models
{
    public class ErrorModel
    {
        public string ErrorMessage { get; set; }
        public string InnerException { get; set; }
    }
}
