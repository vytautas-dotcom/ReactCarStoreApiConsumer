using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactCarStoreApiConsumer.Models
{
    public interface IStoreRepository
    {
        Task<IList<Store>> GetStoreList(Guid storeId = default);
        Task AddStore(Store store);
        Task<Store> UpdateStore(Guid storeId, Store store);
        Task DeleteStore(Guid storeId);
    }
}
