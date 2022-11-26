using System;

namespace CityInMotionApp.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public string Location { get; set; }
        public int Rating { get; set; }
    }
}