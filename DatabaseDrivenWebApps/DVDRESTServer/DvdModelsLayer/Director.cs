﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdModelsLayer
{
    public class Director
    {
        public int DirectorId { get; set; }
        public string Name { get; set; }
        public List<Dvd> Dvds { get; set; }
        
    }
}