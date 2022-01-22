﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? Village { get; set; }
        public string? Taluka { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Zip { get; set; }
    }
}
