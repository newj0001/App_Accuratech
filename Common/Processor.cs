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
    }

    public class Processor : IProcessor
    {
        public static string urlMenuItem = "http://172.30.1.103:44333/api/menuitem/";
        public static string urlFieldItem = "http://172.30.1.103:44333/api/fielditem/";
        public static string urlRegistration = "http://172.30.1.103:44333/api/registration";
        public static async Task<List<MenuItemEntity>> LoadMenus()
        {

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(urlMenuItem))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<MenuItemEntity>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<SubItemEntity>> LoadSubItems()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(urlMenuItem))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<SubItemEntity>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<Registration>> LoadRegistrations()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(urlRegistration))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Registration>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<Uri> CreateMenuItem(MenuItemEntity menuItem)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(urlMenuItem, menuItem);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public static async Task<Uri> CreateFieldItem(SubItemEntity subItem)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(urlFieldItem, subItem);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public static async Task<Uri> CreateRegistration(Registration registration)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(urlRegistration, registration);
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

        public static async Task<Uri> CreateRegistrationValue(RegistrationValue registrationValue)
        {
            HttpResponseMessage response =
                await ApiHelper.ApiClient.PostAsJsonAsync(urlRegistration, registrationValue);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        Task<HttpStatusCode> IProcessor.DeleteMenuItemAsync(int id)
        {
            return DeleteMenuItem(id);
        }
    }
}
