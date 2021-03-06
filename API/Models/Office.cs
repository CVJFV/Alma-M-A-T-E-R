﻿using System.Collections.Generic;

namespace API
{
    public class Office
    {
        public int OfficeID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public ICollection<Apartment> Apartaments { get; set; }
    }
}
