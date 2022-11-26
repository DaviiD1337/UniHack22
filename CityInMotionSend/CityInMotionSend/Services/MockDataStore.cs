<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/Services/MockDataStore.cs
﻿using CityInMotionSend.Models;
========
﻿using CityInMotionApp.Models;
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/Services/MockDataStore.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/Services/MockDataStore.cs
namespace CityInMotionSend.Services
========
namespace CityInMotionApp.Services
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/Services/MockDataStore.cs
{
    public class MockDataStore : IDataStore<Item>
    {
        public static List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/Services/MockDataStore.cs
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." , Location = "Timisoara",rating = -1},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description.",Location = "Timisoara",rating = -1 },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." ,Location = "Satu Mare",rating = -1},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description.",Location = "Timisoara",rating = -1 },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description.",Location = "Timisoara",rating = -1 },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description.", Location = "SatuMare",rating = -1}
========
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." ,Location = "Timisoara",Rating = 0 },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description.",Location = "Timisoara",Rating = 0 },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description.",Location = "Satu Mare",Rating = 0 },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." ,Location = "Satu Mare", Rating = 0},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." ,Location = "Timisoara" , Rating = 0},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." ,Location = "Satu Mare" , Rating = 0}
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/Services/MockDataStore.cs
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}