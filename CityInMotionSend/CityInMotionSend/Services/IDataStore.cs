using System;
using System.Collections.Generic;
using System.Threading.Tasks;

<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/Services/IDataStore.cs
namespace CityInMotionSend.Services
========
namespace CityInMotionApp.Services
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/Services/IDataStore.cs
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
