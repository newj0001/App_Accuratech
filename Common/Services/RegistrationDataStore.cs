using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class RegistrationDataStore : IDataStore<RegistrationModel>
    {
        public static string urlRegistration = "http://172.30.1.105:44333/api/registrationModel/";

        public async Task<Uri> AddItemAsync(RegistrationModel item)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(urlRegistration, item);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public Task<RegistrationModel> UpdateItemAsync(RegistrationModel item, int id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationModel> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<RegistrationModel>> GetItemsAsync()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(urlRegistration))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<RegistrationModel>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
