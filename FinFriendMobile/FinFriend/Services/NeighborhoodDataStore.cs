using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinFriend.Models;

namespace FinFriend.Services
{
    public class NeighborhoodDataStore : IDataStore<Neighborhood>
    {
        IEnumerable<Neighborhood> _neighborhoods;

        public NeighborhoodDataStore()
        {
            _neighborhoods = new List<Neighborhood>()
            {
                new Neighborhood()
                {
                    Id = 1,
                    Name = "Militari"
                },
                new Neighborhood()
                {
                    Id = 2,
                    Name = "Drumul Taberei"
                },
                new Neighborhood()
                {
                    Id = 3,
                    Name = "Chitila"
                },
                new Neighborhood()
                {
                    Id = 4,
                    Name = "Titan"
                }
            };
        }

        public Task<Neighborhood> GetItemAsync(string id)
        {
            if (int.TryParse(id, out int nId))
            {
                var neighborhood = _neighborhoods.Where(n => n.Id == nId).FirstOrDefault();
                return Task.FromResult(neighborhood);
            }

            return Task.FromResult(Neighborhood.EMPTY);
        }

        public Task<IEnumerable<Neighborhood>> GetItemsAsync(bool forceRefresh = false)
        {
            return Task.FromResult(_neighborhoods);
        }
    }
}
