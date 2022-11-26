using System;

<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/Models/Item.cs
namespace CityInMotionSend.Models
========
namespace CityInMotionApp.Models
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/Models/Item.cs
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/Models/Item.cs
        public string Location { get; set; }
        public int rating { get; set; }
========

        public string Location { get; set; }
        public int Rating { get; set; }
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/Models/Item.cs
    }
}