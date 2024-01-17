using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Valyuta_bot
{
    public class Hisobla
    {


        public string Name { get; set; }
   

        public Hisobla(string name)
        {
            Name = name;
           
        }

        public void ShowName()
        {

            HttpClient httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://nbu.uz/uz/exchange-rates/json/");

            var response = httpClient.SendAsync(request).Result;

            var boby = response.Content.ReadAsStringAsync().Result;

            var courses = JsonSerializer.Deserialize<List<Model>>(boby);


            foreach (var item in courses)
            {
                if (item.code == Name)
                {
                    Console.WriteLine(item.cb_price);
                }
            }


        }



}
}
