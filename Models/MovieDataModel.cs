﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstemTest.Models
{
    public class MovieDataModel
    {
        public int Year { get; set; }
        public string Title { get; set; }
        public Info Info { get; set; }
    }

    public class Info
    {
        public List<string> Directors { get; set; }
        public DateTime Release_date { get; set; }
        public double Rating { get; set; }
        public List<string> Genres { get; set; }
        public string Image_url { get; set; }
        public string Plot { get; set; }
        public int Rank { get; set; }
        public int Running_time_secs { get; set; }
        public List<string> Actors { get; set; }
    }
}
