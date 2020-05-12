using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WPF_Bind
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student simpleStudent = new Student()
        {
            Id = 1,
            Name = "Jan",
            LastName = "Kowalski",
            EnlistingDate = new DateTime(2015, 10, 1)
        };

        public List<Student> students = new List<Student>()
        {
            new Student()
            {
            Id = 1,
            Name = "Jan",
            LastName = "Kowalski",
            EnlistingDate = new DateTime(2015, 10, 1)
            },
             new Student()
            {
            Id = 2,
            Name = "Jan",
            LastName = "Nowak",
            EnlistingDate = new DateTime(2016, 10, 1)
            },
              new Student()
            {
            Id = 3,
            Name = "Jan",
            LastName = "Kwiatkowski",
            EnlistingDate = new DateTime(2017, 10, 1)
            },
               new Student()
            {
            Id = 4,
            Name = "Jan",
            LastName = "Smith",
            EnlistingDate = new DateTime(2018, 10, 1)
            },
        };
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = simpleStudent;
            t2.SetBinding(TextBox.TextProperty, new Binding("Name"));

            StudnetLV.ItemsSource = students;
            StudentLB.ItemsSource = students;
        }
    }
}
