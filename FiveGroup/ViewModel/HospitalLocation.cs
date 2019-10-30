using FiveGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiveGroup.ViewModel
{
    public class HospitalLocation
    {
        public List<hospital> Hospitals { get; set; }
        public List<city> Cities { get; set; }
        public List<district> Districts { get; set; }

    }
}