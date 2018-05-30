using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPgui.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPgui
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private static string uri = "http://localhost:62956/api/users/login";
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void Button_TappedAsync(object sender, TappedRoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                User user = new User
                {
                    Name = Username.Text,
                    Password = Password.Password
                };

                string jsonifiedUser = JsonConvert.SerializeObject(user);
                var response = await client.PostAsync(uri, new StringContent(jsonifiedUser, System.Text.Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    var final = response.Content.ReadAsStringAsync().Result;
                    MainPage.loggedInUserId = int.Parse(final);
                    Flyout flyout = Resources["SuccessFlyout"] as Flyout;
                    flyout.ShowAt(Page);

                }
                else
                {
                    Flyout flyout = Resources["FailFlyout"] as Flyout;
                    flyout.ShowAt(Page);
                }
            }

        }
    }
}
