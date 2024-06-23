using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeMaria.Models;

namespace DeMaria.Services
{
    public class ViaCEP
    {
        public async Task<AddressModel> GetAddressFromCepAsync(string zipCode)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://viacep.com.br/ws/{zipCode}/json/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                AddressModel address = JsonConvert.DeserializeObject<AddressModel>(responseBody);

                if (address != null && !string.IsNullOrEmpty(address.ZipCode))
                {
                    return address;
                }
                throw new Exception("CEP não encontrado.");
            }
        }
    }
}

