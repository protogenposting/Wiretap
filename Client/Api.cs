using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Client;

public static class Api{
    public static string requestLocation = "http://localhost:3000/api/";
    private static readonly HttpClient client = new HttpClient();
    public async static Task<Jobject> createUser(string username, string password)
    {
        var values = new Dictionary<string, string>
        {
            { "username", username },
            { "password", password }
        };

        var content = new FormUrlEncodedContent(values);

        var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

        var responseString = await response.Content.ReadAsStringAsync();

        Console.WriteLine(responseString);

        return (JObject)JsonConvert.DeserializeObject(result);
    }
}