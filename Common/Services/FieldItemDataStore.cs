using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class FieldItemDataStore : IDataStore<SubItemEntityModel>
    {
        public static string urlMenuItem = "http://172.30.1.105:44333/api/menuitem/";
        public static string urlFieldItem = "http://172.30.1.105:44333/api/fielditem/";
        public async Task<Uri> AddItemAsync(SubItemEntityModel item)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(urlFieldItem, item);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public async Task<SubItemEntityModel> UpdateItemAsync(SubItemEntityModel item, int id)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(urlFieldItem + id, item))
            {
                response.EnsureSuccessStatusCode();

                item = await response.Content.ReadAsAsync<SubItemEntityModel>();
                return item;
            }
        }

        public async Task<HttpStatusCode> DeleteItemAsync(int id)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(urlFieldItem + id);
            return response.StatusCode;
        }

        public Task<SubItemEntityModel> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<SubItemEntityModel>> GetItemsAsync()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(urlMenuItem))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<SubItemEntityModel>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
