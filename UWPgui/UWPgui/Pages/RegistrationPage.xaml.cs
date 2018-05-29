using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
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
    public sealed partial class RegistrationPage : Page
    {
        private static string uri = "http://localhost:62956/api/users/";

        public RegistrationPage()
        {
            this.InitializeComponent();
        }

        private async void submit_TappedAsync(object sender, TappedRoutedEventArgs e)
        {
            if (password.Password.Length < 5 || 
                passwordc.Password.Length < 5 ||
                email.Text.Length == 0 ||
                emailc.Text.Length == 0 ||
                userName.Text.Length < 5)
            {
                Flyout flyout = Resources["FieldsNotFilledRightFlyout"] as Flyout;
                flyout.ShowAt(Page);
            }
            if (passwordcIcon.Symbol == Symbol.Accept && emailcIcon.Symbol == Symbol.Accept)
            {
                User user = new User{
                    Name = userName.Text,
                    Email = email.Text,
                    Password = password.Password};

                string jsonifiedUser = JsonConvert.SerializeObject(user);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsync(uri, new StringContent(jsonifiedUser, System.Text.Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        Flyout flyout = Resources["SuccessFlyout"] as Flyout;
                        flyout.ShowAt(Page);
                    }
                    else
                    {
                        Flyout flyout = Resources["AlredyExistFlyout"] as Flyout;
                        flyout.ShowAt(Page);
                    }
                }
            }
            else
            {
                Flyout flyout = Resources["FieldsNotFilledRightFlyout"] as Flyout;
                flyout.ShowAt(Page);
            }
        }

        private void passwordc_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TickPw(password.Password == passwordc.Password);
            
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TickPw(password.Password == passwordc.Password);
        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (emailc.Text == email.Text && IsEmailValid(email.Text))
            {
                emailcIcon.Symbol = Symbol.Accept;
                emailcIcon.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }
            else
            {
                emailcIcon.Symbol = Symbol.Cancel;
                emailcIcon.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }

        private void emailc_TextChanged(object sender, TextChangedEventArgs e)
        {
            emailcIcon.Visibility = Visibility.Visible;

            if (emailc.Text == email.Text && IsEmailValid(email.Text))
            {
                emailcIcon.Symbol = Symbol.Accept;
                emailcIcon.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }
            else
            {
                emailcIcon.Symbol = Symbol.Cancel;
                emailcIcon.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }

        private void TickPw(bool bully)
        {
            passwordIcon.Visibility = Visibility.Visible;
            passwordcIcon.Visibility = Visibility.Visible;

            if (bully && password.Password.Length >= 5)
            {
                passwordIcon.Symbol = Symbol.Accept;
                passwordIcon.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                passwordcIcon.Symbol = Symbol.Accept;
                passwordcIcon.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }
            else
            {
                passwordIcon.Symbol = Symbol.Cancel;
                passwordIcon.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                passwordcIcon.Symbol = Symbol.Cancel;
                passwordcIcon.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }

        private bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
