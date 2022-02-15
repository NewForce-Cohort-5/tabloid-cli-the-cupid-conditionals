﻿using System.Collections.Generic;

namespace TabloidCLI.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();

        //this method is to print 
        public override string ToString()
        {
            return $"{Title} ({Url})";
        }
    }
}