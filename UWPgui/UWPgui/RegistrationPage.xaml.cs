using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPgui
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            this.InitializeComponent();
        }

        private void submit_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void passwordc_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TickPw(password.Password == passwordc.Password);
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TickPw(password.Password == passwordc.Password);
        }

        private void emailc_TextChanged(object sender, TextChangedEventArgs e)
        {
            emailcIcon.Visibility = Visibility.Visible;

            if (emailc.Text == email.Text)
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

            if (bully)
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
    }
}
