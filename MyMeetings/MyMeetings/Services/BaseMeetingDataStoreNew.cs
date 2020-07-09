using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MyMeetings.Models;
using MyMeetings.Models.BaseMeeting;
using MyMeetings.Models.Meetings;
using MyMeetings.Services;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseMeetingDataStore2))]
namespace MyMeetings.Services
{
    public class BaseMeetingDataStore2: IBaseMeetingDataStore
    {
        private  List<BaseMeeting> _baseMeetings;
        private HttpClient client;

        public BaseMeetingDataStore2()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
            _baseMeetings = new List<BaseMeeting>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<IEnumerable<BaseMeeting>> GetBaseMeetingsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"v1/base-meetings");
                _baseMeetings = await Task.Run(() => JsonConvert.DeserializeObject<List<BaseMeeting>>(json));
            }
            return _baseMeetings;
        }

        public async Task<BaseMeeting> GetBaseMeetingAsync(int id)
        {
            BaseMeeting bMeeting = new BaseMeeting();
            if (id !=0 && IsConnected)
            {
                var json = await client.GetStringAsync($"v1/base-meetings/{id}");
                bMeeting = await Task.Run(() => JsonConvert.DeserializeObject<BaseMeeting>(json));
            }
            return bMeeting;
        }

        public async Task<bool> AddBaseMeetingAsync(BaseMeeting item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"v1/base-meetings", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            if(response.IsSuccessStatusCode == true)
                _baseMeetings.Add(item);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBaseMeetingAsync(int id)
        {
            if (id == 0 && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"v1/base-meetings{id}");

            return response.IsSuccessStatusCode;
        }


        public async Task<bool> UpdateBaseMeetingAsync(BaseMeeting item)
        {
            if (item == null || item.Id == 0 || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"v1/base-meetings/{item.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }
    }
}
