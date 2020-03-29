using System.Collections.Generic;
using System.Threading.Tasks;
using HSESupporter.Models;

namespace HSESupporter.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(Problem item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}