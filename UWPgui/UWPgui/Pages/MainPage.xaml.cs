using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using UWPgui.Models;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPgui
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static HttpClient client = new HttpClient();
        public static int? loggedInUserId = null;


        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private void AfterUserLogin()
        {

        }

        private void HomePageLogo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //return to homepage
        }

        private void Register_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Content = new RegistrationPage();

        }

        private void Login_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Content = new LoginPage();
        }

        private void NavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //idontcare.Visibility = Visibility.Collapsed;

            var asd = new NavigationViewItem();
            asd.Content = "asdasdasd";
            NavView.MenuItems.Add(asd);
        }

        private void myProfile_Tapped(object sender, TappedRoutedEventArgs e)
        {
            User user = GetUserProfile();
            ContentFrame.Content = new UserPage(user);

        }

        private void myOrders_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }










        private User GetUserProfile()
        {
            HttpResponseMessage response = client.GetAsync("http://localhost:62956/api/users/" + loggedInUserId).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<User>(stringData);
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
