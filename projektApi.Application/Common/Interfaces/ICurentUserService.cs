﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Common.Interfaces
{
    public interface ICurentUserService
    {
        string Email { get; set; }
        bool IsAuthenticated { get; set; }
    }
}
