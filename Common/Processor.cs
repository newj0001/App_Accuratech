using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IProcessor
    {
        Task<HttpStatusCode> DeleteMenuItemAsync(int id);
        Task<HttpStatusCode> DeleteFieldItemAsync(int id);
    }

    public class Processor : IProcessor
    {
        public static string urlMenuItem = "http://172.30.1.105:44333/api/menuitem/";
        public static string urlFieldItem = "http://172.30.1.105:44333/api/fielditem/";
        public static string urlRegistration = "http://172.30.1.105:44333/api/registrationModel/";
        public static string urlRegistrationValues = "http://172.30.1.105:44333/api/registrationvalues";
        public static async Task<List<MenuItemEntityModel>> LoadMenus()
        {

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(urlMenuItem))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<MenuItemEntityModel>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<SubItemEntityModel>> LoadSubItems()
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

        public static async Task<List<RegistrationModel>> LoadRegistrations()
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

        public static async Task<Uri> CreateMenuItem(MenuItemEntityModel menuItem)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(urlMenuItem, menuItem);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public static async Task<Uri> CreateFieldItem(SubItemEntityModel subItem)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(urlFieldItem, subItem);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public static async Task<Uri> CreateRegistration(RegistrationModel registrationModel)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(urlRegistration, registrationModel);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public static async Task<HttpStatusCode> DeleteMenuItem(int id)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(urlMenuItem + id);
            return response.StatusCode;
        }

        public static async Task<HttpStatusCode> DeleteSubItem(int id)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(urlFieldItem + id);
            return response.StatusCode;
        }

        public static async Task<Uri> CreateRegistrationValue(ICollection<RegistrationValueModel> registrationValue)
        {
            HttpResponseMessage response =
                await ApiHelper.ApiClient.PostAsJsonAsync(urlRegistrationValues, registrationValue);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        Task<HttpStatusCode> IProcessor.DeleteMenuItemAsync(int id)
        {
            return DeleteMenuItem(id);
        }

        public Task<HttpStatusCode> DeleteFieldItemAsync(int id)
        {
            return DeleteSubItem(id);
        }
    }
}
