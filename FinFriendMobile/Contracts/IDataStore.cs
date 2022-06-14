using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinFriend.Services
{
    public interface IDataStore<T>
    {
        Task<List<T>> GetItemsAsync();
    }
}
