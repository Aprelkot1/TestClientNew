using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
using TestClient.RequestProvider;
using TestClient.ServiceProvider;
using TestClient.ViewModels;

namespace TestClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ItemsSource iS = new ItemsSource();
       
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TestViewModel();
            //iS.OnStart(TestListBox);
           
        }
        public void TakeTest_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window.Title.Contains("Редактировать тест"))
                {
                    window.Close();
                }
            }
            FindChildrenProvider fcp = new FindChildrenProvider();
            var Id = fcp.FindTextBoxChildrenText("TestIdBox", sender as System.Windows.Controls.Button);
            var Name = fcp.FindTextBoxChildrenText("TestNameBox", sender as System.Windows.Controls.Button);
            EditTestWindow contactsWindow = new EditTestWindow(Id);
            GetListsProvider gl = new GetListsProvider();
            gl.GetQuestions(Id);
            contactsWindow.Title = "Редактировать тест " + Name;
            contactsWindow.Show();
            contactsWindow.Owner = this;
        }
    }
}
