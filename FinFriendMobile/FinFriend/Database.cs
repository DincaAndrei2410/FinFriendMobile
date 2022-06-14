using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FinFriend.Services;
using SQLite;

namespace FinFriend
{
	public class DataStore<T> : IDataStore<T> where T : new()
    {
        private const string FileName = "finfriend.db3";

        private static SQLiteOpenFlags Flags =>
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.FullMutex |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        private static readonly SQLiteAsyncConnection AsyncInstance = new SQLiteAsyncConnection(Path, Flags);

        private static string Path
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return System.IO.Path.Combine(basePath, FileName);
            }
        }

        public Task InitializeData()
        {
            if (AsyncInstance.TableMappings.All(x => x.MappedType != typeof(T)))
            {
                try
                {
                    AsyncInstance.CreateTableAsync<T>();
                }
                catch (Exception ex)
                {
                    var exception = new Exception("Db initialize exception", ex);
                    Debug.WriteLine(ex);
                }
            }

            return Task.CompletedTask;
        }

        public Task<List<T>> GetItemsAsync()
        {
            return AsyncInstance.Table<T>().ToListAsync();
        }

        public async Task<int> InsertAsync(IEnumerable<T> list)
        {
            await AsyncInstance.DeleteAllAsync<T>();
            var result = await AsyncInstance.InsertAllAsync(list);
            return result;
        }
    }
}

