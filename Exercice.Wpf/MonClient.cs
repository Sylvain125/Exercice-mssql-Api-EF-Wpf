using Exercice.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Exercice.Wpf
{
    public class MonClient
    {

        HttpClient client = new HttpClient();

        private string url = "https://localhost:7105/api/UserInfo";
        public async Task<UserInfoDto> GetById(string idShow)
        {
            string urlTotal =  url + "/" + idShow;
            var content = await client.GetFromJsonAsync<UserInfoDto>(urlTotal);
            return content;
        }
        public async Task<IEnumerable<UserInfoDto>> GetAll()
        {
            var content1 = await client.GetFromJsonAsync<IEnumerable<UserInfoDto>>(url);
            return content1;
        }

        public async Task<HttpResponseMessage> Post(UserInfoDto userInfoDto)
        {
            var content = await client.PostAsJsonAsync<UserInfoDto>(url, userInfoDto);
            return content;
        }
        public async Task<string> DeleteById(string idDelete)
        {
            string urlTotal = url + "/" + idDelete;
            var content = await client.DeleteAsync(urlTotal);
            return content.ToString();
        }

        public async Task<string> UpdateById(UserInfoDto updateDto, string idUpdate)
        {
            string urlTotal = url + "/" + idUpdate;
            var content = await client.PutAsJsonAsync<UserInfoDto>(urlTotal, updateDto);
            return content.ToString();
        }
    }
}

