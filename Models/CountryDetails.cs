﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CountryDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class StateDetails : CountryDetails
    {
        public int StateId { get; set; }
    }
    public class DivisionDetails : StateDetails
    {
        public int DivisionId { get; set; }
    }
    public class TalukaDetails : DivisionDetails
    {
        public int TalukaId { get; set; }
    }
}
