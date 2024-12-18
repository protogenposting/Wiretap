using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Client;



/// <summary>
/// The Api class is used for calling the api and stuff
/// </summary>
public static class Api
{
    public static string requestLocation = "http://localhost:3000/api/"; //the location of our server, keep as localhost until we actually find a way to host this.
    public static string sessionID = ""; //the session ID to send to access certain parts of the api
    private static readonly HttpClient client = new HttpClient(); //the client that will be calling all requests

    /// <summary>
    /// This function lets you create a user
    /// </summary>
    /// <param name="username">The username to give</param>
    /// <param name="password">The password to give</param>
    /// <returns>The response from the api</returns>
    public static async Task<string> createUser(string username, string password)
    {
        var values = new Dictionary<string, string>
        {
            { "name", username },
            { "username", username },
            { "password", password }
        };

        string returnValue = await callApiPost("newUser", values);

        return returnValue;
    }
    /// <summary>
    /// This function lets you login
    /// </summary>
    /// <param name="username">The username to give</param>
    /// <param name="password">The password to give</param>
    /// <returns>Either your session ID as a json or an error</returns>
    public static async Task<string> logIn(string username, string password)
    {
        var values = new Dictionary<string, string>
        {
            { "name", username },
            { "username", username },
            { "password", password }
        };

        string returnValue = await callApiPost("login", values);

        return returnValue;
    }
    /// <summary>
    /// This function lets you call a POST request to the api
    /// </summary>
    /// <param name="link">The api link</param>
    /// <param name="values">The values to send</param>
    /// <returns>The response from the api</returns>
    public async static Task<string> callApiPost(string link, Dictionary<string, string> values)
    {
        //Send a post request with our jsonified data to the server
        var response = await client.PostAsync(
            requestLocation + link,
            new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json")
        );

        //read the response
        var responseString = await response.Content.ReadAsStringAsync();

        return responseString;
    }
}