using System;
using System.Collections.Generic;

namespace InstemTest.SharedSdk.Models
{
    public class MovieInfo
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
