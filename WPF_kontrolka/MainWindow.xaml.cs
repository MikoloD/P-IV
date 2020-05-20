using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_kontrolka
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<User> lista = new List<User>()
        {
            new User()
            {
            Login = "User1",
            Password = "qwerty1"
            },
            new User()
            {
            Login = "User2",
            Password = "qwerty2"
            },
            new User()
            {
            Login = "User3",
            Password = "qwerty3"
            },
    };
        public bool CheckLogin(string login, SecureString password)
        {
            var pwd = default(string);
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(password);
                pwd = Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
            foreach(var elem in lista)
            {
                if (elem.Login == login && elem.Password == pwd) return true;
            }
            return false;
        }
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool log = CheckLogin(textbox1.Text.ToString(), passbox1.SecurePassword);
            if (log == true)
            {
                textbox2.Text = $"Witaj {textbox1.Text}, możesz się wylogoać";
                textbox1.Text = "";
                passbox1.Clear();
            }
            else
            {
                textbox1.Text = "";
                passbox1.Clear();
                textbox2.Text = $"Błąd przy logowaniu";
            }
        }
        private void Button_Click_logout(object sender, RoutedEventArgs e)
        {
            textbox2.Text = $"Zaloguj się";
            textbox1.Text = "";
            passbox1.Clear();

        }
    }
}
