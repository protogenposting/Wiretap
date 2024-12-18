using System;
using System.Net;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Client;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public async void SignUp(object sender, RoutedEventArgs args)
    {
        string response = await Api.createUser(usernameBox.Text,passwordBox.Text);

        if(response.Contains("UNIQUE"))
        {
            message.Text = "Please Choose A Unique Username!";
        }
        else
        {
            message.Text = "Welcome to Wiretap, Please Press Login";
        }

        Console.WriteLine(response);
    }
    public async void LogIn(object sender, RoutedEventArgs args)
    {
        string response = await Api.logIn(usernameBox.Text,passwordBox.Text);

        if(response.Contains("Not Found"))
        {
            message.Text = "Your Credentials Are Incorrect";
        }
        else
        {
            var result = (JObject)JsonConvert.DeserializeObject(response);

            Api.sessionID = result["sessionID"].Value<string>();
        }
    }
}