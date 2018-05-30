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
using System.ComponentModel;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPgui
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private static HttpClient client = new HttpClient();
        private static User loggedInUser;

        private static int _loggedInUserId = -1;
        public event PropertyChangedEventHandler PropertyChanged;

        public int loggedInUserId
        {
            get { return _loggedInUserId; }
            set
            {
                _loggedInUserId = value;
                OnPropertyChanged("loggedInUserId");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
            this.PropertyChanged += new PropertyChangedEventHandler(myClass_PropertyChanged);
        }

        private void myClass_PropertyChanged(object sender, EventArgs e)
        {
            if (loggedInUserId != -1)
            {
                loggedInUser = GetUserProfile(loggedInUserId);

                MainPage mp = (Window.Current.Content as Frame).Content as MainPage;
                mp.Username.Text = "Welcome " + loggedInUser.Name;
                mp.Username.Visibility = Visibility.Visible;
                mp.Logout.Visibility = Visibility.Visible;

                mp.Login.Visibility = Visibility.Collapsed;
                mp.Register.Visibility = Visibility.Collapsed;

                mp.myProfileHeader.Visibility = Visibility.Visible;
                mp.myProfile.Visibility = Visibility.Visible;
                mp.myOrders.Visibility = Visibility.Visible;
            }
            else
            {
                loggedInUser = null;
                MainPage mp = (Window.Current.Content as Frame).Content as MainPage;
                mp.Username.Visibility = Visibility.Collapsed;
                mp.Logout.Visibility = Visibility.Collapsed;

                mp.Login.Visibility = Visibility.Visible;
                mp.Register.Visibility = Visibility.Visible;

                mp.myProfileHeader.Visibility = Visibility.Collapsed;
                mp.myProfile.Visibility = Visibility.Collapsed;
                mp.myOrders.Visibility = Visibility.Collapsed;
            }
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
            ContentFrame.Content = new UserPage(loggedInUser);

        }

        private void myOrders_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }










        private User GetUserProfile(int id)
        {
            HttpResponseMessage response = client.GetAsync("http://localhost:62956/api/users/" + id).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<User>(stringData);
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Logout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            loggedInUserId = -1;
        }
    }
}
