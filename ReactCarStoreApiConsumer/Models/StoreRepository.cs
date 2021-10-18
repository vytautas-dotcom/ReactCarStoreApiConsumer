using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReactCarStoreApiConsumer.Models
{
    public class StoreRepository : IStoreRepository

    {
        public async Task<IList<Store>> GetStoreList(Guid storeId = default)
        {
            IList<Store> storeList = new List<Store>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44372/stores/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    storeList = JsonConvert.DeserializeObject<List<Store>>(apiResponse);
                }
            }
            var id = storeId != Guid.Empty ? storeId : (from store in storeList select store.Id).First();
            //ViewBag.storeId = id;
            return storeList;
        }
        public async Task AddStore(Store store)
        {
            Store receivedStore = new Store();
            store.CarList = new List<Car>();
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(store),
                                                                encoding: Encoding.UTF8,
                                                                mediaType: "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44372/stores/", stringContent))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receivedStore = JsonConvert.DeserializeObject<Store>(apiResponse);
                }
            }
        }
        public async Task<Store> UpdateStore(Guid storeId, Store store = null)
        {
            if (store == null)
            {
                List<Store> storeList = new List<Store>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://localhost:44372/stores/"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        storeList = JsonConvert.DeserializeObject<List<Store>>(apiResponse);
                    }
                }
                var storeForEdit = (from stores in storeList where stores.Id == storeId select stores).First();

                return storeForEdit;
            }
            else
            {
                if (store.CarList.Count == 0)
                    store.CarList = new List<Car>();

                using (var httpClient = new HttpClient())
                {
                    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(store),
                                                                    encoding: Encoding.UTF8,
                                                                    mediaType: "application/json");
                    using (var response = await httpClient.PutAsync("https://localhost:44372/stores/", stringContent))
                    {
                        return null;
                    }
                }
            }
        }

        public async Task DeleteStore(Guid storeId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44372/stores/"+storeId))
                {
                }
            }
        }
    }
}
