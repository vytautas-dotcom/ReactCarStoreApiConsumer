using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReactCarStoreApiConsumer.Models
{
    public class CarRepository : ICarRepository
    {
        public async void AddCar(Guid storeId, Car car)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(car),
                                                                encoding: Encoding.UTF8,
                                                                mediaType: "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44372/stores/"+storeId+"/cars", stringContent))
                {
                    
                }
            }
        }

        public async Task<Car> GetCar(Guid storeId, Guid carId)
        {
            Car receivedCar = new Car();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44372/stores/" + storeId + "/cars/" + carId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receivedCar = JsonConvert.DeserializeObject<Car>(apiResponse);
                }
            }
            return receivedCar;
        }

        public async void UpdateCar(Guid storeId, Car car)
        {
            Car receivedCar = new Car();
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(car),
                                                                Encoding.UTF8,
                                                                "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44372/stores/" + storeId + "/cars", stringContent))
                {
                }
            }
        }

        public async void DeleteCar(Guid storeId, Guid carId)
        {
            using (var httpClient = new HttpClient())
            {
                using (await httpClient.DeleteAsync("https://localhost:44372/stores/"+storeId+"/cars/"+carId))
                {

                }
            }
        }
    }
}
