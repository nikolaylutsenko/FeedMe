﻿using System;
using Microsoft.AspNetCore.Identity;

namespace Core.Models
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}